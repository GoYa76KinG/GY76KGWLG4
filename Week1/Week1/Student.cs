using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week1
{
    class Student
    {
        public static Student[] list = new Student[10];
        public string name;
        public string surname;
        public double GPA;
        public static int k = 0;
        public Student(string name, string surname, double GPA)
        {
            this.name = name;
            this.surname = surname;
            this.GPA = GPA;
        }
        public static Student add(string name, string surname, double GPA) // после добавления студента в main
        {
            Student student = new Student(name, surname, GPA);
            list[k] = student;
            k++;
            return student; // возвращаем значения
        }
        public override string ToString()
        {
            return "Name: " + this.name + "\n" + "Surname: " + this.surname + "\n" + "GPA: " + this.GPA; // Необходимо вывести все данные, которые должен видеть пользователь при вызове метода;
        }
    }
}

