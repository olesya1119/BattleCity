using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCity.Classes
{
    internal class Bullet:ICollidable
    {
        private bool goLeft, goRight, goUp, goDown; // Показывают, находится ли пуля в движении. Если да, то куда она едет
        private double posX, posY, size; //Текущая позиция пули (её центр), его размеры - по X и по Y
        private double speed; //Скорость в ед/сек
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
