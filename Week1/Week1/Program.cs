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
             Console.WriteLine("\aEnter your numbers: "); 
             string PrimeNumbers = Console.ReadLine(); 
             string[] Prime = PrimeNumbers.Split(); 
             foreach (string num in Prime) 
             {
                 int PrimeNumb = int.Parse(num); 
                 int i, k = 1; 
                 for (i = 2; (i < PrimeNumb) && (PrimeNumb != 1) && (PrimeNumb != 2) && (k != 0); i++) 
                 {
                     k = PrimeNumb % i;
                 }
                 if ((k != 0) && (PrimeNumb != 0)) 
                 {
                     Console.Write("{0} ", PrimeNumb);
                 }
             }
             Console.ReadKey();
        }
    }
}