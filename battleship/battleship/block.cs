using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleship
{
    class Block
    {
        bool state = false;

        public Pos Pos = new Pos();

        public void CreateBlock(int x, int y)
        {
            Pos.X = x;
            Pos.Y = y;
        }
    }
}
