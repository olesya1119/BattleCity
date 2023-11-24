using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCity.Classes
{
    /// <summary>
    /// Проверка на столкновения между разными объектами.
    /// </summary>
    interface ICollidable
    {
        /// <summary>
        /// Проверка на столкновение объекта со стеной.
        /// </summary>
        bool isCollide(Wall wall);

        /// <summary>
        /// Проверка на столкновение объекта с пулей.
        /// </summary>
        bool isCollide(Bullet bullet);

        /// <summary>
        /// Проверка на столкновение объекта с танком.
        /// </summary>
        bool isCollide(Tank tank);

    }
}
