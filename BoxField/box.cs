using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BoxField
{
    class Box
    {
        //color
        public int x, y, size;
        public Color colour;

        public Box (int _x, int _y, int _size, Color _color)
        {
            x = _x;
            y = _y;
            size = _size;
            colour = _color;
        }

        //need move metheod
    }
}
