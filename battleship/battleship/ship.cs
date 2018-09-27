using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleship
{
    class Ship
    {
        public List<Block> blocks = new List<Block>();

        public void CreateShip(int type, int x, int y)
        {
            switch (type)
            {
                case 0:
                    blocks.Add(new Block());

                    blocks[0].CreateBlock(x, y);
                    break;
                case 1:
                    blocks.Add(new Block());
                    blocks.Add(new Block());

                    blocks[0].CreateBlock(x, y);
                    blocks[1].CreateBlock(x+1, y);
                    break;
                case 2:
                    blocks.Add(new Block());
                    blocks.Add(new Block());
                    blocks.Add(new Block());

                    blocks[0].CreateBlock(x, y);
                    blocks[1].CreateBlock(x + 1, y);
                    blocks[2].CreateBlock(x + 2, y);
                    break;
                case 3:
                    blocks.Add(new Block());
                    blocks.Add(new Block());
                    blocks.Add(new Block());
                    blocks.Add(new Block());

                    blocks[0].CreateBlock(x, y);
                    blocks[1].CreateBlock(x + 1, y);
                    blocks[2].CreateBlock(x + 2, y);
                    blocks[3].CreateBlock(x + 3, y);
                    break;
                case 4:
                    blocks.Add(new Block());
                    blocks.Add(new Block());
                    blocks.Add(new Block());
                    blocks.Add(new Block());
                    blocks.Add(new Block());

                    blocks[0].CreateBlock(x, y);
                    blocks[1].CreateBlock(x + 1, y);
                    blocks[2].CreateBlock(x + 2, y);
                    blocks[3].CreateBlock(x + 3, y);
                    blocks[4].CreateBlock(x + 4, y);
                    break;
                case 5:
                    blocks.Add(new Block());
                    blocks.Add(new Block());
                    blocks.Add(new Block());
                    blocks.Add(new Block());
                    blocks.Add(new Block());
                    blocks.Add(new Block());

                    blocks[0].CreateBlock(x, y);
                    blocks[1].CreateBlock(x + 1, y);
                    blocks[2].CreateBlock(x + 2, y);
                    blocks[3].CreateBlock(x + 3, y);
                    blocks[4].CreateBlock(x + 4, y);
                    blocks[5].CreateBlock(x + 5, y);
                    break;
                case 6:
                    blocks.Add(new Block());
                    blocks.Add(new Block());
                    blocks.Add(new Block());

                    blocks[0].CreateBlock(x, y);
                    blocks[1].CreateBlock(x + 1, y);
                    blocks[2].CreateBlock(x, y - 1);
                    break;
                case 7:
                    blocks.Add(new Block());
                    blocks.Add(new Block());
                    blocks.Add(new Block());

                    blocks[0].CreateBlock(x, y);
                    blocks[1].CreateBlock(x - 1, y);
                    blocks[2].CreateBlock(x, y - 1);
                    blocks[3].CreateBlock(x + 1, y);
                    break;
            }
        }

        public void RotateShip()
        {
            int blocksLen = blocks.Count;

            int anchorX = blocks[0].block.X;
            int anchorY = blocks[0].block.Y;

            for (int i = 1; i < blocksLen; i++)
            {
                int X = blocks[i].block.X;
                int Y = blocks[i].block.Y;

                int anchorLenX = Math.Abs(anchorX - X);
                int anchorLenY = Math.Abs(anchorY - Y);

                if (X == anchorX)
                {
                    blocks[i].block.Y = anchorY;

                    if (Y > anchorY)
                    {
                        blocks[i].block.X = X - anchorLenY;
                    }
                    else if (Y < anchorY)
                    {
                        blocks[i].block.X = X + anchorLenY;
                    }

                }
                else if (Y == anchorY)
                {
                    blocks[i].block.X = anchorX;

                    if (X > anchorX)
                    {
                        blocks[i].block.Y = Y + anchorLenX;
                    }
                    else if (X < anchorX)
                    {
                        blocks[i].block.Y = Y - anchorLenX;
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
                        blocks[i].block.X++;
                    }
                    break;
                case 1:
                    for (int i = 0; i < blocksLen; i++)
                    {
                        blocks[i].block.Y++;
                    }
                    break;
                case 2:
                    for (int i = 0; i < blocksLen; i++)
                    {
                        blocks[i].block.X--;
                    }
                    break;
                case 3:
                    for (int i = 0; i < blocksLen; i++)
                    {
                        blocks[i].block.Y--;
                    }
                    break;
            }
        }

        public void OptimiseShip()
        {
            int blocksLen = blocks.Count;

            for (int a = 0; a < blocksLen; a++)
            {
                if (blocks[a].block.X < 0)
                {
                    for (int b = 0; b < blocksLen; b++)
                    {
                        blocks[b].block.X++;
                    }
                }
                else if (blocks[a].block.X > 9)
                {
                    for (int b = 0; b < blocksLen; b++)
                    {
                        blocks[b].block.X--;
                    }
                }

                if (blocks[a].block.Y < 0)
                {
                    for (int b = 0; b < blocksLen; b++)
                    {
                        blocks[b].block.Y++;
                    }
                }
                else if (blocks[a].block.Y > 9)
                {
                    for (int b = 0; b < blocksLen; b++)
                    {
                        blocks[b].block.Y--;
                    }
                }
            }
        }
    }
}
