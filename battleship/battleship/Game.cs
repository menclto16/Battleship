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
            int playerNum = 0;
            int opponentNum = 1;
            bool match = false;

            while (true)
            {
                Console.WriteLine(map.fields[playerNum].playerName + " strili:");
                try
                {
                    userInput = Console.ReadLine();
                }
                catch (Exception)
                {
                    Console.WriteLine("Spatny vstup! Format vstupu: 'A1'");
                }

                x = userInput[0] - 65;

                y = Int32.Parse(userInput.Substring(1)) - 1;
                //y = (int)Char.GetNumericValue(userInput[1]) - 1;

                for (int a = 0; a < map.fields[opponentNum].ships.Count; a++)
                {
                    if (match) break;

                    for (int b = 0; b < map.fields[opponentNum].ships[a].blocks.Count; b++)
                    {
                        if (map.fields[opponentNum].ships[a].blocks[b].Pos.X == x && map.fields[opponentNum].ships[a].blocks[b].Pos.Y == y && !map.fields[opponentNum].ships[a].blocks[b].state)
                        {
                            map.fields[opponentNum].ships[a].blocks[b].ChangeState();
                            match = true;
                            break;
                        }
                    }
                }

                PrintGraphic();

                Console.WriteLine("x: " + x + " y: " + y);

                if (match)
                {
                    Console.WriteLine("Zasah!");
                }
                else if (!match)
                {
                    Console.WriteLine("Vedle!");
                }

                if (!match && playerNum == 0)
                {
                    playerNum = 1;
                    opponentNum = Math.Abs(playerNum - 1);
                }
                else if (match && playerNum == 0)
                {
                    match = false;
                }
                else if (!match && playerNum == 1)
                {
                    playerNum = 0;
                    opponentNum = Math.Abs(playerNum - 1);
                }
                else if (match && playerNum == 1)
                {
                    match = false;
                }
            }
            
        }

        public void PrintGraphic()
        {
            Console.Clear();

            string nameString = "    " + map.fields[0].playerName;
            nameString += String.Concat(Enumerable.Repeat(" ", 43 - map.fields[0].playerName.Length));
            nameString += map.fields[1].playerName;
            Console.WriteLine(nameString);
            Console.WriteLine("     A  B  C  D  E  F  G  H  I  J               A  B  C  D  E  F  G  H  I  J");
            for (int y = 0; y < 10; y++)
            {
                int fieldNum = 0;
                int column = 0;    

                for (int x = 0; x < 20; x++)
                {
                    if (x == 0 || x == 10)
                    {
                        int numLabel = y + 1;
                        string label = Convert.ToString(numLabel);
                        label = (numLabel < 10) ? " " + label + "  " : " " + label + " ";
                        Console.Write(label);
                    }

                    Console.BackgroundColor = ConsoleColor.Gray;

                    for (int a = 0; a < map.fields[fieldNum].ships.Count; a++)
                    {
                        for (int b = 0; b < map.fields[fieldNum].ships[a].blocks.Count; b++)
                        {
                            if (map.fields[fieldNum].ships[a].blocks[b].Pos.X == column && map.fields[fieldNum].ships[a].blocks[b].Pos.Y == y && map.fields[fieldNum].ships[a].blocks[b].state)
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                            }
                        }
                    }

                    Console.Write(" X ");

                    if (x == 19)
                    {
                        Console.Write("\n");
                    }

                    column++;

                    Console.BackgroundColor = ConsoleColor.Black;

                    if (x == 9)
                    {
                        fieldNum++;
                        column = 0;
                        Console.Write("         ");
                    }
                } 
            }
        }
    }
}
