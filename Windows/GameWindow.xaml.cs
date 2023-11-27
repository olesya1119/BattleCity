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
using BattleCity.Classes.Model;

namespace BattleCity.Windows
{
    /// <summary>
    /// Логика взаимодействия для GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        Game game;

        public GameWindow()
        {
            InitializeComponent();
            game = new Game(1, ref canvas);
            game.startGame();

            Width = game.HeightWindow ;
            Height = game.WeightWindow;
            
            canvas.Focus();

            canvas.Width = game.GameSize;
            canvas.Height = game.GameSize;
            
        }


        private void map_KeyDown(object sender, KeyEventArgs e)
        {
            game.KeyDown(e);
        }

    }
}
