using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Objects
{
    [Serializable]
    class Statistics
    {
        public Statistics(Simulation s)
        {
            TotalHits = 0;
            TotalMisses = 0;
            Shots = new List<Shot>();
            Games = new List<Game>();
            Simulation = s;
        }
        
        public Simulation Simulation { get; set; }
        public List<Shot> Shots { get; set; }
        public List<Game> Games { get; set; }
        public int TotalShots { get { return TotalHits + TotalMisses; } }
        public int TotalHits { get; set; }
        public int TotalMisses { get; set; }
    }
}
