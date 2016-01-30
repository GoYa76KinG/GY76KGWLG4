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
            /* самый простой массив
            int[] array1 = new int[5];

            // заполнянем массив сразу тут
            int[] array2 = new int[] { 1, 3, 5, 7, 9 };

            // альтернатива заполнению выше
            int[] array3 = { 1, 2, 3, 4, 5, 6 };

            // двухмерный массив
            int[,] multiDimensionalArray1 = new int[2, 3];

            // заполняем массив что выше
            int[,] multiDimensionalArray2 = { { 1, 2, 3 }, { 4, 5, 6 } };

            // двухмерный массив у которого нет конкретного числа строк в столбцах
            int[][] jaggedArray = new int[6][];

            // задаем значения тому что выше
            jaggedArray[0] = new int[4] { 1, 2, 3, 4 };

         Покажет количество аргументов...кажется 
        System.Console.WriteLine(args.Length);
        Console.ReadKey();

        int a = 5;
        int b = a + 2; //  типичное сложение...до сих пор не понимаю зачем я это делаю

        bool test = true; // балуемся с бул

        // тут нам должно выдать ошибку...лучше закоментить
        //int c = a + test;

        // тут мы просто создаем переменные... ЗАЧЕЕЕЕМ?!
        float temperature; // не помню что это..
        string name; // строка..
        //MyClass myClass; - не знаю что это

        // тут мы инициализируем переменные
        char firstLetter = 'C'; // чар это символ
        var limit = 3; // как я понял то же самое что и инт32
        int[] source = { 0, 1, 2, 3, 4, 5 }; // это типичный массив
        var query = from item in source //  если бы я знал что это...
                    where item <= limit
                    select item;

        byte by = Byte.MaxValue; // тип данных байт
        byte num = 0xA; // еще один байт в другой системе исчесления как я понял
        int i = 5; // интеджер
        char c = 'Z'; // чар

        string s = "The answer is " + 5.ToString();
        // ну тут все понятно
        Console.WriteLine(s);

        Type type = 12345.GetType();
        // тут нам должны вывести тип данных, в данном случае инт32
        Console.WriteLine(type);*/


            // задаем строку
            string message1;

            // инициализируем в нулл
            string message2 = null;

            // инициализируем как пустую строку
            string message3 = System.String.Empty;

            //инициализируем как строку
            string oldPath = "c:\\Program Files\\Microsoft Visual Studio 8.0";

            // добавляем @ чтобы не посчитало \ как команду..не знаю как это назвать
            string newPath = @"c:\Program Files\Microsoft Visual Studio 9.0";

            // задаем стринг здесь
            System.String greeting = "Hello World!";

            // переводит переменную в тип стринг
            var temp = "I'm still a strongly-typed System.String!";

            // константа
            const string message4 = "You can't get rid of me!";

            // массив из символов
            char[] letters = { 'A', 'B', 'C' };
            string alphabet = new string(letters);

            string s1 = "A string is more ";
            string s2 = "than the sum of its chars.";

            // соединяем строки что задали выше
            s1 += s2;

            System.Console.WriteLine(s1);
            // получаем обьединенную версию

            string s10 = "Hello ";
            string s20 = s1;
            s1 += "World";

            System.Console.WriteLine(s20);// с20 принимает значение с10

            string filePath = @"C:\Users\scoleridge\Documents\";
            // выводит ссылку

            string text = @"My pensive SARA ! thy soft cheek reclined
    Thus on mine arm, most soothing sweet it is
    To sit beside our Cot,...";
            /* должно вывести:
            My pensive SARA ! thy soft cheek reclined
               Thus on mine arm, most soothing sweet it is
               To sit beside our Cot,... 
            */

            string quote = @"Her name was ""Sara.""";
            //должны выйти: Her name was "Sara."

            Console.ReadKey();
        }

    }

        /*public enum FileMode // не знаю даже что это делает
        {
            CreateNew = 1,
            Create = 2,
            Open = 3,
            OpenOrCreate = 4,
            Truncate = 5,
            Append = 6,
        }
        public string GetName(int ID) // новая функция
        {
            if (ID < names.Length) // вы поняли..
                return names[ID]; // в случае тру возвращаем это значение
            else
                return String.Empty; // в другом случае опустошаем
        }
        private string[] names = { "Spencer", "Sally", "Doug" }; // имена..

        public struct CoOrds // учимся создавать структуры :facepalm:
        {
            public int x, y; // будущие координаты

            public CoOrds(int p1, int p2) // тут все понятно
            {
                x = p1;
                y = p2;
            }
        }
    }*/
}
