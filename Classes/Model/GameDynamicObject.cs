using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BattleCity.Classes.Model
{
    /// <summary>
    /// Направление. 
    /// </summary>
    public enum Direction { Up, Right, Down, Left }

    /// <summary>
    /// Динамический элемент игры
    /// </summary>
    internal class GameDynamicObject : GameObject, ICollidable
    {
        private int hp;
        private Direction direction;
        private double speed;

        /// <summary>
        /// Количество очков здоровья.
        /// </summary>
        public int HP { get { return hp; } set { hp = value; } }
        /// <summary>
        /// Направление в которое "смотрит" объект.
        /// </summary>
        public Direction Direction { get { return direction; } set { direction = value; } }
        /// <summary>
        /// Скорость объекта.
        /// </summary>
        public double Speed { get { return speed; } set { speed = value; } }

        public bool isCollide(Wall wall)
        {
            if (Math.Max(PosX - Size / 2, wall.PosX - wall.Size / 2) <= Math.Min(PosX + Size / 2, wall.PosX + wall.Size / 2)
            && Math.Max(PosY - Size / 2, wall.PosY - wall.Size / 2) <= Math.Min(PosY + Size / 2, wall.PosY + wall.Size / 2)) { return true; }
            return false;
        }

        public bool isCollide(Bullet bullet)
        {
            if (Math.Max(PosX - Size / 2, bullet.PosX - bullet.Size / 2) <= Math.Min(PosX + Size / 2, bullet.PosX + bullet.Size / 2)
                && Math.Max(PosY - Size / 2, bullet.PosY - bullet.Size / 2) <= Math.Min(PosY + Size / 2, bullet.PosY + bullet.Size / 2)) { return true; }
            return false;
        }

        public bool isCollide(Tank tank)
        {
            if (Math.Max(PosX - Size / 2, tank.PosX - tank.Size / 2) <= Math.Min(PosX + Size / 2, tank.PosX + tank.Size / 2)
                && Math.Max(PosY - Size / 2, tank.PosY - tank.Size / 2) <= Math.Min(PosY + Size / 2, tank.PosY + tank.Size / 2)) { return true; }
            return false;
        }



    }
}
