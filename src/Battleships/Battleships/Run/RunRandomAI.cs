﻿using Battleships.Algorithms;
using Battleships.DataAccess;
using Battleships.Enums;
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
        public static void Run(int size, int iterations, string simDesc, string boardPath, bool dbInsert)
        {
            Statistics stats = new Statistics(new Simulation() {SimulationId = Guid.NewGuid(), Description = simDesc, SimulationDate = DateTime.Now, AIType = (int)AIType.Random});

            try
            {
                Random random = new Random();
                for (int i = 0; i < iterations; i++)
                {
                    Game game = new Game();
                    game.GameId = Guid.NewGuid();
                    game.SimulationId = stats.Simulation.SimulationId;
                    game.GameNumber = i + 1;


                    string s = Files.Read(boardPath);
                    Board board = GridParser.Parse(s, size);
                    RandomAI RandAI = new RandomAI(board, game.GameId, random);
                    stats.Shots.AddRange(RandAI.Play());
                    stats.Games.Add(game);
                   // Display.Grid(board);
                }

                if(dbInsert)
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
