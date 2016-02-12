using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GY76KGW2LP1G4
{
    class Program
    {
        static void Look(string path)
        {
            Stack<string> dirs = new Stack<string>();
            dirs.Push(path);
            while (dirs.Count > 0)
            {
                DirectoryInfo CurrentDir = new DirectoryInfo(dirs.Pop());
                DirectoryInfo[] SubDirs = CurrentDir.GetDirectories();
                FileInfo[] files = CurrentDir.GetFiles();
                Console.WriteLine(CurrentDir);
                foreach (FileInfo file in files)
                {
                    Console.WriteLine(file);
                }
                foreach (DirectoryInfo d in SubDirs)
                {
                    dirs.Push(d.FullName);
                }
            }
            try
            {

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
        static void Main(string[] args)
        {
            Look(@"C:\");
            Console.ReadKey();
        }
    }
}
