using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GY76KGW1LP3G4
{
    class Program
    {
        static string Select()
        {
            Console.WriteLine("Enter word \"add\" to add new contact");
            Console.WriteLine("Enter word \"list\" to add new contact");
            string choise = Console.ReadLine();
            string selection = choise;
            return selection;
        }
        static void Main(string[] args)
        {
            while(true)
            {
                string selection = Select();
                if (selection == "add")
                {
                    Console.WriteLine("\aEnter name of student: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("\aEnter his surname: ");
                    string surname = Console.ReadLine();
                    Console.WriteLine("\aEnter his faculty: ");
                    string faculty = Console.ReadLine();
                    Console.WriteLine("\aEnter his specialization: ");
                    string specialization = Console.ReadLine();
                    Console.WriteLine("\aEnter his course of studying: ");
                    string Course = Console.ReadLine();
                    int course = int.Parse(Course);
                    Console.WriteLine("\aEnter his GPA: ");
                    string gpa = Console.ReadLine();
                    double GPA = double.Parse(gpa);
                    Console.WriteLine(Student.add(name, surname, faculty, specialization, course, GPA));
                }
                if (selection == "list") 
                {
                    for (int i = 0; i < Student.k; i++) 
                    {
                        Console.WriteLine(Student.list[i]); 
                    }
                }
            }
        }
    }
}
