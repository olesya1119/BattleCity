using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BattleCity.Classes
{
    internal class Level
    {
        int ID;
        private List<Wall> walls; //Массив из стен, расположенных на карте
        private int maxEnemyTanks, numberOfplayrs, numberOfenemy; //Максимально количество вражеских танков одновременно, количество игроков (1 или 2), количество врагов
        private double startPosx1, startPosy1, startPosx2, startPosy2;  //Стартовые позиции игрока1 и игрока2


        public Level(int ID) {
           
        }

        public void SaveLevel() { 
            
        }
        
    }
}
