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
        public Shot Shoot()
        {
            if (Ship == null)
            {
                IsShot = true;
                IsHit = false;
                return new Shot { ShotTypeId = (int)ShotType.Missed , ShipTypeId = Ship.SEA};
            }
            if (!Ship.IsDestroyed)
            {
                IsShot = true;
                IsHit = true;
                Ship.PartsShot++;
                if (Ship.PartsShot == Ship.Length)
                {
                    Ship.IsDestroyed = true;
                    return new Shot { ShotTypeId = (int)ShotType.Destroyed, ShipTypeId = Ship.Type };
                }
                return new Shot { ShotTypeId = (int)ShotType.Hit, ShipTypeId = Ship.Type };
            }

            return new Shot { ShotTypeId = (int)ShotType.Missed, ShipTypeId = Ship.SEA };
        }
    }
}