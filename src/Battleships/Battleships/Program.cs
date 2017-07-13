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
            //RunRandomAI.Run(10,1,"Random", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Grids\", "Grid1.txt"),false);
            RunImprovedHuntTargetAI.Run(10, 1, "Improved Hunt Target", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Grids\", "Grid1.txt"), false);
            //RunHuntTargetAI.Run(10, 1, "Hunt Target", Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Grids\", "Grid1.txt"), false);

            Console.ReadKey();
        }
    }
} 

