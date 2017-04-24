using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.DataAccess
{
    class DbRepository : Connection
    {
        public DbRepository() : base() { }

        public void AddSimulation(Simulation s)
        {
            Entity.Simulations.Add(s);
            Entity.SaveChanges();
        }

        public void AddGames(List<Game> games)
        {

            Entity.BulkInsert(games);
            Entity.BulkSaveChanges();
        }

        public void AddShots(List<Shot> shots)
        {
            Entity.BulkInsert(shots);
            Entity.BulkSaveChanges();
        }
    }
}
