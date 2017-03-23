using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Objects
{
    class Statistics
    {
        public Statistics()
        {
            TotalHits = 0;
            TotalMisses = 0;
        }

        private int hits, misses, shots;

        public int TotalShots { get { return TotalHits + TotalMisses; } }
        public int TotalHits { get; set; }
        public int TotalMisses { get; set; }
    }
}
