using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BattleCity.Classes
{
    enum Direction { Up, Right, Down, Left }
    class Tank: ICollidable
    {
        private bool go; // Показывают, находится ли танк в движении.
        private double posX, posY, size; //Текущая позиция танка (его центра), его размеры - по X и по Y
        private double speed; //Скорость 
        private int hp; //Количество единиц здоровья, направление движения
        private Direction direction;

        public bool Go { get { return go; } set { go = value; } }
        public double PosX { get { return posX; } }
        public double PosY { get { return posY; } }
        public double Size { get { return size; } }
        public double Speed { get { return speed; } }
        public int Hp { get { return hp; } }
        public Direction Direction { get { return direction; } set { direction = value; } }

        public Tank()
        {

        }
        public Tank(double posX, double posY, double size, double speed, int hp)
        {
            go = false;
            direction = Direction.Up;
            this.posX = posX;
            this.posY = posY;
            this.size = size;
            this.speed = speed;
            this.hp = hp;
        }

        public bool isCollide(Wall wall)
        {
            if (Math.Max(posX - size / 2, wall.PosX - wall.Size / 2) <= Math.Min(posX + size / 2, wall.PosX + wall.Size / 2)
                && Math.Max(posY - size / 2, wall.PosY - wall.Size / 2) <= Math.Min(posY + size / 2, wall.PosY + wall.Size / 2)) { return true; }
            return false;
        }

        public bool isCollide(Bullet bullet)
        {
            if (Math.Max(posX - size / 2, bullet.PosX - bullet.Size / 2) <= Math.Min(posX + size / 2, bullet.PosX + bullet.Size / 2)
                && Math.Max(posY - size / 2, bullet.PosY - bullet.Size / 2) <= Math.Min(posY + size / 2, bullet.PosY + bullet.Size / 2)) { return true; }
            return false;
        }

        public bool isCollide(Tank tank)
        {
            if (Math.Max(posX - size / 2, tank.PosX - tank.Size / 2) <= Math.Min(posX + size / 2, tank.PosX + tank.Size / 2)
                && Math.Max(posY - size / 2, tank.PosY - tank.Size / 2) <= Math.Min(posY + size / 2, tank.PosY + tank.Size / 2)) { return true; }
            return false;
        }
        public Bullet Shoot() //Стрелять
        {
            double posBulletX, posBulletY, bulletSize = 0.2 * size;
            switch (direction)
            {
                case Direction.Left:
                    posBulletX = posX - size/2 - bulletSize/2;
                    posBulletY = posY; break;
                case Direction.Right:
                    posBulletX = posX + size / 2 + bulletSize / 2;
                    posBulletY = posY; break;
                case Direction.Down:
                    posBulletY = posY - size / 2 - bulletSize / 2;
                    posBulletX = posX; break;
                case Direction.Up:
                    posBulletY = posY + size / 2 + bulletSize / 2;
                    posBulletX = posX; break;
                default:
                    posBulletX = posX; posBulletY = posY; break;
            }
            Bullet bullet = new Bullet(posBulletX, posBulletY, bulletSize, speed*2, direction);
            return bullet;
        }

        public void CollideWithBullet() //Столкновение с пулей
        {
            hp--;
            if (hp < 0)
            {
                
            }

        }



        public void Drive() //Движение танка
        {
             
            if (go && direction == Direction.Left)
            {
                if (posX - size / 2 - speed <= 0)
                {
                    posX = size / 2;
                }
                else
                {
                    posX -= speed;
                }

            }
            else if (go && direction == Direction.Right)
            {
                if (posX + size / 2 + speed >= Map.X)
                {
                    posX = Map.X - size / 2;
                }
                else
                {
                    posX += speed;
                }

            }
            else if (go && direction == Direction.Up)
            {
                if(posY + size / 2 + speed >= Map.X)
                {
                    posY = Map.X - size / 2;
                }
                else
                {
                    posY += speed;
                }

            } 
            else if (go && direction == Direction.Down)
            {
                if (posY - size / 2 - speed <= 0)
                {
                    posY = size / 2;
                }
                else
                {
                    posY -= speed;
                }
            }

        }



    }
}
