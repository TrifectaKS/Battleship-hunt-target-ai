using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.DataAccess
{
    class Connection
    {
        public BattleshipDBEntities Entity { get; set; }
        public Connection()
        {
            Entity = new BattleshipDBEntities();
        }
    }
}
