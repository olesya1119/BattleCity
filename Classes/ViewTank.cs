using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Windows.Input;
using System.Windows.Media.Media3D;
using System.Windows.Controls;
using System.Numerics;
using System.Windows.Media;

namespace BattleCity.Classes
{

    internal class ViewPlayerTank
    {
        private Tank tank;
        private Rectangle rectangle;
        private int frame, numberPlayer;
        private Key left, right, up, down;
        private ImageBrush[] frames;

        public Tank Tank { get { return tank; } }
        public Rectangle Rectangle { get{return rectangle; } }

        public ViewPlayerTank(Tank tank, Key left, Key right, Key up, Key down, int numberPlayer)
        {
            this.left = left;
            this.right = right;
            this.up = up;
            this.down = down;
            this.tank = tank;
            this.numberPlayer = numberPlayer;

            if (numberPlayer == 1)
            {
                frames = Media.getAnimationFrames(AnimationFrames.DrivePlayerTank1);
            }

            frame = 0;
            rectangle = new Rectangle();

            rectangle.Height = tank.Size;
            rectangle.Width = tank.Size;
            rectangle.Fill = frames[0];
            Canvas.SetLeft(rectangle, tank.PosX - tank.Size / 2);
            Canvas.SetBottom(rectangle, tank.PosY - tank.Size / 2);
        }

        public void KeyDown(KeyEventArgs e)
        {
            frame += 1;
            if (frame >= frames.Length/4) {
                frame = 0;
            }

            if (e.Key == left)
            {
                tank.GoDown = tank.GoRight = tank.GoUp = false;
                tank.GoLeft = true;
                rectangle.Fill = frames[frame + frames.Length / 4 * 3];
            }
            else if (e.Key == right)
            {
                tank.GoDown = tank.GoLeft = tank.GoUp = false;
                tank.GoRight = true;
                rectangle.Fill = frames[frame + frames.Length / 4];
            }
            else if (e.Key == up)
            {
                tank.GoDown = tank.GoRight = tank.GoLeft = false;
                tank.GoUp = true;
                rectangle.Fill = frames[frame];
            }
            else if (e.Key == down)
            {
                tank.GoLeft = tank.GoRight = tank.GoUp = false;
                tank.GoDown = true;
                rectangle.Fill = frames[frame + frames.Length / 2];
            }

            tank.Drive();
            Canvas.SetLeft(rectangle, tank.PosX - tank.Size / 2);
            Canvas.SetBottom(rectangle, tank.PosY - tank.Size / 2);
        }

        public void KeyUp(KeyEventArgs e)
        {
            if (e.Key == left)
            {
                tank.GoLeft = false;
            }
            else if (e.Key == right)
            {
                tank.GoRight = false;
            }
            else if (e.Key == up)
            {
                tank.GoUp = false;
            }
            else if (e.Key == down)
            {
                tank.GoDown = false;
            }
        }
    }
}

