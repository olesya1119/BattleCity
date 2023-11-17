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
        private TypeWall typeWall;
        private double posX, posY, size;
        private bool destructibility = false;

        public TypeWall TypeWall { get { return typeWall; } set { typeWall = value; } }
        public double PosX { get { return posX; } set { posX = value; } }
        public double PosY { get { return posY; } set { posY = value; } }
        public double Size { get { return size; } set { size = value; } }
        public bool Destructibility { get {  return destructibility; } set { destructibility = value; } }

        public Wall(TypeWall typeWall, double posX, double posY, double size, bool destructibility)
        {
            this.typeWall = typeWall;
            this.posX = posX;
            this.posY = posY;
            this.size = size;
            this.destructibility = destructibility;
        }

        public Wall()
        {
            typeWall = 0;
            posX = 0;
            posY = 0;
            size = 1;
            destructibility = false;
        }
    }

}
