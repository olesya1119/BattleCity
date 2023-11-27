using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace BattleCity.Classes
{
    internal class ViewWall
    {
        private Wall wall;
        private Rectangle rectangle;
        private Canvas canvas;
        public ViewWall(Wall wall, ref Canvas canvas)
        {
            this.wall = wall;
            this.canvas = canvas;

            rectangle = new Rectangle();
            rectangle.Height = wall.Size;
            rectangle.Width = wall.Size;
            
            if (wall.TypeWall == TypeWall.Steel) { 
                rectangle.Fill = Media.getTexture(Texture.Steel);
            }
            else if (wall.TypeWall == TypeWall.Brick)
            {
                rectangle.Fill = Media.getTexture(Texture.Brick);
            }
            else
            {
                rectangle.Fill = Media.getTexture(Texture.Error);
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
