using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleship
{
    class Map
    {
        public List<Field> fields = new List<Field>();

        public void AddNewField(int playerNum)
        {
            Field field = new Field();
            field.CreateNewField(playerNum);
            fields.Add(field);
        }

        public void PrintMap()
        {
            Console.Clear();

            string nameString = "    " + fields[0].playerName;
            nameString += String.Concat(Enumerable.Repeat(" ", 43 - fields[0].playerName.Length));
            nameString += fields[1].playerName;
            Console.WriteLine(nameString);
            Console.WriteLine("     A  B  C  D  E  F  G  H  I  J               A  B  C  D  E  F  G  H  I  J");
            for (int y = 0; y < 10; y++)
            {
                int fieldNum = 0;
                int column = 0;
                int numOfDownedBlocks;
                bool downed = false;

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

                    for (int a = 0; a < fields[fieldNum].ships.Count; a++)
                    {
                        downed = false;
                        numOfDownedBlocks = 0;

                        for (int b = 0; b < fields[fieldNum].ships[a].blocks.Count; b++)
                        {
                            if (fields[fieldNum].ships[a].blocks[b].state) numOfDownedBlocks++;
                        }

                        if (numOfDownedBlocks == fields[fieldNum].ships[a].blocks.Count) downed = true;

                        for (int c = 0; c < fields[fieldNum].ships[a].blocks.Count; c++)
                        {

                            if (fields[fieldNum].ships[a].blocks[c].state) numOfDownedBlocks++;

                            if (fields[fieldNum].ships[a].blocks[c].Pos.X == column && fields[fieldNum].ships[a].blocks[c].Pos.Y == y && fields[fieldNum].ships[a].blocks[c].state)
                            {
                                if (downed)
                                {
                                    Console.BackgroundColor = ConsoleColor.DarkRed;
                                }
                                else
                                {
                                    Console.BackgroundColor = ConsoleColor.Red;
                                }
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
