using BattleCity.Classes.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BattleCity.Classes
{
    /// <summary>
    /// Логика танка.
    /// </summary>
    class Tank: GameDynamicObject
    {
        private bool go;

        /// <summary>
        /// Показывают, находится ли танк в движении.
        /// </summary>
        public bool Go { get { return go; } set { go = value; } }



        public Tank() {}

        public Tank(double posX, double posY, double size, double speed, int hp)
        {
            Go = false;
            Direction = Direction.Up;
            PosX = posX;
            PosY = posY;
            Size = size;
            Speed = speed;
            HP = hp;
        }

        /// <summary>
        /// Совершить выстрел. Если танк не имеет "живой" пули, то она создается
        /// </summary>
        /// <returns></returns>
        public Bullet Shoot() 
        {
            double PosBulletX, PosBulletY, bulletSize = 0.2 * Size;
            switch (Direction)
            {
                case Direction.Left:
                     PosBulletX = PosX - Size / 2 - bulletSize / 2;
                     PosBulletY = PosY; break;
                case Direction.Right:
                     PosBulletX = PosX + Size / 2 + bulletSize / 2;
                     PosBulletY = PosY; break;
                case Direction.Down:
                     PosBulletY = PosY - Size / 2 - bulletSize / 2;
                     PosBulletX = PosX; break;
                case Direction.Up:
                     PosBulletY = PosY + Size / 2 + bulletSize / 2;
                     PosBulletX = PosX; break;
                default:
                     PosBulletX = PosX; PosBulletY = PosY; break;
                }
            return new Bullet(PosBulletX, PosBulletY, bulletSize, Speed * 2, Direction);
            
        }
        public void CollideWithTank() //Столкновение с пулей
        {
            switch (Direction)
            {
                case Direction.Left: PosX += Speed; break;
                case Direction.Right: PosX -= Speed; break;
                case Direction.Up: PosY -= Speed; break;
                case Direction.Down: PosY += Speed; break;
            }
        }
        public void CollideWithBullet() //Столкновение с пулей
        {
            HP--;
        }

        /// <summary>
        /// Обновление позиций танка и пули
        /// </summary>
        public void Update()
        {
            Drive();
        }

        /// <summary>
        /// Совершает движение в завсимости от напрвления
        /// </summary>
        private void Drive() //Движение танка
        {
             
            if (go && Direction == Direction.Left)
            {
                if (PosX - Size / 2 - Speed <= 0)
                {
                    PosX = Size / 2;
                }
                else
                {
                    PosX -= Speed;
                }

            }
            else if (go && Direction == Direction.Right)
            {
                if (PosX + Size / 2 + Speed >= Map.X)
                {
                    PosX = Map.X - Size / 2;
                }
                else
                {
                    PosX += Speed;
                }

            }
            else if (go && Direction == Direction.Up)
            {
                if(PosY + Size / 2 + Speed >= Map.X)
                {
                    PosY = Map.X - Size / 2;
                }
                else
                {
                    PosY += Speed;
                }

            } 
            else if (go && Direction == Direction.Down)
            {
                if (PosY - Size / 2 - Speed <= 0)
                {
                    PosY = Size / 2;
                }
                else
                {
                    PosY -= Speed;
                }
            }

        }



    }
}
