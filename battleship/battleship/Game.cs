using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleship
{
    class Game
    {
        public int gameType;
        Map map = new Map();

        enum XChar { A, B, C, D, E, F, G, H, I, J };

        public void StartGame()
        {
            switch (gameType)
            {
                case 0:
                    map.AddNewField();
                    map.AddNewField();
                    break;
            }

            PlayGame();
        }

        private void PlayGame()
        {
            int x;
            int y;

            string userInput = "";

            while (true)
            {
                Console.WriteLine(map.fields[0].playerName + " strili:");
                try
                {
                    userInput = Console.ReadLine();
                }
                catch (Exception)
                {
                    Console.WriteLine("Spatny vstup! Format vstupu: 'A1'");
                }

                x = userInput[0] - 65;
                y = (int)Char.GetNumericValue(userInput[1]) - 1;

                Console.WriteLine("x: " + x + " y: " + y);

                for (int a = 0; a < map.fields[0].ships.Count; a++)
                {
                    for (int b = 0; b < map.fields[0].ships[a].blocks.Count; b++)
                    {
                        if (map.fields[0].ships[a].blocks[b].Pos.X == x && map.fields[0].ships[a].blocks[b].Pos.Y == y)
                        {
                            Console.WriteLine("Zasah!");
                        }
                    }
                }
            }
            
        }

        public void PrintGraphic()
        {
            Console.Clear();

            Console.Write("     A  B  C  D  E  F  G  H  I  J               A  B  C  D  E  F  G  H  I  J\n");
            for (int y = 0; y < 10; y++)
            {
                int numLabel = y + 1;
                string label = Convert.ToString(numLabel);
                label = (numLabel < 10) ? " " + label + "  " : " " + label + " ";
                Console.Write(label);

                for (int x = 0; x < 10; x++)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;

                    for (int a = 0; a < map.fields[0].ships.Count; a++)
                    {
                        for (int b = 0; b < map.fields[0].ships[a].blocks.Count; b++)
                        {
                            if (x == map.fields[0].ships[a].blocks[b].Pos.X && y == map.fields[0].ships[a].blocks[b].Pos.Y)
                            {
                                Console.BackgroundColor = ConsoleColor.Red;

                                for (int c = 0; c < map.fields[0].ships.Count; c++)
                                {
                                    if (a == c)
                                    {
                                        continue;
                                    }

                                    for (int d = 0; d < map.fields[0].ships[c].blocks.Count; d++)
                                    {
                                        if (map.fields[0].ships[a].blocks[b].Pos.X == map.fields[0].ships[c].blocks[d].Pos.X && map.fields[0].ships[a].blocks[b].Pos.Y == map.fields[0].ships[c].blocks[d].Pos.Y)
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
