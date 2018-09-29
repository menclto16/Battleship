using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace battleship
{
    class Map
    {
        public List<Ship> ships = new List<Ship>();
        
        public void AddNewShip(int type, int x, int y)
        {
            Ship ship = new Ship();

            ship.CreateShip(type, x, y);

            ships.Add(ship);
        }
    }
}
