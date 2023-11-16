using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BattleCity.Classes
{
    class Tank//: ICollidable
    {
        private bool goLeft, goRight, goUp, goDown; // Показывают, находится ли танк в движении. Если да, то куда он едет
        private double posX, posY, size; //Текущая позиция танка (его центра), его размеры - по X и по Y
        private double speed; //Скорость в ед/сек
        private int hp; //Количество единиц здоровья


        public void Shoot() //Стрелять
        {

        }

        public void CollideWithBullet() //Столкновение с пулей
        {
            hp--;
            if (hp < 0)
            {
                Animations.Boom();
            }

        }



        public void Drive(int ms) //Движение танка
        {
            double dist = ms * speed/1000; //Пройденая дистанция
            if (goLeft)
            {
                if (posX + size / 2 - dist <= 0)
                {
                    posX = size / 2;
                }
                else
                {
                    posX -= dist;
                }

            }
            else if (goRight)
            {
                if (posX + size / 2 + dist >= Map.X)
                {
                    posX = Map.X - size / 2;
                }
                else
                {
                    posX += dist;
                }

            }
            else if (goUp)
            {
                if(posY + size / 2 + dist >= Map.X)
                {
                    posY = Map.X - size / 2;
                }
                else
                {
                    posY += dist;
                }

            } 
            else if (goDown)
            {
                if (posY + size / 2 + dist <= 0)
                {
                    posY = size / 2;
                }
                else
                {
                    posY -= dist;
                }
            }

        }



    }
}
