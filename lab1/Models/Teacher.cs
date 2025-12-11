using System;

namespace lab1.Models
{
    public class Teacher
    {
        private string name;
        private string teacherId;
        private string specialization;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public string TeacherId
        {
            get { return teacherId; }
            set { teacherId = value; }
        }

        public string Specialization
        {
            get { return specialization; }
            set { specialization = value; }
        }

        public Teacher(string name, string teacherId, string specialization)
        {
            this.name = name;
            this.teacherId = teacherId;
            this.specialization = specialization;
        }

        public void Display()
        {
            Console.WriteLine($"Преподаватель: {Name}, Специализация: {Specialization}");
        }
    }
}
