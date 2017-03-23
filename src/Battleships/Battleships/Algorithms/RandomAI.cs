using Battleships.Enums;
using Battleships.Functions;
using Battleships.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Algorithms
{
    class RandomAI:AI
    {
        public RandomAI(Board board):base(board)
        {
            init();
        }

        public Statistics Play()
        {
            while (ShipsDestroyed != Ship.NUM_OF_SHIPS)
            {
                Shoot();
            }

            return Stats;
        }

        private void init()
        {
            int cells = Board.Size * Board.Size;
            int count = 0;

            for (int y = 0; y < Board.Size; y++)
            {
                for (int x = 0; x < Board.Size; x++)
                {
                    Grid[x, y] = count;
                    ShotsAvailable.Add(count);
                    count++;
                }
            }
        }

        private void Shoot()
        {
            Coordinates c = GetCoordinates();
            ShotResult result = Board.Grid[c.X, c.Y].Shoot();

            switch (result.ShotType)
            {
                case ShotType.Missed: Stats.TotalMisses++; break;
                case ShotType.Hit: Stats.TotalHits++; break;
                case ShotType.Destroyed: Stats.TotalHits++; ShipsDestroyed++; break;
                default: Stats.TotalMisses++; break;
            }
        }
    }
}
