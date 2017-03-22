using Battleships.Enums;
using Battleships.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Algorithms
{
    class RandomAI
    {
        public int Size { get; set; }
        private Random Rand { get; set; }
        public int[,] Grid { get; set; }
        public List<int> ShotHistory { get; set; }
        public Board Board { get; set; }
        public int ShipsDestroyed { get; set; }
        
        public RandomAI(Board board, int size)
        {
            Board = board;
            Size = size;
            ShipsDestroyed = 0;
            Grid = new int[Size, Size];
            ShotHistory = new List<int>();
            Rand = new Random();

            init();
        }

        private void init()
        {
            int cells = Size * Size;
            int count = 0;

            for(int y = 0; y < Size; y++)
            {
                for(int x = 0; x < Size; x++)
                {
                    Grid[x, y] = count;
                    count++;
                }
            }
        }

        private void Shoot()
        {
            Coordinates c = GetCoordinates();
            ShotResult result = Board.Grid[c.X, c.Y].Shoot();
            ShotHistory.Add(c.Val);

            if (result.ShotType == ShotType.Destroyed)
            {
                ShipsDestroyed++;
                if(ShipsDestroyed == Ship.NUM_OF_SHIPS)
                {

                }
            }
        }

        private Coordinates GetCoordinates()
        {
            int num = GetCellNumber();
            char[] coords = (num + "").ToCharArray();


            if (coords.Length == 2)
                return new Coordinates { X = Int32.Parse(coords[1] + ""), Y = Int32.Parse(coords[0] + ""), Val = num };
            else
                return new Coordinates { X = num, Y = 0, Val = num };
        }

        private int GetCellNumber()
        {
            bool flag = false;
            int cellNum = -1;

            do
            {
                cellNum = GenerateRandom();
                flag = false;

                foreach (int shot in ShotHistory)
                {
                    if (shot == cellNum)
                    {
                        flag = true;
                        break;
                    }
                }
            } while (flag == true);

            return cellNum;
        }

        private int GenerateRandom()
        {
            return Rand.Next(0, Size);
        }
    }
}
