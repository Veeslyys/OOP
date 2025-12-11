using System;

namespace lab1.Models
{
    public class OfflineCourse : Course
    {
        private string classroom;
        private string building;

        public string Classroom
        {
            get { return classroom; }
            set { classroom = value; }
        }

        public string Building
        {
            get { return building; }
            set { building = value; }
        }

        public OfflineCourse(string courseName, string courseId, string classroom, string building) 
            : base(courseName, courseId)
        {
            this.classroom = classroom;
            this.building = building;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("\nОФЛАЙН КУРС");
            Console.WriteLine($"Название: {CourseName}");
            Console.WriteLine($"ID: {CourseId}");
            Console.WriteLine($"Корпус: {Building}");
            Console.WriteLine($"Аудитория: {Classroom}");
            
            if (AssignedTeacher != null)
            {
                Console.WriteLine($"Преподаватель: {AssignedTeacher.Name}");
            }
            else
            {
                Console.WriteLine("Преподаватель: не назначен");
            }
            
            Console.WriteLine($"Количество студентов: {Students.Count}");
        }
    }
}
