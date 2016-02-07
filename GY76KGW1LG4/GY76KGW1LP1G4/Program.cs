using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GY76KGW1LP1G4
{
    class Program
    {
        static void Main(string[] args)
        {
            string numberstring = Console.ReadLine();
            string[] numbers = numberstring.Split();
            bool[] array = new bool[numbers.Length];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = false;
            }

            for(int i = 0; i < numbers.Length; i++)
            {
                for(int j = 2; j*j < int.Parse(numbers[i]); j++)
                {
                    if (int.Parse(numbers[i]) % j != 0)
                        array[i] = true;
                }
            }

            for(int i = 0; i < array.Length; i++)
            {
                if (array[i])
                    Console.WriteLine(numbers[i]);
            }
            Console.ReadKey();
        }
    }
}
