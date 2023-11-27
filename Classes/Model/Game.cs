using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows.Input;
using System.Windows.Controls;

namespace BattleCity.Classes.Model
{
    internal class Game
    {
        static double HeightWindow = System.Windows.SystemParameters.PrimaryScreenHeight;
        static double WeightWindow = System.Windows.SystemParameters.PrimaryScreenWidth;
        static double GameSize = HeightWindow * 0.9;
        DispatcherTimer gameTimer = new DispatcherTimer();

        private Level level;
        private ViewPlayerTank player1, player2;
        private Canvas canvas;
        public double X = GameSize/200; //Размер поля 200*200. При перемножении на X получем длину в пикселях экрана
        public Level Level { get; set; }


        public Game(int id, ref Canvas canvas)
        {
            level = new Level(id);
            
        }

        public void startGame()
        {
            Tank tank1 = new Tank(level.StartPosx1 *X, level.StartPosy1 * X, 5*X, 2*X, 6);
            Tank tank2 = new Tank(level.StartPosx2 * X, level.StartPosy2 * X, 5*X, 2*X, 6);
            player1 = new ViewPlayerTank(tank1, Key.A, Key.D, Key.W, Key.S, Key.Space, 1, ref canvas);
            player1 = new ViewPlayerTank(tank2, Key.Left, Key.Right, Key.Up, Key.Down, Key.Enter, 1, ref canvas);

        }



        public void KeyDown(KeyEventArgs e)
        {
            player1.Shoot(e);
            player2.Shoot(e);

        }
    }
}
