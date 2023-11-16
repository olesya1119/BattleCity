using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCity.Classes
{
    enum TypeWall {Brick, Steel, Water}
    internal class Wall
    {
        private TypeWall wall;
        private int posX, posY;
        private bool destructibility = false;
    }

}
