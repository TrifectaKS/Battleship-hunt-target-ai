using Battleships.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Objects
{
    class Cell
    {
        public Cell(Ship s)
        {
            if(s!=null)
                Ship = s;

            IsShot = false;
            IsHit = false;
        }
        public Ship Ship { get; set; }
        public bool IsShot { get; set; }
        public bool IsHit { get; set; }
        public ShotResult Shoot()
        {
            if(Ship == null)
            {
                IsShot = true;
                IsHit = false;
                return new ShotResult { ShotType = ShotType.Missed };
            }
            else if (!Ship.IsDestroyed)
            {
                IsShot = true;
                IsHit = true;
                Ship.PartsShot++;
                if (Ship.PartsShot == Ship.Length)
                {
                    Ship.IsDestroyed = true;
                    return new ShotResult { ShotType = ShotType.Destroyed, ShipType = Ship.Type };
                }
                return new ShotResult { ShotType = ShotType.Hit };
            }

            return new ShotResult { ShotType = ShotType.Missed };
        }
    }
}