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
            

            Console.Write(" A  B  C  D  E  F  G  H  I  J\n");
            for (int i = 0; i < 10; i++)
            {
                for (int b = 0; b < 10; b++)
                {
                    if (b % 2 == 0 && i % 2 == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    } else if (b % 2 != 0 && i % 2 == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                    } else if (b % 2 != 0 && i % 2 != 0)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    } else if (b % 2 == 0 && i % 2 != 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Gray;
                    }

                    Console.Write("   ");

                    if (b == 9)
                    {
                        Console.Write("\n");
                    }
                }
            }
            
        }
    }
}
