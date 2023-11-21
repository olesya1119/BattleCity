using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCity.Classes
{
    internal class Bullet:ICollidable
    {
        private bool itExists; //Существует ли пуля
        private double posX, posY, size; //Текущая позиция пули (её центр), его размеры - по X и по Y
        private double speed; //Скорость в ед/сек
        private Direction direction;

        public Direction Direction {  get { return direction; } }
        public double PosX { get { return posX; } }
        public double PosY { get { return posY; } }
        public double Size { get { return size; } }
        public double Speed { get { return speed; } }
        public bool ItExists {  get { return itExists; } }

        public Bullet(double posX, double posY, double size, double speed, Direction direction)
        {
            this.itExists = true;
            this.posX = posX;
            this.posY = posY;
            this.size = size;
            this.speed = speed;
            this.direction = direction;
        }

        public void Fly()
        {
            if (ItExists && direction == Direction.Left)
            {
                if (posX - size / 2 - speed <= 0)
                {
                    itExists = false;
                }
                else
                {
                    posX -= speed;
                }

            }
            else if (ItExists && direction == Direction.Right)
            {
                if (posX + size / 2 + speed >= Map.X)
                {
                    itExists = false;
                }
                else
                {
                    posX += speed;
                }

            }
            else if (ItExists && direction == Direction.Up)
            {
                if (posY + size / 2 + speed >= Map.X)
                {
                    itExists = false;
                }
                else
                {
                    posY += speed;
                }

            }
            else if (ItExists && direction == Direction.Down)
            {
                if (posY - size / 2 - speed <= 0)
                {
                    itExists = false;
                }
                else
                {
                    posY -= speed;
                }
            }


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
    }
}
