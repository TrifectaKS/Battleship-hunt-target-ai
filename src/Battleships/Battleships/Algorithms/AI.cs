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
        internal List<Shot> Shots { get; set; }
        internal int ShotNumber { get; set; }
        internal Guid GameGuid { get; set; }

        internal const int CountStart = 0;

        public AI(Board board, Guid guid)
        {
            Board = board;
            GameGuid = guid;
            ShipsDestroyed = 0;
            ShotNumber = 0;
            Grid = new int[Board.Size, Board.Size];
            ShotsAvailable = new List<int>();
            Rand = new Random();
            Shots = new List<Shot>();
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

        internal Coordinates GetCoordinates(int val)
        {
            if(val == 0)
                return new Coordinates { X = 0, Y = 0, Val = val };

            return new Coordinates { X = (val) % Board.Size, Y = (val) / Board.Size, Val = val };
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
