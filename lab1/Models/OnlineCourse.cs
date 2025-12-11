using System;

namespace lab1.Models
{
    public class OnlineCourse : Course
    {
        private string platform;
        private string link;

        public string Platform
        {
            get { return platform; }
            set { platform = value; }
        }

        public string Link
        {
            get { return link; }
            set { link = value; }
        }

        public OnlineCourse(string courseName, string courseId, string platform, string link) 
            : base(courseName, courseId)
        {
            this.platform = platform;
            this.link = link;
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("\nОНЛАЙН КУРС");
            Console.WriteLine($"Название: {CourseName}");
            Console.WriteLine($"ID: {CourseId}");
            Console.WriteLine($"Платформа: {Platform}");
            Console.WriteLine($"Ссылка: {Link}");
            
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
