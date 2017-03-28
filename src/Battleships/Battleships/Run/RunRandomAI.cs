using Battleships.Algorithms;
using Battleships.File_Operations;
using Battleships.Functions;
using Battleships.Objects;
using Battleships.Parsing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Test
{
    class RunRandomAI
    {
        const int SIZE = 10;
        const int ITERATIONS = 100;
        public static void Run()
        {
            try
            {
                List<Statistics> st = new List<Statistics>();

                for (int i = 0; i < ITERATIONS; i++)
                {
                    string s = Files.Read(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Grids\", "Grid1.txt"));
                    Board board = GridParser.Parse(s, SIZE);
                    RandomAI RandAI = new RandomAI(board);
                    Statistics stats = RandAI.Play();
                    st.Add(stats);
                   // Display.Grid(board);
                }

                double avgShots = 0, avgMisses = 0;
                foreach (Statistics stat in st)
                {
                    avgShots += stat.TotalShots;
                    avgMisses += stat.TotalMisses;
                }

                avgShots = avgShots / ITERATIONS;
                avgMisses = avgMisses / ITERATIONS;

                Console.WriteLine("Average Shots: " + avgShots + "\nAverage Misses = " + avgMisses);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
