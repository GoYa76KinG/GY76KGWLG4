using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[6];
            FileStream fsi = new FileStream("input.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite); // путь к файлу чтения
            FileStream fso = new FileStream("output.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite); // путь к файлу сохранения
            StreamReader rs = new StreamReader(fsi); // открываем поток входа данных
            StreamWriter sw = new StreamWriter(fso); // то же самое с выходом
            string[] massive = rs.ReadLine().Split(' '); // создаем массив и сплитим по пробелу
            for (int i = 0; i < massive.Length; i++) // меняем типы данных эдементов массива
                array[i] = int.Parse(massive[i]);
            int k = 0;
            int min = array[0]; // минимум изначально
            for (int i = 0; i < array.Length; i++) // пробегаемся по всем элементам
            {
                // далее проверки на простоту и нахождение минимального
                for (int j = 1; j < min; j++)
                {
                    if (array[i] % j == 0)
                    {
                        k++;
                    }
                }
                if (k == 2 && array[i] < min)
                {
                    min = array[i];
                }
                k = 0;
            }
            sw.WriteLine("Minumum prime number is: " + min); // записываем в файл
            sw.Close();
            rs.Close();
        }
    }
}
