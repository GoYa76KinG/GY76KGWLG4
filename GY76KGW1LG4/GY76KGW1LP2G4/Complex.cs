using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GY76KGW1LP2G4
{
    public class Complex
    {
        int a, b;
        public Complex(int a, int b)
        {
            this.a = a;
            this.b = b;
        }

     public static Complex operator +(Complex c1, Complex c2)
            {
                int LCM;
                int i = 1, k = 0;
                int sum, numerator1, numerator2; 
                if (c1.b != c2.b) 
                {
                    for (LCM = 1; i != 0; LCM++)
                    {
                        i = (LCM % c1.b) + (LCM % c2.b); 
                    }
                    LCM -= 1;
                    numerator1 = c1.a * (LCM / c2.b); 
                    numerator2 = c2.a * (LCM / c1.b); 
                    sum = numerator1 + numerator2;
                }
                else 
                {
                    sum = c1.a + c2.a;
                    LCM = c1.b; 
                }
                i = 1;
                if (sum < LCM) 
                    k = sum;
                else 
                    k = LCM;
                for (int j = k; i != 0 && k > 0; k--)
                    i = sum % j + LCM % j; 
                if (i == 0)
                {
                    sum = sum / (k + 1);
                    LCM = LCM / (k + 1); 
                }
                Complex ci = new Complex(sum, LCM); 
                return ci; 
            }
        public override string ToString()
        {
            return a + "/" + b;
        }
    }
}
