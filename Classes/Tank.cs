using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BattleCity.Classes
{
    class Tank
    {
        private bool goLeft, goRight, goUp, goDown; // Показывают, находится ли танк в движении. Если да, то куда он едет
        private double posX, posY, sizeX, sizeY; //Текущая позиция танка (его центра), его размеры - по X и по Y
        private double speed; //Скорость в ед/сек


        public void Shoot() //Стрелять
        {

        }

        public void Drive(int ms) //Движение танка
        {
            double dist = ms * speed/1000; //Пройденая дистанция
            if (goLeft)
            {
                if (posX + sizeX / 2 - dist <= 0)
                {
                    posX = sizeX / 2;
                }
                else
                {
                    posX -= dist;
                }

            }
            else if (goRight)
            {
                if (posX + sizeX / 2 + dist >= Map.X)
                {
                    posX = Map.X - sizeX / 2;
                }
                else
                {
                    posX += dist;
                }

            }
            else if (goUp)
            {
                if(posY + sizeY / 2 + dist >= Map.X)
                {
                    posY = Map.X - sizeY / 2;
                }
                else
                {
                    posY += dist;
                }

            } 
            else if (goDown)
            {
                if (posY + sizeY / 2 + dist <= 0)
                {
                    posY = sizeY / 2;
                }
                else
                {
                    posY -= dist;
                }
            }

        }



    }
}
