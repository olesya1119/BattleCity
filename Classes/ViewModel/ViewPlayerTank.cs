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


using BattleCity.Classes.Model;
using System.Data;

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
        private ViewBullet viewBullet;

        public Tank Tank { get { return tank; } }
        public Rectangle Rectangle { get { return rectangle; } }
        public Canvas Canvas { get { return canvas; } }

        public Key Left { get { return left; } }
        public Key Right { get { return right; } }  
        public Key Up { get { return up; } }
        public Key Down { get { return down; } }
        public ViewBullet ViewBullet { get { return viewBullet; } }


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
            viewBullet = null;
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
            tank.Update();
            Canvas.SetLeft(rectangle, tank.PosX - tank.Size / 2);
            Canvas.SetBottom(rectangle, tank.PosY - tank.Size / 2);

            if (viewBullet != null)
            {
                viewBullet.Update();
                if (viewBullet.Bullet.HP == 0)
                {
                    viewBullet = null;
                }
            }
      
        }

       public void UpdateKeyboard()
        {
            if (Keyboard.IsKeyDown(left))
            {
                tank.Go = true;
                tank.Direction = Direction.Left;
                UpdateTexture();
            }

            else if(Keyboard.IsKeyDown(right))
            {
                tank.Go = true;
                tank.Direction = Direction.Right;
                UpdateTexture();
            }

            else if (Keyboard.IsKeyDown(up))
            {
                tank.Go = true;
                tank.Direction = Direction.Up;
                UpdateTexture();
            }

            else if (Keyboard.IsKeyDown(down))
            {
                tank.Go = true;
                tank.Direction = Direction.Down;
                UpdateTexture();
            }

            else {
                tank.Go = false;
            }

        }
        
        public void Shoot(KeyEventArgs e)
        {
            if (viewBullet == null && e.Key == shoot)
            {
                viewBullet = new ViewBullet(tank.Shoot(), ref canvas);
            }
        }
    }
}

