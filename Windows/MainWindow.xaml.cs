using BattleCity.Classes;
using BattleCity.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BattleCity
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /*
        int Flag = 1;
        int X = 10, Y = 10;
        Rectangle rectangle = new Rectangle();
        public MainWindow()
        {


            InitializeComponent();
            
            rectangle.Width = 50;
            rectangle.Height = 50;
            rectangle.Fill = Brushes.Green;
            
      
            Canvas.SetLeft(rectangle, X); //X
            Canvas.SetTop(rectangle, Y); //Y
            canvas.Children.Add(rectangle);

        }
        
        private void canvas_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A || e.Key == Key.W || e.Key == Key.S || e.Key == Key.D) 
            { 
            Flag = 1;
                while (Flag == 1)
                {
                    if (e.Key == Key.A)
                    {
                        Canvas.SetLeft(rectangle, Canvas.GetLeft(rectangle) - 100);
                    }
                    else if (e.Key == Key.D)
                    {
                        Canvas.SetLeft(rectangle, Canvas.GetLeft(rectangle) + 100);
                    }
                    else if (e.Key == Key.W)
                    {
                        Canvas.SetTop(rectangle, Canvas.GetTop(rectangle) + 100);
                    }
                    else
                    {
                        Canvas.SetTop(rectangle, Canvas.GetTop(rectangle) - 100);
                    }
                }
            }
        }

        private void canvas_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.A || e.Key == Key.W || e.Key == Key.S || e.Key == Key.D)
            {
                Flag = 0;
            }
        }
        
        protected override void OnPreviewKeyDown(KeyEventArgs e)
        {
            
            if (e.Key == Key.A || e.Key == Key.W || e.Key == Key.S || e.Key == Key.D)
            {
                Flag = 1;
                while (Flag == 1)
                {
                    if (e.Key == Key.A)
                    {
                        Canvas.SetLeft(rectangle, Canvas.GetLeft(rectangle) - 100);
                    }
                    else if (e.Key == Key.D)
                    {
                        Canvas.SetLeft(rectangle, Canvas.GetLeft(rectangle) + 100);
                    }
                    else if (e.Key == Key.W)
                    {
                        Canvas.SetTop(rectangle, Canvas.GetTop(rectangle) + 100);
                    }
                    else
                    {
                        Canvas.SetTop(rectangle, Canvas.GetTop(rectangle) - 100);
                    }
                }
            }


            base.OnPreviewKeyDown(e);
        }

        protected override void OnPreviewKeyUp(KeyEventArgs e)
        {
            if (e.Key == Key.A || e.Key == Key.W || e.Key == Key.S || e.Key == Key.D)
            {
                Flag = 0;
            }

            base.OnPreviewKeyUp(e);
        }
        */

        public MainWindow()
        {
            
            /*InitializeComponent();
            List<Wall> walls = new List<Wall>();
            Wall wall1 = new Wall(TypeWall.Brick, 1, 1, 1, false);
            Wall wall2 = new Wall(TypeWall.Steel, 12, 45, 4, true);
            walls.Add(wall1);
            walls.Add(wall2);

            Level level = new Level(2, walls, 4, 1, 4, 6, 7, 3, 6);
            level.SaveLevel();
            Level level1 = new Level(2);

            start.Content = level1.ID.ToString();*/
            InitializeComponent();
            

        }

        private void start_Click(object sender, RoutedEventArgs e)
        {
            GameWindow gameWindow = new GameWindow();
            gameWindow.Show();
        }
    }
}
