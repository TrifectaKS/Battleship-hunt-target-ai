using Battleships.Algorithms;
using Battleships.File_Operations;
using Battleships.Functions;
using Battleships.Objects;
using Battleships.Parsing;
using Battleships.Run;
using Battleships.Test;
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
            //Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Grids\", "Grid1.txt")
            //RunRandomAI.Run(10,1000,"Test Run 4", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Grids\", "Grid1.txt"));
            RunHuntTargetAI.Run(10, 1,"Hunt Target", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Grids\", "Grid1.txt"));
            
            Console.ReadKey();
        }
    }
} 
