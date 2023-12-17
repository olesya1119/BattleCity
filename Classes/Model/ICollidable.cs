using BattleCity.Classes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace BattleCity.Classes
{
    /// <summary>
    /// Проверка на столкновения между разными объектами.
    /// </summary>
    interface ICollidable
    {
        /// <summary>
        /// Проверка на столкновение объекта с другим объектом.
        /// </summary>
        bool isCollide(GameObject gameObject);
    }
}
