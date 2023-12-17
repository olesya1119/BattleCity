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
        private double speed;

        /// <summary>
        /// Количество очков здоровья.
        /// </summary>
        public int HP { get; set; }
        /// <summary>
        /// Направление в которое "смотрит" объект.
        /// </summary>
        public Direction Direction { get; set; }
        /// <summary>
        /// Скорость объекта.
        /// </summary>
        public double Speed { get { return speed; } set { speed = value > 0 ? value : 1; } }
        
        public bool isCollide(GameObject gameObject)
        {
            
            if (Math.Max(PosX - Size / 2, gameObject.PosX - gameObject.Size / 2) <= Math.Min(PosX + Size / 2, gameObject.PosX + gameObject.Size / 2)
            && Math.Max(PosY - Size / 2, gameObject.PosY - gameObject.Size / 2) <= Math.Min(PosY + Size / 2, gameObject.PosY + gameObject.Size / 2)) { return true; }
            return false;
        }
    }
}
