using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Objects
{
    class Board
    {
        public Cell[,] Grid { get; set; }
        public int Size { get; set; }
        public List<Ship> Ships { get; set; }
    }
}
