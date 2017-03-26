using Battleships.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Objects
{
    class ShotResult
    {
        public int ShipType { get; set; }
        public ShotType ShotType { get; set; }
        public Orientation Orientation { get; set; }
        public DirectionTaken DirectionTaken { get; set; }
        public int InitialTargetX { get; set; }
        public int InitialTargetY { get; set; }
        public int ShotNumber { get; set; }
        public State AIState { get; set; }

    }
}
