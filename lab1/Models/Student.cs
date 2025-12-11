using System;

namespace lab1.Models
{
    public class Student
    {
        private string name;
        private string studentId;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string StudentId
        {
            get { return studentId; }
            set { studentId = value; }
        }

        public Student(string name, string studentId)
        {
            this.name = name;
            this.studentId = studentId;
        }

        public void Display()
        {
            Console.WriteLine($"Студент: {Name}, ID: {StudentId}");
        }
    }
}
