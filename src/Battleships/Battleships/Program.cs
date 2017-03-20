using Battleships.File_Operations;
using Battleships.Objects;
using Battleships.Parsing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Battleships.File_Operations.Files;

namespace Battleships
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string s = Files.Read(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Grids\", "Grid1.txt"));
                Board board = GridParser.Parse(s, 10);
            }catch(Exception e)
            {
                Console.WriteLine(e.ToString());
            }

            Console.ReadKey();
        }
    }
}
