using Battleships.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Algorithms
{
    class AI
    {
        private Random Rand { get; set; }
        internal int[,] Grid { get; set; }
        internal List<int> ShotsAvailable { get; set; }
        internal Board Board { get; set; }
        internal int ShipsDestroyed { get; set; }
        internal Statistics Stats { get; set; }
        internal int ShotNumber { get; set; }

        public AI(Board board)
        {
            Board = board;
            ShipsDestroyed = 0;
            ShotNumber = 0;
            Grid = new int[Board.Size, Board.Size];
            ShotsAvailable = new List<int>();
            Rand = new Random();
            Stats = new Statistics();
        }

        internal Coordinates GetCoordinates()
        { 
            int num = GetCellNumber();
            char[] coords = (num + "").ToCharArray();


            if (coords.Length == 2)
                return new Coordinates { X = Int32.Parse(coords[1] + ""), Y = Int32.Parse(coords[0] + ""), Val = num };
            else
                return new Coordinates { X = num, Y = 0, Val = num };
        }

        internal int GetCellNumber()
        {
            int index = GenerateRandom(0, ShotsAvailable.Count);
            int num = ShotsAvailable.ElementAt(index);
            ShotsAvailable.RemoveAt(index);
            return num;
        }

        internal int GenerateRandom(int min, int max)
        {
            return Rand.Next(min, max);
        }
    }
}
