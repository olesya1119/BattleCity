using BattleCity.Classes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCity.Classes
{
    internal class Bullet : GameDynamicObject
    {
        

        public Bullet(double posX, double posY, double size, double speed, Direction direction)
        {
            HP = 1;
            PosX = posX;
            PosY = posY;
            Size = size;
            Speed = speed;
            Direction = direction;
        }

        /// <summary>
        /// Летит пока "жива" и не достигла стены
        /// </summary>
        public void Fly()
        {
            if (HP>0 && Direction == Direction.Left)
            {
                if (PosX - Size / 2 - Speed <= 0)
                {
                    HP = 0;
                }
                else
                {
                    PosX -= Speed;
                }
            }

            else if (HP > 0 && Direction == Direction.Right)
            {
                if (PosX + Size / 2 + Speed >= Map.X)
                {
                    HP = 0;
                }
                else
                {
                    PosX += Speed;
                }
            }

            else if (HP > 0 && Direction == Direction.Up)
            {
                if (PosY + Size / 2 + Speed >= Map.X)
                {
                    HP = 0;
                }
                else
                {
                    PosY += Speed;
                }

            }
            else if (HP > 0 && Direction == Direction.Down)
            {
                if (PosY - Size / 2 - Speed <= 0)
                {
                    HP = 0;
                }
                else
                {
                    PosY -= Speed;
                }
            }


        }

    }
}
