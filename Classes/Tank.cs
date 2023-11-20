using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BattleCity.Classes
{
    class Tank: ICollidable
    {
        private bool goLeft, goRight, goUp, goDown; // Показывают, находится ли танк в движении. Если да, то куда он едет
        private double posX, posY, size; //Текущая позиция танка (его центра), его размеры - по X и по Y
        private double speed; //Скорость 
        private int hp; //Количество единиц здоровья

        public bool GoLeft { get { return goLeft; } set { goLeft = value; } }
        public bool GoRight { get { return goRight; } set { goRight = value; } }
        public bool GoUp { get { return goUp; } set { goUp = value; } }
        public bool GoDown { get { return goDown; } set { goDown = value; } }
        public double PosX { get { return posX; } }
        public double PosY { get { return posY; } }
        public double Size { get { return size; } }
        public double Speed { get { return speed; } }
        public int Hp { get { return hp; } }

        public Tank()
        {

        }
        public Tank(double posX, double posY, double size, double speed, int hp)
        {
            goDown = goLeft = goRight = goUp = false;
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
        public void Shoot() //Стрелять
        {

        }

        public void CollideWithBullet() //Столкновение с пулей
        {
            hp--;
            if (hp < 0)
            {
                Media.Boom();
            }

        }



        public void Drive() //Движение танка
        {
             
            if (goLeft)
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
            else if (goRight)
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
            else if (goUp)
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
            else if (goDown)
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
