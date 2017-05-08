using Battleships.Run;
using Battleships.Test;
using System;
using System.IO;

namespace Battleships
{
    class Program
    {
        static void Main(string[] args)
        {
            //Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Grids\", "Grid1.txt")
            RunRandomAI.Run(10,10000,"Random", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Grids\", "Grid1.txt"));
            RunHuntTargetAI.Run(10, 10000,"Hunt Target", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Grids\", "Grid1.txt"));
            
            Console.ReadKey();
        }
    }
} 
