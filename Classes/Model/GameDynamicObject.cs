using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Shapes;

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
        
        public bool isCollide(GameObject gameObject)
        {
            
            if (Math.Max(PosX - Size / 2, gameObject.PosX - gameObject.Size / 2) <= Math.Min(PosX + Size / 2, gameObject.PosX + gameObject.Size / 2)
            && Math.Max(PosY - Size / 2, gameObject.PosY - gameObject.Size / 2) <= Math.Min(PosY + Size / 2, gameObject.PosY + gameObject.Size / 2)) { return true; }
            return false;
        }
    }
}
