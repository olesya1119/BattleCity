using BattleCity.Classes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace BattleCity.Classes
{
    enum TypeWall {Steel, Brick, Water}
    internal class Wall : GameObject
    {
        private TypeWall typeWall;
        private bool destructibility = false;
        private bool bulletCanFly = false;
        public TypeWall TypeWall { get { return typeWall; } set { typeWall = value; } }
        public bool Destructibility { get {  return destructibility; } set { destructibility = value; } }
        public bool BulletCanFly { get { return bulletCanFly; } set { bulletCanFly = value; } }
        public Wall()
        {
            typeWall = 0;
            PosX = 0;
            PosY = 0;
            Size = 1;
            destructibility = false;
            bulletCanFly = false;
        }
        public Wall(TypeWall typeWall, double posX, double posY, double size)
        {
            this.typeWall = typeWall;
            PosX = posX;
            PosY = posY;
            Size = size;
            switch (typeWall)
            {
                case TypeWall.Steel: destructibility = false; bulletCanFly = false; break; 
                case TypeWall.Brick: destructibility = true; bulletCanFly = false; break; 
                case TypeWall.Water: destructibility = false; bulletCanFly = true; break;
            }
        }
    }
}
