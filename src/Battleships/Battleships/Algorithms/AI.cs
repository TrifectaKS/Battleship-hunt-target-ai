using Battleships.Enums;
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
        
        internal Coordinates GetAdjecentTarget(Coordinates c, DirectionTaken d)
        {
            switch (d)
            {
                case DirectionTaken.Up: if (IsInBounds(c.X, c.Y - 1)) return new Coordinates { X = c.X, Y = c.Y - 1, Val = GetVal(c.X, c.Y - 1) }; break;
                case DirectionTaken.Down: if (IsInBounds(c.X, c.Y + 1)) return new Coordinates { X = c.X, Y = c.Y + 1, Val = GetVal(c.X, c.Y + 1) }; break;
                case DirectionTaken.Left: if (IsInBounds(c.X - 1, c.Y)) return new Coordinates { X = c.X - 1, Y = c.Y, Val = GetVal(c.X - 1, c.Y) }; break;
                case DirectionTaken.Right: if (IsInBounds(c.X + 1, c.Y)) return new Coordinates { X = c.X + 1, Y = c.Y, Val = GetVal(c.X + 1, c.Y) }; break;
            }
            
            return null;
        }

        internal List<Coordinates> GetAdjecentTarget(Coordinates c, Orientation o)
        {
            List<Coordinates> tempCoords = new List<Coordinates>();
            Coordinates t;
            if (o == Orientation.Random)
            {
                t = GetAdjecentTarget(c, DirectionTaken.Up);
                if (t != null && !Board.Grid[c.X, c.Y - 1].IsShot) tempCoords.Add(t);
                t = GetAdjecentTarget(c, DirectionTaken.Down);
                if (t != null && !Board.Grid[c.X, c.Y + 1].IsShot) tempCoords.Add(t);
                t = GetAdjecentTarget(c, DirectionTaken.Left);
                if (t != null && !Board.Grid[c.X - 1, c.Y].IsShot) tempCoords.Add(t);
                t = GetAdjecentTarget(c, DirectionTaken.Right);
                if (t != null && !Board.Grid[c.X + 1, c.Y].IsShot) tempCoords.Add(t);

            }
            else if (o == Orientation.Vertical)
            {
                t = GetAdjecentTarget(c, DirectionTaken.Up);
                if (t != null && !Board.Grid[c.X, c.Y-1].IsShot) tempCoords.Add(t);
                t = GetAdjecentTarget(c, DirectionTaken.Down);
                if (t != null && !Board.Grid[c.X, c.Y+1].IsShot) tempCoords.Add(t);
            }
            else if (o == Orientation.Horizontal)
            {
                t = GetAdjecentTarget(c, DirectionTaken.Left);
                if (t != null && !Board.Grid[c.X-1, c.Y].IsShot) tempCoords.Add(t);
                t = GetAdjecentTarget(c, DirectionTaken.Right);
                if (t != null && !Board.Grid[c.X+1, c.Y].IsShot) tempCoords.Add(t);
            }
            return tempCoords;
        }

        internal int GetVal(int x, int y)
        {
            if (!IsInBounds(x,y))
                return -1;

            return (Board.Size * y) + x;
        }

        internal bool IsInBounds(int x, int y)
        {
            if (y < 0 || y >= Board.Size || x < 0 || x >= Board.Size)
                return false;

            return true;
        }


        internal Orientation FindOrientation(Coordinates c1, Coordinates c2)
        {
            if (c1.X == c2.X) return Orientation.Horizontal;
            else if (c1.Y == c2.Y) return Orientation.Vertical;
            else return Orientation.Random;
        }

        internal Coordinates GetCoordinates(int val)
        {
            if(val == 0)
                return new Coordinates { X = 0, Y = 0, Val = val };
            else if(val >= Math.Pow(Board.Size, 2) || val < 0)
                return null;
            
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
