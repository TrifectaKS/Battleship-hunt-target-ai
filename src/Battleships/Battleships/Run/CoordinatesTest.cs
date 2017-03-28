using Battleships.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Run
{
    class CoordinatesTest
    {
        internal Coordinates GetCoordinates(int val,int size)
        {
            /*
                val / size = y
                    if y == floor(y)
                        Coord.Y = y
                        Coord.X = size
                    else
                        decimalval = decimalpart(y)
                        Coord.Y = floor(y)
                        Coord.X = round(integer, decimalval * size)
             */

            if (val == 0)
                return new Coordinates { X = 0, Y = 0, Val = 0 };

            double num = (double)val / (double)size;
            Console.WriteLine("val " + val + " n " + num);
            if (num == Math.Floor(num))
                return new Coordinates { X = size - 1, Y = (int)num - 1, Val = val };

            if (Math.Floor(num) == 0)
                return new Coordinates { Y = 0, X = (int)Math.Round((num - Math.Truncate(num)) * size), Val = val };

            return new Coordinates { Y = (int)Math.Floor(num), X = (int)Math.Ceiling((num - Math.Truncate(num)) * size) - 1, Val = val };
        }

        public void Test()
        {
            for(int i = 0; i < 100; i++)
            {
                Coordinates c = GetCoordinates(i, 10);
                Console.WriteLine("Val: " + c.Val + "X: " + c.X + " Y: " + c.Y);
            }
        }
    }
}
