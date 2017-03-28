using Battleships.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.DataAccess
{
    class DbInsert
    {
        public static bool Insert(Statistics stats)
        {
            try
            {
                DbRepository repo = new DbRepository();
                repo.AddSimulation(stats.Simulation);
                repo.AddGames(stats.Games);
                repo.AddShots(stats.Shots);
                return true;
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}
