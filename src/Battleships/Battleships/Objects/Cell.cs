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
    }
}