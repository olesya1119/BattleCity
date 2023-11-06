using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCity.Classes
{
    /// <summary>
    /// Проверка на столкновения между разными объектами
    /// </summary>
    interface ICollidable
    {
        /// <summary>
        /// Проверка на столкновение объекта со стеной
        /// </summary>
        void isCollide(Wall wall);

        /// <summary>
        /// Проверка на столкновение объекта с пулей
        /// </summary>
        void isCollide(Bullet bullet);

        /// <summary>
        /// Проверка на столкновение объекта с танком
        /// </summary>
        void isCollide(Tank tank);

    }
}
