using Battleships.Enums;
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
        private List<Coordinates> TargetCoords { get; set; }
        private Orientation TargetOrientation { get; set; }
        private List<Coordinates> PossibleTargets { get; set; }
        private bool OrientationFound { get; set; }
        public HuntTargetAI(Board board, Guid guid):base(board,guid)
        {
            init();
            TargetCoords = new List<Coordinates>();
            PossibleTargets = new List<Coordinates>();
            OrientationFound = false;
        }

        public List<Shot> Play()
        {
            bool isHunting = true;
            OrientationFound = false;
            Shot result;

            while (ShipsDestroyed != Ship.NUM_OF_SHIPS)
            {
                if (isHunting)
                {
                    result = Hunt();
                    if(result.ShotTypeId == (int)ShotType.Hit)
                    {
                        TargetCoords.Add(new Coordinates { X = result.X, Y = result.Y, Val = result.InitialVal.GetValueOrDefault() });
                        isHunting = false;
                    }
                }else
                {
                    result = Target();
                    if(result.ShotTypeId == (int)ShotType.Hit)
                    {
                        TargetCoords.Add(new Coordinates { X = result.X, Y = result.Y, Val = result.InitialVal.GetValueOrDefault() });
                    }
                    else if (result.ShotTypeId == (int)ShotType.Destroyed)
                    {
                        isHunting = true;
                        ShipsDestroyed++;
                        OrientationFound = false;
                        PossibleTargets = new List<Coordinates>();
                    }
                }

                Shots.Add(result);
                ShotNumber++;
            }

            return Shots;
        }

        private Shot Hunt()
        {
            Coordinates c = GetCoordinates(GetCellNumber());
            Shot result = Board.Grid[c.X, c.Y].Shoot();

            result.ShotId = Guid.NewGuid();
            result.GameId = GameGuid;
            result.AIState = (int)State.Random;
            result.DirectionId = (int)DirectionTaken.Random;
            result.X = c.X;
            result.Y = c.Y;
            result.OrientationId = (int)Orientation.Random;
            result.ShotNumber = ShotNumber;
            result.AIState = (int)State.Hunt;

            if (result.ShotTypeId == (int)ShotType.Destroyed) ShipsDestroyed++;

            return result;
        }

        private Shot Target()
        {
            Shot result = null;

            if (!OrientationFound)
            {
                PossibleTargets = GetAdjecentTarget(TargetCoords[0], Orientation.Random);
                int randomIndex = GenerateRandom(0,PossibleTargets.Count);
                result = Board.Grid[PossibleTargets[randomIndex].X, PossibleTargets[randomIndex].Y].Shoot();
                if(result.ShotTypeId == (int)ShotType.Hit)
                {
                    OrientationFound = true;
                    TargetOrientation = FindOrientation(TargetCoords[0], PossibleTargets[randomIndex]);
                }

                result.ShotId = Guid.NewGuid();
                result.GameId = GameGuid;
                result.AIState = (int)State.Target;
                result.DirectionId = (int)DirectionTaken.Random;
                result.X = PossibleTargets[randomIndex].X;
                result.Y = PossibleTargets[randomIndex].Y;
                result.OrientationId = (int)TargetOrientation;
                result.ShotNumber = ShotNumber;

            }else
            {
                PossibleTargets = GetAdjecentTarget(TargetCoords[0], TargetOrientation);
                PossibleTargets.AddRange(GetAdjecentTarget(TargetCoords[TargetCoords.Count - 1], TargetOrientation));

            }
            return result;
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

       

        //PARITY HUNT TARGET INIT

        //private void init()
        //{
        //    if (GenerateRandom(1, 2) % 2 == 0) IsEven = true;
        //    else IsEven = false;

        //    int cells = (int)Math.Pow(Board.Size,2);
        //    int count = 0;

        //    for (int y = 0; y < Board.Size; y++)
        //    {
        //        for (int x = 0; x < Board.Size; x++)
        //        {
        //            Grid[x, y] = count;
        //            if(count%2==0 && IsEven)
        //            {
        //                ShotsAvailable.Add(count);
        //                count++;
        //            }else if(count%2==1 && !IsEven)
        //            {
        //                ShotsAvailable.Add(count);
        //                count++;
        //            }
        //        }
        //    }
        //}
    }
}
