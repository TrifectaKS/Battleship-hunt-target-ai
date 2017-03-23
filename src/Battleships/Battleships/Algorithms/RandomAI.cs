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
    class RandomAI
    {
        private Random Rand { get; set; }
        private int[,] Grid { get; set; }
        private List<int> ShotsAvailable { get; set; }
        private List<int> ShotHistory { get; set; }
        private Board Board { get; set; }
        private int ShipsDestroyed { get; set; }
        private Statistics Stats { get; set; }
        
        public RandomAI(Board board)
        {
            Board = board;
            ShipsDestroyed = 0;
            Grid = new int[Board.Size, Board.Size];
            ShotHistory = new List<int>();
            ShotsAvailable = new List<int>();
            Rand = new Random();
            Stats = new Statistics();
            init();
        }

        public Statistics Play()
        {
            while(ShipsDestroyed != Ship.NUM_OF_SHIPS)
            {
                //Display.Grid(Board);
                //Console.WriteLine("SHOOT");
                Shoot();
            }

            return Stats;
        }

        private void init()
        {
            int cells = Board.Size * Board.Size;
            int count = 0;

            for(int y = 0; y < Board.Size; y++)
            {
                for(int x = 0; x < Board.Size; x++)
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
            ShotHistory.Add(c.Val);
            switch (result.ShotType)
            {
                case ShotType.Missed: Stats.TotalMisses++; break;
                case ShotType.Hit: Stats.TotalHits++; break;
                case ShotType.Destroyed: Stats.TotalHits++; ShipsDestroyed++; break;
                default: Stats.TotalMisses++; break;
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
            int index = GenerateRandom(0, ShotsAvailable.Count);
            int num = ShotsAvailable.ElementAt(index);
            ShotsAvailable.RemoveAt(index);
            return num;
        }

        private int GenerateRandom(int min, int max)
        {
            return Rand.Next(min, max);
        }
    }
}
