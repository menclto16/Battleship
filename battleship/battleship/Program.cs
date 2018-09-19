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
            List<Ship> ships = new List<Ship>();

            Ship ship1 = new Ship();
            Ship ship2 = new Ship();
            ship1.createShip(5, 1, 1);
            ship2.createShip(6, 5, 8);
            ships.Add(ship1);
            ships.Add(ship2);

            Console.Write("     A  B  C  D  E  F  G  H  I  J\n");
            for (int y = 0; y < 10; y++)
            {
                Console.BackgroundColor = ConsoleColor.Black;

                int numLabel = y + 1;
                string label = Convert.ToString(numLabel);
                label = (numLabel < 10) ? " " + label + "  " : " " + label + " ";
                Console.Write(label);

                for (int x = 0; x < 10; x++)
                {
                    if (x % 2 == 0 && y % 2 == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    } else if (x % 2 != 0 && y % 2 == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                    } else if (x % 2 != 0 && y % 2 != 0)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    } else if (x % 2 == 0 && y % 2 != 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }

                    foreach (var ship in ships)
                    {
                        foreach (var block in ship.blocks)
                        {
                            if (x == block.X && y == block.Y)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                            }
                        }

                    }

                    Console.Write("   ");
                    
                    if (x == 9)
                    {
                        Console.Write("\n");
                    }
                }
            }
            
        }
    }
}
