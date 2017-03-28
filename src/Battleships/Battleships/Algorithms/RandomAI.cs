﻿using Battleships.Enums;
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
        public RandomAI(Board board, Guid guid):base(board, guid)
        {
            init();
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

        public List<Shot> Play()
        {
            while (ShipsDestroyed != Ship.NUM_OF_SHIPS)
            {
                ShotNumber++;
                Shoot();
            }

            return Shots;
        }

        private void Shoot()
        {
            Coordinates c = GetCoordinates(GetCellNumber());
            //Console.WriteLine("Shot num " + ShotNumber + " x " + c.X + " y " + c.Y);
            Shot result = Board.Grid[c.X, c.Y].Shoot();
             
            result.ShotId = Guid.NewGuid();
            result.GameId = GameGuid;
            result.AIState = (int)State.Random;
            result.DirectionId = (int)DirectionTaken.Random;
            result.X= c.X;
            result.Y = c.Y;
            result.OrientationId = (int)Orientation.Random;
            result.ShotNumber = ShotNumber;
            result.AIState = (int)State.Random;

            Shots.Add(result);

            if (result.ShotTypeId == (int)ShotType.Destroyed) ShipsDestroyed++;
        }
    }
}
