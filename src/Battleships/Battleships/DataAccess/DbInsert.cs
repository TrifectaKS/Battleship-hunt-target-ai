using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.DataAccess
{
    class DbInsert
    {
        public static bool Insert(List<Shot> s, List<Game> g, Simulation sim)
        {
            try
            {
                DbRepository repo = new DbRepository();
                repo.AddSimulation(sim);
                repo.AddGames(g);
                repo.AddShots(s);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
