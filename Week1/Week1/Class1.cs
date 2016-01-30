using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1
{
    class Complex // создаем новый класс для комплексных чисел
    {
        int a, b; // наши комплексные числа
        public Complex(int a, int b)
        {
            this.a = a; // без комментариев...
            this.b = b;
        }

        public static Complex operator +(Complex c1, Complex c2)
        {
            int LCM; // Least Common Multiple
            int i = 1, k = 0;
            int sum, numerator1, numerator2; // Сумма, числитель 1 числа и числитель 2 числа
            if(c1.b != c2.b) // если знаменатели разные
            {
                for(LCM = 1; i!=0; LCM++)
                {
                    i = (LCM % c1.b) + (LCM % c2.b); // находим НОК
                }
                LCM -= 1;
                numerator1 = c1.a * (LCM / c2.b); // Находим первый числитель, учитывая НОК
                numerator2 = c2.a * (LCM / c1.b); // То же самое со вторым
                sum = numerator1 + numerator2; // общий числитель
            }
            else // если же знаменатель одинаковый
            {
                sum = c1.a + c2.a; // просто складываем числители
                LCM = c1.b; // знаменатель остается
            }
            // далее делаем так чтобы числитель сразу сокращался со знаменателем если это возможно
            i = 1;
            if (sum < LCM) // если общий числитель меньше
                k = sum; 
            else // если же больше
                k = LCM;
            for (int j = k; i != 0 && k > 0; k--) 
                i = sum % j + LCM % j; // находим общий делитель
            if (i == 0)
            {
                sum = sum / (k + 1); // делим числитель на ОД
                LCM = LCM / (k + 1); // делим знаменатель на общий делитель
            }
            Complex c3 = new Complex(sum, LCM); // создаем новое комплексное числа включающее в себя общую сумму
            return c3; // возвращаем ей значение
        }
        public override string ToString()
        {
            return a + "/" + b; // возвращаем
        }
    }
}
