using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCity.Classes
{
    internal class Bullet
    {
        private bool goLeft, goRight, goUp, goDown; // Показывают, находится ли пуля в движении. Если да, то куда она едет
        private double posX, posY, size; //Текущая позиция пули (её центр), его размеры - по X и по Y
        private double speed; //Скорость в ед/сек
        private int hp; //Количество единиц здоровья
    }
}
