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
            Console.WriteLine("Enter low limit: "); // задаем нижний порог
            int a = int.Parse(Console.ReadLine()); 
            Console.WriteLine("Enter high limit: "); // задаем верхний лимит
            int b = int.Parse(Console.ReadLine());
            for (int i = a; i <= b; i++) // цикл для вывода ответа
            {
                if (isSimple(i))
                {
                    Console.Write(i.ToString() + " "); // если простое то выводим
                }
            }
            Console.ReadKey();
        }
        //метод который определяет простое число или нет
        private static bool isSimple(int N) // функция для проверки на простоту
        {
            for (int i = 2; i < (int)(N / 2); i++)
            {
                if (N % i == 0)
                    return false;
            }
            return true;
        }
    }
}