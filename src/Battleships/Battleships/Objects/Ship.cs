using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Objects
{
    class Ship
    {

        //Number Of Ships
        public const int NUM_OF_SHIPS = 5;
        //Ids
        public const int CV_ID = 1, BB_ID = 2, CL_ID = 3, SS_ID = 4, DD_ID = 5, SEA = 0;
        //Lens
        public const int CV_LEN = 5, BB_LEN = 4, CL_LEN = 3, SS_LEN = 3, DD_LEN = 2;
        
        public Ship(int id)
        {
            Type = id;

            switch (id)
            {
                case CV_ID: Length = CV_LEN; Name = "CV"; break;
                case BB_ID: Length = BB_LEN; Name = "BB"; break;
                case CL_ID: Length = CL_LEN; Name = "CL"; break;
                case SS_ID: Length = SS_LEN; Name = "SS"; break;
                case DD_ID: Length = DD_LEN; Name = "DD"; break;
                default: Length = SEA; break;
            }

            PartsShot = 0;
            IsDestroyed = false;
        }

        public string Name { get; set; }
        public int Type { get; set; }
        public int Length { get; set; }
        public int PartsShot { get; set; }
        public bool IsDestroyed { get; set; }
    }
}