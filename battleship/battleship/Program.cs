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
            while (true)
            {
                Console.WriteLine("1) Nova hra");
                Console.WriteLine("2) Ukoncit hru");
                int selection = 0;

                try
                {
                    ConsoleKeyInfo userInput = Console.ReadKey();

                    selection = int.Parse(userInput.KeyChar.ToString());

                }
                catch (Exception)
                {
                    Console.WriteLine("\n\nNeplatny vstup!");
                }

                switch (selection)
                {
                    case 1:
                        Game game = new Game();
                        game.gameType = 0;
                        game.StartGame();
                        break;
                    case 2:
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
