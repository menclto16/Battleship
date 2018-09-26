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
                            if (x == ships[a].blocks[b].X && y == ships[a].blocks[b].Y)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkRed;

                                for (int c = 0; c < ships.Count; c++)
                                {
                                    if (a == c)
                                    {
                                        continue;
                                    }

                                    for (int d = 0; d < ships[c].blocks.Count; d++)
                                    {
                                        if (ships[a].blocks[b].X == ships[c].blocks[d].X && ships[a].blocks[b].Y == ships[c].blocks[d].Y)
                                        {
                                            Console.BackgroundColor = ConsoleColor.Red;
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
            int[] shipTypeList = { 0, 1, 2, 3, 4, 5, 6, 7 };
            List<Ship> ships = new List<Ship>();

            while (true)
            {
                if (shipNum != shipMem)
                {
                    Ship ship = new Ship();
                    ship.createShip(shipTypeList[shipNum], 0, 0);
                    ships.Add(ship);

                    shipMem = shipNum;
                }

                int blocksLen = ships[shipNum].blocks.Count;

                for (int a = 0; a < blocksLen; a++)
                {
                    if (ships[shipMem].blocks[a].X < 0)
                    {
                        for (int b = 0; b < blocksLen; b++)
                        {
                            ships[shipMem].blocks[b].X++;
                        }
                    }
                    else if (ships[shipMem].blocks[a].X > 9)
                    {
                        for (int b = 0; b < blocksLen; b++)
                        {
                            ships[shipMem].blocks[b].X--;
                        }
                    }

                    if (ships[shipMem].blocks[a].Y < 0)
                    {
                        for (int b = 0; b < blocksLen; b++)
                        {
                            ships[shipMem].blocks[b].Y++;
                        }
                    }
                    else if (ships[shipMem].blocks[a].Y > 9)
                    {
                        for (int b = 0; b < blocksLen; b++)
                        {
                            ships[shipMem].blocks[b].Y--;
                        }
                    }
                }

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

                if (inputKey.Key == ConsoleKey.LeftArrow)
                {
                    for (int i = 0; i < blocksLen; i++)
                    {
                        ships[shipNum].blocks[i].X--;
                    }
                }
                else if (inputKey.Key == ConsoleKey.UpArrow)
                {
                    for (int i = 0; i < blocksLen; i++)
                    {
                        ships[shipNum].blocks[i].Y--;
                    }
                }
                else if (inputKey.Key == ConsoleKey.RightArrow)
                {
                    for (int i = 0; i < blocksLen; i++)
                    {
                        ships[shipNum].blocks[i].X++;
                    }
                }
                else if (inputKey.Key == ConsoleKey.DownArrow)
                {
                    for (int i = 0; i < blocksLen; i++)
                    {
                        ships[shipNum].blocks[i].Y++;
                    }
                }
                else if (inputKey.Key == ConsoleKey.R)
                {
                    int anchorX = ships[shipNum].blocks[0].X;
                    int anchorY = ships[shipNum].blocks[0].Y;

                    for (int i = 1; i < blocksLen; i++)
                    {
                        int X = ships[shipNum].blocks[i].X;
                        int Y = ships[shipNum].blocks[i].Y;

                        int anchorLenX = Math.Abs(anchorX - X);
                        int anchorLenY = Math.Abs(anchorY - Y);

                        if (X == anchorX)
                        {
                            ships[shipNum].blocks[i].Y = anchorY;

                            if (Y > anchorY)
                            {
                                ships[shipNum].blocks[i].X = X - anchorLenY;
                            }
                            else if (Y < anchorY)
                            {
                                ships[shipNum].blocks[i].X = X + anchorLenY;
                            }

                        }
                        else if (Y == anchorY)
                        {
                            ships[shipNum].blocks[i].X = anchorX;

                            if (X > anchorX)
                            {
                                ships[shipNum].blocks[i].Y = Y + anchorLenX;
                            }
                            else if (X < anchorX)
                            {
                                ships[shipNum].blocks[i].Y = Y - anchorLenX;
                            }
                        }
                    }
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
                                if (ships[shipNum].blocks[a].X == ships[b].blocks[c].X && ships[shipNum].blocks[a].Y == ships[b].blocks[c].Y)
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
