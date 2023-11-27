using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;


namespace BattleCity.Classes
{
    internal class Level
    {
        int id;
        private List<Wall> walls; //Массив из стен, расположенных на карте
        private double startPosx1, startPosy1, startPosx2, startPosy2;  //Стартовые позиции игрока1 и игрока2

        public int ID { get { return id; } set { id = value; } }
        public List<Wall> Walls { get { return walls; } set { walls = value; } }
        public double StartPosx1 { get { return startPosx1; } set { startPosx1 = value; } }
        public double StartPosy1 { get { return startPosy1; } set { startPosy1 = value; } }
        public double StartPosx2 { get { return startPosx2; } set { startPosx2 = value; } }
        public double StartPosy2 { get { return startPosy2; } set { startPosy2 = value; } }


        public Level(int id) {
            string fileName = "../../Levels/Level" + id.ToString() + ".json";
            string jsonString = File.ReadAllText(fileName); ;
            Level level = JsonSerializer.Deserialize<Level>(jsonString);
            this.id = level.id;
            walls = level.walls;
            startPosx1 = level.startPosx1;
            startPosy1 = level.startPosy1;
            startPosx2 = level.startPosx2;
            startPosy2 = level.startPosy2;
        }

        public void SaveLevel() { 
            string fileName = "../../Levels/Level" + id.ToString() + ".json";
            string jsonString = JsonSerializer.Serialize(this);
            File.WriteAllText(fileName, jsonString);
        }

        public Level(int id, List<Wall> walls, double startPosx1, double startPosy1, double startPosx2, double startPosy2)
        {
            this.id = id;
            this.walls = walls;
            this.startPosx1 = startPosx1;
            this.startPosy1 = startPosy1;
            this.startPosx2 = startPosx2;
            this.startPosy2 = startPosy2;
        }

        public Level()
        {
            id = 0;
            walls = null;
            startPosx1 = 0;
            startPosy1 = 0;
            startPosx2 = 0;
            startPosy2 = 0;
        }
    }
}
