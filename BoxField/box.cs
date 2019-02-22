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

        public void Move (int speed)
        {
            y += speed;
        }

        public void Move (int speed, string direction)
        {
            if (direction == "right")
            {
                x += speed;
            }
            else if (direction == "left")
            {
                x -= speed;
            }
        }

        public bool Collision (Box b)
        {
            Rectangle rec1 = new Rectangle(b.x, b.y, b.size, b.size);
            Rectangle playerRec = new Rectangle(x, y, size, size);

            if (rec1.IntersectsWith(playerRec)) { return true; }
            return false;
        }
    }
}
