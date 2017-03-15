using Battleships.Enums;
using Battleships.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Functions
{
    class Display
    {
        /*
            LEGEND
            A,B,C,D,E For ships that are not destroyed
            # For destroyed ships
            0 For hit ships
            ~ For empty cells
            x For missed shot cells
        */
        public static string Grid(Board b)
        {
            string str = "";
            
            for (int y = 0; y < b.Size; y++)
            {
                for (int x = 0; x < b.Size; x++)
                {
                    if (b.Grid[x, y].Ship == null)
                    {
                        if (b.Grid[x,y].IsShot)
                            str += "x ";
                        else
                            str += "~ ";
                    }
                    else if (b.Grid[x, y].Ship != null)
                    {
                        if (!b.Grid[x, y].Ship.IsDestroyed && !b.Grid[x,y].IsHit)
                        {
                            switch (b.Grid[x, y].Ship.Type.ToString())
                            {
                                case "CV": str += "E "; break; //e
                                case "CL": str += "C "; break; //c
                                case "BB": str += "D "; break; //d
                                case "DD": str += "A "; break; //a
                                case "SS": str += "B "; break; //b
                            }
                        }
                        else if(!b.Grid[x, y].Ship.IsDestroyed && b.Grid[x, y].IsHit)
                        {
                            str += "0 ";
                        }else if(b.Grid[x, y].Ship.IsDestroyed && b.Grid[x, y].IsHit)
                        {
                            str += "# ";
                        }
                    }
                }
                str += "\n";
            }
            return str;
        }
        
        public static string Ships(Board b, bool destroyed)
        {
            if (b.Ships == null || b.Ships.Count == 0)
                return "No Ships Found";

            string str = "Live Ships:\n";
            int c = 1;

            foreach (Ship s in b.Ships)
            {
                if (s.IsDestroyed == destroyed)
                {
                    str += "Ship " + c + ": " + s.Type.ToString() + "\n";
                    c++;
                }
            }
            return str;
        }

        public static string Ships(Board b)
        {
            if (b.Ships == null || b.Ships.Count == 0)
                return "No Ships Found";

            string str = "All Ships:\n";
            int c = 1;
            
            foreach (Ship s in b.Ships)
            {
                str += "Ship " + c + ": " + s.Type.ToString() + "\n";
                c++;
            }
            return str;
        }
    }
}
