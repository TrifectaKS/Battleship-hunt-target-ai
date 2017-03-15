using Battleships.Enums;
using Battleships.Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleships.Parsing
{
    class GridParser
    {
        private static List<Ship> InitializeShips()
        {
            List<Ship> ships = new List<Ship>();

            ships.Add(new Ship(ShipType.CV));
            ships.Add(new Ship(ShipType.BB));
            ships.Add(new Ship(ShipType.CL));
            ships.Add(new Ship(ShipType.SS));
            ships.Add(new Ship(ShipType.DD));

            return ships;
        }

        private static int[,] TextToArray(string gridString, int size)
        {
            char[] charGrid = gridString.ToCharArray();

            int[,] grid = new int[size, size];

            int yCount = 0;
            int xCount = 0;

            foreach(char c in charGrid)
            {
                switch (c)
                {
                    case '#':
                        grid[xCount, yCount] = 0;
                        xCount++;
                        break;
                    case '1':
                        grid[xCount, yCount] = Int32.Parse("" + c);
                        xCount++;
                        break;
                    case '2':
                        grid[xCount, yCount] = Int32.Parse("" + c);
                        xCount++;
                        break;
                    case '3':
                        grid[xCount, yCount] = Int32.Parse("" + c);
                        xCount++;
                        break;
                    case '4':
                        grid[xCount, yCount] = Int32.Parse("" + c);
                        xCount++;
                        break;
                    case '5':
                        grid[xCount, yCount] = Int32.Parse("" + c);
                        xCount++;
                        break;
                    case '\n':
                        yCount++;
                        break;
                }
            }

            return grid;
        }

        private static Cell[,] ParseGrid(int[,] grid, List<Ship> ships, int size)
        {
            Cell[,] cellGrid = new Cell[size,size];
            
            for(int y = 0; y < size; y++)
            {
                for(int x = 0; x < size; x++)
                {
                    switch (grid[x,y])
                    {
                        case 0:
                            cellGrid[x, y] = new Cell(null);
                            break;
                        case 1:
                            cellGrid[x, y] = new Cell(ships.ElementAt(grid[x,y] - 1));
                            break;
                        case 2:
                            cellGrid[x, y] = new Cell(ships.ElementAt(grid[x,y] - 1));
                            break;
                        case 3:
                            cellGrid[x, y] = new Cell(ships.ElementAt(grid[x,y] - 1));
                            break;
                        case 4:
                            cellGrid[x, y] = new Cell(ships.ElementAt(grid[x,y] - 1));
                            break;
                        case 5:
                            cellGrid[x, y] = new Cell(ships.ElementAt(grid[x,y] - 1));
                            break;
                    }
                }
            }
            return cellGrid;
        }

        public static Board Parse(string gridString, int size)
        {
            List<Ship> ships = InitializeShips();
            return new Board()
            {
                Grid = ParseGrid(TextToArray(gridString, size), ships, size)
                , Ships = ships
                , Size = size
            };
        }
    }
}
