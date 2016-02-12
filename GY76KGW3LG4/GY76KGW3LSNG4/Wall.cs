using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GY76KGW3LSNG4
{
    public class Wall : Drawer
    {
        public Wall()
        {
            color = ConsoleColor.Red;
            sign = 'X';
        }
        public void LoadLevel(int level)
        {
            string fileName = string.Format("level{0}.txt", level);
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamReader sr = new StreamReader(fs);

            body.Clear();
            string[] rows = sr.ReadToEnd().Split('\n');
            for (int i = 0; i < rows.Length; i++)
                for (int j = 0; j < rows[i].Length; j++)
                    if (rows[i][j] == 'X')
                        body.Add(new Point(j, i));
        }
    }
}
