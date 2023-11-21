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
        private Bullet bullet;
        private Rectangle rectangle;
        private ImageBrush[] frames;
        private Canvas canvas;

        public Bullet Bullet { get { return bullet; } }

        public ViewBullet(Bullet bullet, ref Canvas canvas)
        {
            this.bullet = bullet;
            this.canvas = canvas;


            frames = Media.getAnimationFramesWithRotate(AnimationFrames.Bullet);
            rectangle = new Rectangle();
            rectangle.Height = bullet.Size;
            rectangle.Width = bullet.Size;

            rectangle.Fill = frames[(int)bullet.Direction];
            Canvas.SetLeft(rectangle, bullet.PosX - bullet.Size / 2);
            Canvas.SetBottom(rectangle, bullet.PosY - bullet.Size / 2);

            canvas.Children.Add(rectangle);
        }

        public void Fly()
        {
            bullet.Fly();
            Canvas.SetLeft(rectangle, bullet.PosX - bullet.Size / 2);
            Canvas.SetBottom(rectangle, bullet.PosY - bullet.Size / 2);

            if (bullet.ItExists ==  false) { 
                canvas.Children.Remove(rectangle);
            }
        }
    }
}
