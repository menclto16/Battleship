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

        public void AddNewField()
        {
            Field field = new Field();
            field.CreateNewField();
            fields.Add(field);
        }
    }
}
