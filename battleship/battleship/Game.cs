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

        public void StartGame()
        {
            switch (gameType)
            {
                case 0:
                    map.AddNewField(1);
                    map.AddNewField(2);
                    map.AddNewField(3);
                    break;
            }

            PlayGame();
        }

        private void PlayGame()
        {
            int x;
            int y;

            string userInputStr = "";
            ConsoleKeyInfo userInputInt;
            int playerNum = 0;
            int opponentNum;
            bool match = false;
            bool downed = false;
            int numOfDownedBlocks;
            int numOfBlocks = 0;
            int hitBlocks1 = 0;
            int hitBlocks2 = 0;
            int hitBlocks3 = 0;

            foreach (var ship in map.fields[0].ships)
            {
                foreach (var block in ship.blocks)
                {
                    numOfBlocks++;
                }
            }

            map.PrintMap();
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("Hrac " + map.fields[playerNum].playerName + " si voli pole, na ktere bude strilet:");

                while (true)
                {
                    try
                    {
                        userInputInt = Console.ReadKey();

                        int selection = int.Parse(userInputInt.KeyChar.ToString());

                        if (selection >= 1 && selection <=3)
                        {
                            if (selection - 1 == playerNum)
                            {
                                Console.WriteLine("Nemuzes strilet sam na sebe!");
                            }
                            else
                            {
                                opponentNum = selection - 1;

                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Spatny vstup! Format vstupu: '1-3'");
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Spatny vstup! Format vstupu: '1-3'");
                    }
                }

                Console.WriteLine("Hrac " + map.fields[playerNum].playerName + " strili na hrace " + map.fields[opponentNum].playerName + ":");

                while (true)
                {
                    try
                    {
                         userInputStr = Console.ReadLine();
                        if (userInputStr.Length <= 3 && userInputStr.Length >=2 && Char.IsLetter(userInputStr[0]) && int.TryParse(userInputStr.Substring(1), out int n))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Spatny vstup! Format vstupu: 'A1-I10'");
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Spatny vstup! Format vstupu: 'A1-I10'");
                    }
                }

                userInputStr = userInputStr.ToUpper();

                x = userInputStr[0] - 65;

                y = Int32.Parse(userInputStr.Substring(1)) - 1;

                for (int a = 0; a < map.fields[opponentNum].ships.Count; a++)
                {
                    numOfDownedBlocks = 0;

                    for (int b = 0; b < map.fields[opponentNum].ships[a].blocks.Count; b++)
                    {
                        if (map.fields[opponentNum].ships[a].blocks[b].Pos.X == x && map.fields[opponentNum].ships[a].blocks[b].Pos.Y == y && !map.fields[opponentNum].ships[a].blocks[b].state)
                        {
                            map.fields[opponentNum].ships[a].blocks[b].ChangeState();
                            match = true;
                            if (playerNum == 0) hitBlocks1++;
                            if (playerNum == 1) hitBlocks2++;
                            if (playerNum == 2) hitBlocks3++;
                        }

                        if (map.fields[opponentNum].ships[a].blocks[b].state) numOfDownedBlocks++;

                        if (numOfDownedBlocks == map.fields[opponentNum].ships[a].blocks.Count && match) downed = true;
                    }
                }

                map.PrintMap();

                if (match)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    if (downed)
                    {
                        Console.WriteLine("Zasah! Potopena!");
                    }
                    else
                    {
                        Console.WriteLine("Zasah!");
                    }
                }
                else if (!match)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Vedle!");
                }

                Console.ForegroundColor = ConsoleColor.Gray;

                if (!match)
                {
                    playerNum++;
                    if (playerNum == 3) playerNum = 0;
                }
                else if (match)
                {
                    match = false;
                    downed = false;
                }
                
                if (hitBlocks1 == numOfBlocks || hitBlocks2 == numOfBlocks || hitBlocks3 == numOfBlocks)
                {
                    map.fields[0].UncoverBlocks();
                    map.fields[1].UncoverBlocks();
                    map.fields[2].UncoverBlocks();
                    map.PrintMap();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nHrac " + map.fields[playerNum].playerName + " vyhral!");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("Stiskni libovolne tlacitko pro navrat do menu...");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
            }
        }
    }
}
