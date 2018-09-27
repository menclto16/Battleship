using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleship
{
    class Ship
    {
        public List<Pos> blocks = new List<Pos>();

        public void CreateShip(int type, int newPosX, int newPosY)
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
                    blockPos1.X = newPosX;
                    blockPos1.Y = newPosY;
                    blocks.Add(blockPos1);

                    blockPos2.X = newPosX + 1;
                    blockPos2.Y = newPosY;
                    blocks.Add(blockPos2);

                    blockPos3.X = newPosX + 2;
                    blockPos3.Y = newPosY;
                    blocks.Add(blockPos3);

                    blockPos4.X = newPosX + 3;
                    blockPos4.Y = newPosY;
                    blocks.Add(blockPos4);
                    break;
                case 5:
                    blockPos1.X = newPosX;
                    blockPos1.Y = newPosY;
                    blocks.Add(blockPos1);

                    blockPos2.X = newPosX + 1;
                    blockPos2.Y = newPosY;
                    blocks.Add(blockPos2);

                    blockPos3.X = newPosX + 2;
                    blockPos3.Y = newPosY;
                    blocks.Add(blockPos3);

                    blockPos4.X = newPosX + 3;
                    blockPos4.Y = newPosY;
                    blocks.Add(blockPos4);

                    blockPos5.X = newPosX + 4;
                    blockPos5.Y = newPosY;
                    blocks.Add(blockPos5);
                    break;
                case 6:
                    blockPos1.X = newPosX;
                    blockPos1.Y = newPosY;
                    blocks.Add(blockPos1);

                    blockPos2.X = newPosX + 1;
                    blockPos2.Y = newPosY;
                    blocks.Add(blockPos2);

                    blockPos3.X = newPosX;
                    blockPos3.Y = newPosY - 1;
                    blocks.Add(blockPos3);
                    break;
                case 7:
                    blockPos1.X = newPosX;
                    blockPos1.Y = newPosY;
                    blocks.Add(blockPos1);

                    blockPos2.X = newPosX - 1;
                    blockPos2.Y = newPosY;
                    blocks.Add(blockPos2);

                    blockPos3.X = newPosX;
                    blockPos3.Y = newPosY - 1;
                    blocks.Add(blockPos3);

                    blockPos4.X = newPosX + 1;
                    blockPos4.Y = newPosY;
                    blocks.Add(blockPos4);
                    break;
            }
        }

        public void RotateShip()
        {
            int blocksLen = blocks.Count;

            int anchorX = blocks[0].X;
            int anchorY = blocks[0].Y;

            for (int i = 1; i < blocksLen; i++)
            {
                int X = blocks[i].X;
                int Y = blocks[i].Y;

                int anchorLenX = Math.Abs(anchorX - X);
                int anchorLenY = Math.Abs(anchorY - Y);

                if (X == anchorX)
                {
                    blocks[i].Y = anchorY;

                    if (Y > anchorY)
                    {
                        blocks[i].X = X - anchorLenY;
                    }
                    else if (Y < anchorY)
                    {
                        blocks[i].X = X + anchorLenY;
                    }

                }
                else if (Y == anchorY)
                {
                    blocks[i].X = anchorX;

                    if (X > anchorX)
                    {
                        blocks[i].Y = Y + anchorLenX;
                    }
                    else if (X < anchorX)
                    {
                        blocks[i].Y = Y - anchorLenX;
                    }
                }
            }
        }

        public void MoveShip(int direction)
        {
            int blocksLen = blocks.Count;

            switch (direction)
            {
                case 0:
                    for (int i = 0; i < blocksLen; i++)
                    {
                        blocks[i].X++;
                    }
                    break;
                case 1:
                    for (int i = 0; i < blocksLen; i++)
                    {
                        blocks[i].Y++;
                    }
                    break;
                case 2:
                    for (int i = 0; i < blocksLen; i++)
                    {
                        blocks[i].X--;
                    }
                    break;
                case 3:
                    for (int i = 0; i < blocksLen; i++)
                    {
                        blocks[i].Y--;
                    }
                    break;
            }
        }
    }
}
