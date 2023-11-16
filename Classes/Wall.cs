using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace BattleCity.Classes
{
    enum TypeWall {Brick, Steel, Water}
    internal class Wall
    {
        private TypeWall wall;
        private double posX, posY, size;
        private bool destructibility = false;
        public double PosX { get { return posX; } }
        public double PosY { get { return posY; } }
        public double Size { get { return size; } }
        public bool Destructibility { get {  return destructibility; } }
    }

}
