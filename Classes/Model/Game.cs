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

            List<Wall> walls = new List<Wall>();
            walls.Add(new Wall(TypeWall.Brick, 56 * X, 50 * X, 5 * X ));
            walls.Add(new Wall(TypeWall.Brick, 14 * X, 50 * X, 5 * X));
            walls.Add(new Wall(TypeWall.Brick, 22 * X, 50 * X, 5 * X));
            walls.Add(new Wall(TypeWall.Brick, 170 * X, 64 * X, 5 * X));
            walls.Add(new Wall(TypeWall.Brick, 55 * X, 100 * X, 5 * X));


            //level = new Level(id);
            level = new Level(1, walls, 70, 100, 20, 100);
            this.canvas = canvas;
            
            for (int i = 0; i < level.Walls.Count; i++) {
                viewWalls.Add(new ViewWall(level.Walls[i], ref canvas));
            }
        }

        public void startGame()
        {
            Tank tank1 = new Tank(level.StartPosx1 * X, level.StartPosy1 * X, 10*X, 1*X, 6);
            Tank tank2 = new Tank(level.StartPosx2 * X, level.StartPosy2 * X, 10*X, 1*X, 6);
            player1 = new ViewPlayerTank(tank1, Key.A, Key.D, Key.W, Key.S, Key.Space, 1, ref canvas);
            player2 = new ViewPlayerTank(tank2, Key.Left, Key.Right, Key.Up, Key.Down, Key.Enter, 2, ref canvas);

            
            gameTimer.Tick += GameTimerEvent;
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Start();
        }

        public void Colision()
        {
            Tank tnk1 = new Tank(player1.Tank), tnk2 = new Tank(player2.Tank);
            if (tnk1.Go)
            {
                switch (tnk1.Direction)
                {
                    case Direction.Left:
                        tnk1.PosX -= tnk1.Speed; break;
                    case Direction.Right:
                        tnk1.PosX += tnk1.Speed; break;
                    case Direction.Up:
                        tnk1.PosY += tnk1.Speed; break;
                    case Direction.Down:
                        tnk1.PosY -= tnk1.Speed; break;
                }
                if (tnk1.isCollide(tnk2)) player1.Tank.Go = false;
            }
            if (tnk2.Go)
            {
                switch (tnk2.Direction)
                {
                    case Direction.Left:
                        tnk2.PosX -= tnk2.Speed; break;
                    case Direction.Right:
                        tnk2.PosX += tnk2.Speed; break;
                    case Direction.Up:
                        tnk2.PosY += tnk2.Speed; break;
                    case Direction.Down:
                        tnk2.PosY -= tnk2.Speed; break;
                }
                if (tnk2.isCollide(tnk1)) player2.Tank.Go = false;
            }



            if (player1.ViewBullet != null && player2.Tank.isCollide(player1.ViewBullet.Bullet))
            {
                player1.ViewBullet.Death();
                player2.Tank.CollideWithBullet();
            }

            if (player2.ViewBullet != null && player1.Tank.isCollide(player2.ViewBullet.Bullet))
            {
                player2.ViewBullet.Death();
                player1.Tank.CollideWithBullet();
            }
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
