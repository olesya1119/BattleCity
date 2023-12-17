using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows.Input;
using System.Windows.Controls;
using System.Threading;

namespace BattleCity.Classes.Model
{
    internal class Game
    {
        private double heightWindow;
        private double weightWindow;
        private double gameSize;
        private List<ViewWall> viewWalls = new List<ViewWall>();
        DispatcherTimer gameTimer = new DispatcherTimer();

        private Level level;
        private ViewPlayerTank player1, player2;
        private Tank tnk1, tnk2;
        private Canvas canvas;
        public double X; //Размер поля 200*200. При перемножении на X получем длину в пикселях экрана
        public Level Level { get; set; }
        
        public double HeightWindow { get { return heightWindow; } }
        public double WeightWindow { get { return weightWindow; } }
        public double GameSize { get { return gameSize; } }


        public Game(int id, ref Canvas canvas)
        {
            heightWindow = System.Windows.SystemParameters.PrimaryScreenHeight;
            weightWindow = System.Windows.SystemParameters.PrimaryScreenWidth;
            gameSize = heightWindow* 0.9;
            X = gameSize / 200;

            level = new Level(id);
            this.canvas = canvas;
            
            for (int i = 0; i < level.Walls.Count; i++) {
                viewWalls.Add(new ViewWall(level.Walls[i], ref canvas));
            }
        }

        public void startGame()
        {
            Tank tank1 = new Tank(level.StartPosx1 * X, level.StartPosy1 * X, 10*X, 1*X, 6);
            Tank tank2 = new Tank(level.StartPosx2 * X, level.StartPosy2 * X, 10*X, 1*X, 6);
            tnk1 = new Tank(tank1);
            tnk2 = new Tank(tank2);
            player1 = new ViewPlayerTank(tank1, Key.A, Key.D, Key.W, Key.S, Key.Space, 1, ref canvas);
            player2 = new ViewPlayerTank(tank2, Key.Left, Key.Right, Key.Up, Key.Down, Key.Enter, 2, ref canvas);

            
            gameTimer.Tick += GameTimerEvent;
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Start();
        }
        void tankCanGo(ViewPlayerTank p)
        {
            if (p.Tank.Go)
            {
                switch (p.Tank.Direction)
                {
                    case Direction.Left:
                        tnk1.PosX -= p.Tank.Speed; break;
                    case Direction.Right:
                        tnk1.PosX += p.Tank.Speed; break;
                    case Direction.Up:
                        tnk1.PosY += p.Tank.Speed; break;
                    case Direction.Down:
                        tnk1.PosY -= p.Tank.Speed; break;
                }
                if (tnk1.isCollide(tnk2)) { p.Tank.Go = false; return; }
                for (int i = 0; i < viewWalls.Count; i++)
                {
                    if (tnk1.isCollide(viewWalls[i].Wall))
                    {
                        p.Tank.Go = false;
                        return;
                    }
                }
            }
        }
        bool checkWall(ViewPlayerTank p, List<ViewWall> viewWalls, int i)
        {
            if (p.ViewBullet != null && p.ViewBullet.Bullet.isCollide(viewWalls[i].Wall))
            {
                if (!viewWalls[i].Wall.BulletCanFly) p.ViewBullet.Death();
                if (viewWalls[i].Wall.Destructibility)
                {
                    viewWalls[i].Death();
                    viewWalls.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
        void checkBullet(ViewPlayerTank p1, ViewPlayerTank p2)
        {
            if (p1.ViewBullet != null && p2.Tank.isCollide(p1.ViewBullet.Bullet))
            {
                p1.ViewBullet.Death();
                p2.Tank.CollideWithBullet();
            }
        }
        public void Colision()
        {
            tnk1.PosX = player1.Tank.PosX;
            tnk1.PosY = player1.Tank.PosY;
            tnk2.PosX = player2.Tank.PosX;
            tnk2.PosY = player2.Tank.PosY;
            tankCanGo(player1);
            tankCanGo(player2);
            if (player1.ViewBullet != null || player2.ViewBullet != null)
            {
                for (int i = 0; i < viewWalls.Count; i++)
                {
                    if (checkWall(player1, viewWalls, i)) break;
                    if (checkWall(player2, viewWalls, i)) break;
                }
            }
            checkBullet(player1, player2);
            checkBullet(player2, player1);
        }
        public void GameTimerEvent(object sender, EventArgs e)
        {
            Colision();
            player1.Update();
            player1.UpdateKeyboard();
            player2.Update();
            player2.UpdateKeyboard();
        }
        public void KeyDown(KeyEventArgs e)
        {
            player1.Shoot(e);
            player2.Shoot(e);
        }

        public bool GameOver()
        {
            if (player1.Tank.HP == 0 || player2.Tank.HP == 0) { return true; }
            return false;
        }

        
    }
}
