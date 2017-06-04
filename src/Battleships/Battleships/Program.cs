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
            RunRandomAI.Run(10,100,"Random", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Grids\", "Grid1.txt"),true);
            RunImprovedHuntTargetAI.Run(100, 1, "Improved Hunt Target", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Grids\", "Grid1.txt"), true);
            RunHuntTargetAI.Run(10, 100, "Hunt Target", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Grids\", "Grid1.txt"), true);

            Console.ReadKey();
        }
    }
} 

