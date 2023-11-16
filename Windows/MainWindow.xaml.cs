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


    }
}
