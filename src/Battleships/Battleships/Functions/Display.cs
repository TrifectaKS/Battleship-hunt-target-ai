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
        public static void Grid(Board b)
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
                            switch (b.Grid[x, y].Ship.Type)
                            {
                                case Ship.CV_ID: str += Ship.CV_ID + " "; break; //e
                                case Ship.CL_ID: str += Ship.CL_ID + " "; break; //c
                                case Ship.BB_ID: str += Ship.BB_ID + " "; break; //d
                                case Ship.DD_ID: str += Ship.DD_ID + " "; break; //a
                                case Ship.SS_ID: str += Ship.SS_ID + " "; break; //b
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

            Console.WriteLine(str);
        }
        
        public static void Ships(Board b, bool destroyed)
        {
            if (b.Ships == null || b.Ships.Count == 0)
            {
                Console.WriteLine("No Ships Found");
                return;
            }

            string str = "Live Ships:\n";
            int c = 1;

            foreach (Ship s in b.Ships)
            {
                if (s.IsDestroyed == destroyed)
                {
                    str += "Ship " + c + ": " + s.Name + " Lenght: " + s.Length + "\n";
                    c++;
                }
            }

            Console.WriteLine(str);
        }

        public static void Ships(Board b)
        {
            if (b.Ships == null || b.Ships.Count == 0)
            {
                Console.WriteLine("No Ships Found");
                return;
            }

            string str = "All Ships:\n";
            int c = 1;
            
            foreach (Ship s in b.Ships)
            {
                str += "Ship " + c + ": " + s.Name + " Lenght: " + s.Length + "\n";
                c++;
            }

            Console.WriteLine(str);
        }
    }
}
