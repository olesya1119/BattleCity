using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCity.Classes.Model
{
    /// <summary>
    /// Базовый элемент игры
    /// </summary>
    internal class GameObject
    {
        private double posX, posY, size;
        /// <summary>
        /// Позиция центра объекта по координате X.
        /// </summary>
        public double PosX {  get { return posX; } set {  posX = value; } }
        /// <summary>
        /// Позиция центра объекта по координате Y.
        /// </summary>
        public double PosY { get {  return posY; } set {  posY = value; } }
        /// <summary>
        /// Ширина и длина объекта.
        /// </summary>
        public double Size { get { return size; } set { size = value; } }




    }
}
