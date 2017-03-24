using Battleships.Algorithms;
using Battleships.File_Operations;
using Battleships.Functions;
using Battleships.Objects;
using Battleships.Parsing;
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
            RunRandomAI.Run();

            Console.ReadKey();
        }
    }
}
