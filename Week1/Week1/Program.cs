using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1
{
    class Program
    {
        static string Select()
        {
            // показываем пользователю список доступных комманд для выполнения
            Console.WriteLine("\aEnter \"add\" if you want to add new student to the list;");
            Console.WriteLine("Enter \"list\" if you want to see all students in the list");
            string choise = Console.ReadLine(); // считываем команду пользователя
            string selection = choise; // передаем значение команды в основной стринг
            return selection; // возвращаем значение
        }
        static void Main(string[] args)
        {
            while (true) // пока тру
            {
                string selection = Select(); // задаем значение из функции
                if (selection == "add") // если он ввел add 
                {
                    Console.WriteLine("\aEnter name of student: "); // просим ввести имя
                    string name = Console.ReadLine(); // вводим имя
                    Console.WriteLine("\aEnter his surname: "); // просим фамилию
                    string surname = Console.ReadLine(); // фамилия
                    Console.WriteLine("\aEnter his GPA: "); // просим ввести гпа
                    string gpa = Console.ReadLine(); // считываем его
                    double GPA = double.Parse(gpa); // меняем тип данных на дабл
                    Console.WriteLine(Student.add(name, surname, GPA)); // добавляем студента
                }
                if(selection == "list") // если ввели list
                {
                    for(int i = 0; i < Student.k; i++) // пробегаемся по всем студентам в списке
                    {
                        Console.WriteLine(Student.list[i]); // выводим данные о студенте
                    }
                }
            }
        }
    }
}
