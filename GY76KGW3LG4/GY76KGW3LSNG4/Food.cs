using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GY76KGW3LSNG4
{
    public class Food : Drawer
    {
        public Food()
        {
            color = ConsoleColor.Green;
            sign = '$';
        }

        public void SetNewPosition()
        {
            int x = new Random().Next() % 120;
            int y = new Random().Next() % 27;
            if (body.Count == 0)
                body.Add(new Point(x, y));
            else
            {
                body[0].x = x;
                body[0].y = y;
            }
        }

    }
}
