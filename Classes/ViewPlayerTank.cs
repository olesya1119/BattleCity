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
using System.Threading;

namespace BattleCity.Classes
{

    internal class ViewPlayerTank
    {
        private Tank tank;
        private Rectangle rectangle;
        private int frame, numberPlayer;
        private Key left, right, up, down, shoot;
        private ImageBrush[] frames;
        private Canvas canvas;
        private List<ViewBullet> bullets;

        public Tank Tank { get { return tank; } }
        public Rectangle Rectangle { get { return rectangle; } }
        public Canvas Canvas { get { return canvas; } }

        public Key Left { get { return left; } }
        public Key Right { get { return right; } }  
        public Key Up { get { return up; } }
        public Key Down { get { return down; } }


        public ViewPlayerTank(Tank tank, Key left, Key right, Key up, Key down, Key shoot, int numberPlayer, ref Canvas canvas)
        {
            this.left = left;
            this.right = right;
            this.up = up;
            this.down = down;
            this.shoot = shoot;
            this.tank = tank;
            this.numberPlayer = numberPlayer;
            this.canvas = canvas;

            if (numberPlayer == 1)
            {
                frames = Media.getAnimationFramesWithRotate(AnimationFrames.DrivePlayerTank1);
            }

            frame = 0;
            rectangle = new Rectangle();

            rectangle.Height = tank.Size;
            rectangle.Width = tank.Size;
            rectangle.Fill = frames[0];
            Canvas.SetLeft(rectangle, tank.PosX - tank.Size / 2);
            Canvas.SetBottom(rectangle, tank.PosY - tank.Size / 2);

            canvas.Children.Add(rectangle);

            bullets = new List<ViewBullet> { };
        }

        public void UpdateTexture() {
            frame += 1;
            if (frame >= frames.Length / 4)
            {
                frame = 0;
            }
            rectangle.Fill = frames[frame + (frames.Length / 4) * (int)tank.Direction];
        }

        public void Update() { 

            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Fly();
                if (!bullets[i].Bullet.ItExists) { 
                    Media media = new Media();
                    //media.Boom(bullets[i].Bullet.PosX, bullets[i].Bullet.PosY, 60, ref canvas);

                    bullets.RemoveAt(i);
                    i--;
                }
            }
        }

        
        public void KeyDown(KeyEventArgs e)
        {
            if (e.Key == left)
            {
                tank.Direction = Direction.Left;;
            }
            else if (e.Key == right)
            {
                tank.Direction = Direction.Right;
            }
            else if (e.Key == up)
            {
                tank.Direction = Direction.Up;
            }
            else if (e.Key == down)
            {
                tank.Direction = Direction.Down;
            }

            if (Keyboard.IsKeyDown(left) || Keyboard.IsKeyDown(right) || Keyboard.IsKeyDown(up) || Keyboard.IsKeyDown(down))
            {
                tank.Go = true;
                UpdateTexture();
                tank.Drive();
            }


            if (e.Key == shoot)
            {
                bullets.Add(new ViewBullet(tank.Shoot(), ref canvas));
            }

            Canvas.SetLeft(rectangle, tank.PosX - tank.Size / 2);
            Canvas.SetBottom(rectangle, tank.PosY - tank.Size / 2);
        }

        public void KeyUp(KeyEventArgs e)
        {
            if (e.Key == left && tank.Direction == Direction.Left)
            {
                tank.Go = false;
            }
            else if (e.Key == right && tank.Direction == Direction.Right)
            {
                tank.Go = false;
            }
            else if (e.Key == up && tank.Direction == Direction.Up)
            {
                tank.Go = false;
            }
            else if (e.Key == down && tank.Direction == Direction.Down)
            {
                tank.Go = false;
            }
        }
    }
}

