using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleship
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Ship> ships = createField(0);

            printGraphic(ships);
        }

        static void printGraphic(List<Ship> ships)
        {
            Console.Clear();

            Console.Write("     A  B  C  D  E  F  G  H  I  J\n");
            for (int y = 0; y < 10; y++)
            {
                int numLabel = y + 1;
                string label = Convert.ToString(numLabel);
                label = (numLabel < 10) ? " " + label + "  " : " " + label + " ";
                Console.Write(label);

                for (int x = 0; x < 10; x++)
                {
                    if (x % 2 == 0 && y % 2 == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    else if (x % 2 != 0 && y % 2 == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }
                    else if (x % 2 != 0 && y % 2 != 0)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    }
                    else if (x % 2 == 0 && y % 2 != 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }

                    for (int a = 0; a < ships.Count; a++)
                    {
                        for (int b = 0; b < ships[a].blocks.Count; b++)
                        {
                            if (x == ships[a].blocks[b].block.X && y == ships[a].blocks[b].block.Y)
                            {
                                Console.BackgroundColor = ConsoleColor.Red;

                                for (int c = 0; c < ships.Count; c++)
                                {
                                    if (a == c)
                                    {
                                        continue;
                                    }

                                    for (int d = 0; d < ships[c].blocks.Count; d++)
                                    {
                                        if (ships[a].blocks[b].block.X == ships[c].blocks[d].block.X && ships[a].blocks[b].block.Y == ships[c].blocks[d].block.Y)
                                        {
                                            Console.BackgroundColor = ConsoleColor.DarkRed;
                                        }
                                    }
                                }
                            }
                        }
                    }

                    
                    Console.Write("   ");

                    if (x == 9)
                    {
                        Console.Write("\n");
                    }

                    Console.BackgroundColor = ConsoleColor.Black;
                }
            }
        }

        static List<Ship> createField(int playerNum)
        {
            int shipNum = 0;
            int shipMem = -1;
            bool overlap = false;
            int[] shipTypeList = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 5, 6, 7 };
            List<Ship> ships = new List<Ship>();

            while (true)
            {
                if (shipNum != shipMem)
                {
                    Ship ship = new Ship();
                    ship.CreateShip(shipTypeList[shipNum], 0, 0);
                    ships.Add(ship);

                    shipMem = shipNum;
                }

                int blocksLen = ships[shipNum].blocks.Count;

                ships[shipNum].OptimiseShip();
                printGraphic(ships);
                Console.WriteLine("<^>v - posun, r - otoceni");

                if (overlap)
                {
                    Console.WriteLine("Lode se nesmi prekryvat!");
                    overlap = false;
                }

                if (shipNum >= shipTypeList.Length)
                {
                    break;
                }

                ConsoleKeyInfo inputKey = Console.ReadKey();

                if (inputKey.Key == ConsoleKey.RightArrow)
                {
                    ships[shipNum].MoveShip(0);
                }
                else if (inputKey.Key == ConsoleKey.DownArrow)
                {
                    ships[shipNum].MoveShip(1);
                }
                else if (inputKey.Key == ConsoleKey.LeftArrow)
                {
                    ships[shipNum].MoveShip(2);
                }
                else if (inputKey.Key == ConsoleKey.UpArrow)
                {
                    ships[shipNum].MoveShip(3);
                }
                else if (inputKey.Key == ConsoleKey.R)
                {
                    ships[shipNum].RotateShip(); 
                }
                else if (inputKey.Key == ConsoleKey.Enter)
                {
                    for (int a = 0; a < ships[shipNum].blocks.Count; a++)
                    {
                        for (int b = 0; b < ships.Count; b++)
                        {
                            if (b == shipNum) continue;

                            for (int c = 0; c < ships[b].blocks.Count; c++)
                            {
                                if (ships[shipNum].blocks[a].block.X == ships[b].blocks[c].block.X && ships[shipNum].blocks[a].block.Y == ships[b].blocks[c].block.Y)
                                {
                                    overlap = true;
                                    break;
                                }
                            }
                        }
                    }

                    if (!overlap) shipNum++; 
                }
            }

            return ships;
        }
    }
}
