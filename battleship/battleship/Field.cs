using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleship
{
    class Field
    {
        public List<Ship> ships = new List<Ship>();
        public string playerName;

        public void CreateNewField()
        {
            Console.WriteLine("Zadej jmeno hrace:");

            try
            {
                playerName = Console.ReadLine();
            }
            catch (Exception)
            {
                Console.WriteLine("Spatny vstup!");
            }

            int[] shipTypeList = { 0, 0, 1, 1, 2, 2, 3, 3, 4, 5, 6, 7 };
            int shipNum = 0;
            int shipMem = -1;
            bool overlap = false;

            while (true)
            {
                if (shipNum == shipTypeList.Length) break;

                if (shipNum != shipMem)
                {
                    AddNewShip(shipTypeList[shipNum], 0, 0);

                    shipMem = shipNum;
                }

                int blocksLen = ships[shipNum].blocks.Count;

                ships[shipNum].OptimiseShip();

                PrintField();

                if (overlap)
                {
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
                                if (ships[shipNum].blocks[a].Pos.X == ships[b].blocks[c].Pos.X && ships[shipNum].blocks[a].Pos.Y == ships[b].blocks[c].Pos.Y)
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
        }

        public void AddNewShip(int type, int x, int y)
        {
            Ship ship = new Ship();

            ship.CreateShip(type, x, y);

            ships.Add(ship);
        }

        private void PrintField()
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
                    Console.BackgroundColor = ConsoleColor.Gray;

                    for (int a = 0; a < ships.Count; a++)
                    {
                        for (int b = 0; b < ships[a].blocks.Count; b++)
                        {
                            if (x == ships[a].blocks[b].Pos.X && y == ships[a].blocks[b].Pos.Y)
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
                                        if (ships[a].blocks[b].Pos.X == ships[c].blocks[d].Pos.X && ships[a].blocks[b].Pos.Y == ships[c].blocks[d].Pos.Y)
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
    }
}
