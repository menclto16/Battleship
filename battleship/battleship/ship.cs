using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleship
{
    class Ship
    {
        public int posX;
        public int posY;
        List<Pos> blocks = new List<Pos>();

        public void setPos(int type, int newPosX, int newPosY)
        {
            Pos blockPos1 = new Pos();
            Pos blockPos2 = new Pos();
            Pos blockPos3 = new Pos();
            Pos blockPos4 = new Pos();
            Pos blockPos5 = new Pos();
            Pos blockPos6 = new Pos();
            Pos blockPos7 = new Pos();

            switch (type)
            {
                case 0:
                    blockPos1.X = newPosX;
                    blockPos1.Y = newPosY;
                    blocks.Add(blockPos1);
                    break;
                case 1:
                    blockPos1.X = newPosX;
                    blockPos1.Y = newPosY;
                    blocks.Add(blockPos1);

                    blockPos2.X = newPosX+1;
                    blockPos2.Y = newPosY;
                    blocks.Add(blockPos2);
                    break;
                case 2:
                    blockPos1.X = newPosX;
                    blockPos1.Y = newPosY;
                    blocks.Add(blockPos1);

                    blockPos2.X = newPosX + 1;
                    blockPos2.Y = newPosY;
                    blocks.Add(blockPos2);

                    blockPos3.X = newPosX + 2;
                    blockPos3.Y = newPosY;
                    blocks.Add(blockPos3);
                    break;
                case 3:
                    blockPos1.X = newPosX;
                    blockPos1.Y = newPosY;
                    blocks.Add(blockPos1);

                    blockPos2.X = newPosX + 1;
                    blockPos2.Y = newPosY;
                    blocks.Add(blockPos2);

                    blockPos3.X = newPosX + 2;
                    blockPos3.Y = newPosY;
                    blocks.Add(blockPos3);
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    break;
                case 8:
                    break;
            }
        }
    }
}
