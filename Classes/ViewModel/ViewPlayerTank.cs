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


        public async void UpdateAsync() { 
            tank.Update();
            Canvas.SetLeft(rectangle, tank.PosX - tank.Size / 2);
            Canvas.SetBottom(rectangle, tank.PosY - tank.Size / 2);


            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].Update();
                if (bullets[i].Bullet.HP == 0)
                {
                    
                    //Media media = new Media(bullets[i].Bullet.PosX + 10, bullets[i].Bullet.PosY - 10, 60, ref canvas);
                    //await media.Boom();

                    bullets.RemoveAt(i);
                    
                    i--;
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
        
        /*
        public void KeyDown(KeyEventArgs e)
        {
            if (e.Key == left)
            {
                
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
            }


            if (e.Key == shoot)
            {
                Shoot(); 
            }

           
        }*/

        /*
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
        }*/

        public bool Shoot(KeyEventArgs e, int lastShotTime)
        {
            if (e.Key == shoot && lastShotTime>1000)
            {
                bullets.Add(new ViewBullet(tank.Shoot(), ref canvas));
                return true;
            }

            return false;
        }
    }
}

