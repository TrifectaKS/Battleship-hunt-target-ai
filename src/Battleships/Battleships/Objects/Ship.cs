using Battleships.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Objects
{
    class Ship
    {
        public Ship(ShipType type)
        {
            Type = type;
            PartsShot = 0;
            IsDestroyed = false;
        }

        public ShipType Type { get; set; }
        public int PartsShot { get; set; }
        public bool IsDestroyed { get; set; }
    }
}