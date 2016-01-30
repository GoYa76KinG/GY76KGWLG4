using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\aWrite complex number \"a\": ");
            Complex a = new Complex(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            Console.WriteLine("\aWrite complex number \"b\": ");
            Complex b = new Complex(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));
            Complex c;
            c = a + b;
            Console.WriteLine("a + b = " + c);
            Console.ReadKey();
        }
    }
}