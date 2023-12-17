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
        public TypeWall TypeWall { get; set; }
        public bool Destructibility { get; set; } = false;
        public bool BulletCanFly { get; set; } = false;
        public Wall()
        {
            TypeWall = 0;
            PosX = 0;
            PosY = 0;
            Size = 1;
            Destructibility = false;
            BulletCanFly = false;
        }
        public Wall(TypeWall typeWall, double posX, double posY, double size)
        {
            this.TypeWall = typeWall;
            PosX = posX;
            PosY = posY;
            Size = size;
            switch (typeWall)
            {
                case TypeWall.Steel: Destructibility = false; BulletCanFly = false; break; 
                case TypeWall.Brick: Destructibility = true; BulletCanFly = false; break; 
                case TypeWall.Water: Destructibility = false; BulletCanFly = true; break;
            }
        }
    }
}
