using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GY76KGW1LP3G4
{
    public class Student
    {
        public static Student[] list = new Student[100];
        public string name;
        public string surname;
        public string faculty;
        public string specialization;
        public int course;
        public double GPA;
        public Student(string name, string surname, string faculty, string specialization, int course, double GPA)
        {
            this.name = name;
            this.surname = surname;
            this.faculty = faculty;
            this.specialization = specialization;
            this.course = course;
            this.GPA = GPA;
        }
        public static int k = 0;
        public static Student add(string name, string surname, string faculty, string specialization, int course, double GPA)
        {
            Student student = new Student(name, surname, faculty, specialization, course, GPA);
            list[k] = student;
            k++;
            return student;
        }
        public override string ToString()
        {
            return "Name of student: " + this.name + "\nSurname of student: " + this.surname + "\nFaculty of student: " + this.faculty + "\nSpecialization =: " + this.specialization + "\nCourse of studying: " + this.course + "\nStudent's GPA: " + this.GPA;
        }
    }
}
