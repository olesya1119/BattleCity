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
        private int frame, numberPlayer;
        private Key shoot;
        private ImageBrush[] frames;
        private Canvas canvas;

        public Tank Tank { get; }
        public Rectangle Rectangle { get; }
        public Canvas Canvas { get { return canvas; } }
        /// <summary>
        /// Нажата клавиша влево.
        /// </summary>
        public Key Left { get; }
        /// <summary>
        /// Нажата клавиша вправо.
        /// </summary>
        public Key Right { get; }
        /// <summary>
        /// Нажата клавиша вверх.
        /// </summary>
        public Key Up { get; }
        /// <summary>
        /// Нажата клавиша вниз.
        /// </summary>
        public Key Down { get; }
        public ViewBullet ViewBullet { get; private set; }


        public ViewPlayerTank(Tank tank, Key left, Key right, Key up, Key down, Key shoot, int numberPlayer, ref Canvas canvas)
        {
            this.Left = left;
            this.Right = right;
            this.Up = up;
            this.Down = down;
            this.shoot = shoot;
            this.Tank = tank;
            this.numberPlayer = numberPlayer;
            this.canvas = canvas;

            if (numberPlayer == 1)
            {
                frames = Media.getAnimationFramesWithRotate(AnimationFrames.DrivePlayerTank1);
            }
            else
            {
                frames = Media.getAnimationFramesWithRotate(AnimationFrames.DrivePlayerTank2);
            }

            frame = 0;
            Rectangle = new Rectangle();

            Rectangle.Height = tank.Size;
            Rectangle.Width = tank.Size;
            Rectangle.Fill = frames[0];
            Canvas.SetLeft(Rectangle, tank.PosX - tank.Size / 2);
            Canvas.SetBottom(Rectangle, tank.PosY - tank.Size / 2);

            canvas.Children.Add(Rectangle);
            ViewBullet = null;
        }



        public void UpdateTexture() {
            frame += 1;
            if (frame >= frames.Length / 4)
            {
                frame = 0;
            }
            Rectangle.Fill = frames[frame + (frames.Length / 4) * (int)Tank.Direction];
        }


        public void Update() { 
            Tank.Update();
            Canvas.SetLeft(Rectangle, Tank.PosX - Tank.Size / 2);
            Canvas.SetBottom(Rectangle, Tank.PosY - Tank.Size / 2);

            if (ViewBullet != null)
            {
                ViewBullet.Update();
                if (ViewBullet.Bullet.HP == 0)
                {
                    ViewBullet = null;
                }
            }
      
        }

       public void UpdateKeyboard()
        {
            if (Keyboard.IsKeyDown(Left))
            {
                Tank.Go = true;
                Tank.Direction = Direction.Left;
                UpdateTexture();
            }

            else if(Keyboard.IsKeyDown(Right))
            {
                Tank.Go = true;
                Tank.Direction = Direction.Right;
                UpdateTexture();
            }

            else if (Keyboard.IsKeyDown(Up))
            {
                Tank.Go = true;
                Tank.Direction = Direction.Up;
                UpdateTexture();
            }

            else if (Keyboard.IsKeyDown(Down))
            {
                Tank.Go = true;
                Tank.Direction = Direction.Down;
                UpdateTexture();
            }

            else {
                Tank.Go = false;
            }

        }
        
        public void Shoot(KeyEventArgs e)
        {
            if (ViewBullet == null && e.Key == shoot)
            {
                ViewBullet = new ViewBullet(Tank.Shoot(), ref canvas);
            }
        }
    }
}

