using BattleCity.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace BattleCity.Windows
{
    /// <summary>
    /// Логика взаимодействия для GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {

        static double HeightWindow = System.Windows.SystemParameters.PrimaryScreenHeight;
        static double WeightWindow = System.Windows.SystemParameters.PrimaryScreenWidth;
        static double GameSize = HeightWindow * 0.9;
        DispatcherTimer gameTimer = new DispatcherTimer();
        static int timerMS = 20; //как часто запускается таймер
        int timer;



        Tank tank1 = new Tank(GameSize * 0.5, GameSize * 0.5, 50, 5, 5);

        ViewPlayerTank player;




        public GameWindow()
        {   
            Width = HeightWindow ;
            Height = WeightWindow;
            InitializeComponent();
            canvas.Focus();

            canvas.Width = GameSize;
            canvas.Height = GameSize;

            timer = 0;
            player = new ViewPlayerTank(tank1, Key.Left, Key.Right, Key.Up, Key.Down, Key.Enter, 1, ref canvas);

       
            gameTimer.Tick += GameTimerEventAsync;
            gameTimer.Interval = TimeSpan.FromMilliseconds(timerMS);
            gameTimer.Start();
        }

        private void GameTimerEventAsync(object sender, EventArgs e)
        {
            timer += 20;
            player.UpdateAsync();
            player.UpdateKeyboard();
        }

        private void map_KeyDown(object sender, KeyEventArgs e)
        {
            if (player.Shoot(e, timer))
            {
                timer = 0;
            }
            //player.KeyDown(e);
        }

        private void map_KeyUp(object sender, KeyEventArgs e)
        {
            //player.KeyUp(e);
        }
    }
}
