using Battleships.Algorithms;
using Battleships.DataAccess;
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
        const int ITERATIONS = 1000;
        public static void Run()
        {
            Statistics stats = new Statistics(new Simulation() {SimulationId = Guid.NewGuid(), Description = "Random AI", SimulationDate = DateTime.Now });

            try
            {
                for (int i = 0; i < ITERATIONS; i++)
                {
                    Game game = new Game();
                    game.GameId = Guid.NewGuid();
                    game.SimulationId = stats.Simulation.SimulationId;
                    game.GameNumber = i + 1;


                    string s = Files.Read(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Grids\", "Grid1.txt"));
                    Board board = GridParser.Parse(s, SIZE);
                    RandomAI RandAI = new RandomAI(board, game.GameId);
                    stats.Shots.AddRange(RandAI.Play());
                    stats.Games.Add(game);
                   // Display.Grid(board);
                }

                DbInsert.Insert(stats);
                Console.WriteLine("Done");

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
