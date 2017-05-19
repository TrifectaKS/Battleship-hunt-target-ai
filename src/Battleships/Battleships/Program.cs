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
            RunRandomAI.Run(10,5000,"Random", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Grids\", "Grid1.txt"),true);
            RunImprovedHuntTargetAI.Run(10, 5000,"Improved Hunt Target", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Grids\", "Grid1.txt"), true);
            RunHuntTargetAI.Run(10, 5000, "Hunt Target", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Grids\", "Grid1.txt"), true);

            Console.ReadKey();
        }
    }
} 

