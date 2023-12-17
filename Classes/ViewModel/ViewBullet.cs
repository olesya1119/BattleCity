using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace BattleCity.Classes
{
    internal class ViewBullet
    {
        private Rectangle rectangle;
        private Canvas canvas;

        public Bullet Bullet { get; set; }

        public ViewBullet(Bullet bullet, ref Canvas canvas)
        {
            this.Bullet = bullet;
            this.canvas = canvas;

            rectangle = new Rectangle();
            rectangle.Height = bullet.Size;
            rectangle.Width = bullet.Size;

            rectangle.Fill = Media.getAnimationFramesWithRotate(AnimationFrames.Bullet)[(int)bullet.Direction];
            Canvas.SetLeft(rectangle, bullet.PosX - bullet.Size / 2);
            Canvas.SetBottom(rectangle, bullet.PosY - bullet.Size / 2);

            canvas.Children.Add(rectangle);
        }

        public void Update()
        {
            Bullet.Fly();
            Canvas.SetLeft(rectangle, Bullet.PosX - Bullet.Size / 2);
            Canvas.SetBottom(rectangle, Bullet.PosY - Bullet.Size / 2);

            if (Bullet.HP ==  0) { 
                Death();
            }
            
        }

        public void Death()
        {
            canvas.Children.Remove(rectangle);
            Bullet.HP = 0;
        }
    }
}
