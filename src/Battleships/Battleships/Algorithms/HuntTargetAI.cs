using Battleships.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Algorithms
{
    class HuntTargetAI : AI
    {
        private Random Rand { get; set; }
        private List<int> ShotHistory { get; set; }
        private bool IsEven { get; set; }

        public HuntTargetAI(Board board, Guid guid):base(board,guid)
        {
            init();
        }

        public Shot Hunt()
        {
            return null;
        }

        public Shot Target()
        {
            return null;
        }
        
        private void init()
        {
            if (GenerateRandom(1, 2) % 2 == 0) IsEven = true;
            else IsEven = false;

            int cells = (int)Math.Pow(Board.Size,2);
            int count = 0;

            for (int y = 0; y < Board.Size; y++)
            {
                for (int x = 0; x < Board.Size; x++)
                {
                    Grid[x, y] = count;
                    if(count%2==0 && IsEven)
                    {
                        ShotsAvailable.Add(count);
                        count++;
                    }else if(count%2==1 && !IsEven)
                    {
                        ShotsAvailable.Add(count);
                        count++;
                    }
                }
            }
        }
    }
}
