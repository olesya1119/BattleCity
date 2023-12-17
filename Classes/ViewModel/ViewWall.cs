using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace BattleCity.Classes
{
    internal class ViewWall
    {
        private Rectangle rectangle;
        private Canvas canvas;
        public Wall Wall { get; }
        public ViewWall(Wall wall, ref Canvas canvas)
        {
            Wall = wall;
            this.canvas = canvas;

            rectangle = new Rectangle
            {
                Height = wall.Size,
                Width = wall.Size
            };

            if (wall.TypeWall == TypeWall.Steel) { 
                rectangle.Fill = Media.getTexture(Texture.Steel);
            }
            else if (wall.TypeWall == TypeWall.Brick)
            {
                rectangle.Fill = Media.getTexture(Texture.Brick);
            }
            else if (wall.TypeWall == TypeWall.Brick)
            {
                rectangle.Fill = Media.getTexture(Texture.Water);
            }
            else
            {
                rectangle.Fill = Media.getTexture(Texture.Water);
            }

            Canvas.SetLeft(rectangle, wall.PosX - wall.Size / 2);
            Canvas.SetBottom(rectangle, wall.PosY - wall.Size / 2);

            canvas.Children.Add(rectangle);
        }
        public void Death()
        {
            canvas.Children.Remove(rectangle);
        }
    }
}
