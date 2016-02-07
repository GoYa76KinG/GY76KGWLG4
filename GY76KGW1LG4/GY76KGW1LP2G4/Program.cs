using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GY76KGW1LP2G4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your complex number \"a\": ");
            Complex a = new Complex(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));

            Console.WriteLine("Enter your complex number \"b\": ");
            Complex b = new Complex(int.Parse(Console.ReadLine()), int.Parse(Console.ReadLine()));

            Complex c = a + b;
            Console.WriteLine("a + b = " + c);
            Console.ReadKey();
        }
    }
}
