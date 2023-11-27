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



            //level = new Level(id);
            level = new Level(1, new List<Wall> { }, 70, 100, 20, 100);
            this.canvas = canvas;
            

        }

        public void startGame()
        {
            Tank tank1 = new Tank(level.StartPosx1 * X, level.StartPosy1 * X, 10*X, 1*X, 6);
            Tank tank2 = new Tank(level.StartPosx2 * X, level.StartPosy2 * X, 10*X, 1*X, 6);
            player1 = new ViewPlayerTank(tank1, Key.A, Key.D, Key.W, Key.S, Key.Space, 1, ref canvas);
            player2 = new ViewPlayerTank(tank2, Key.Left, Key.Right, Key.Up, Key.Down, Key.Enter, 1, ref canvas);

            gameTimer.Tick += GameTimerEvent;
            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Start();
        }

        public void Colision()
        {
           if (player1.Tank.isCollide(player2.Tank))
           {
                player1.Tank.CollideWithTank();
                player2.Tank.CollideWithTank();
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
