using System;
using lab1.Models;
using lab1.Services;

namespace lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("УПРАВЛЕНИЕ КУРСАМИ\n");

            CourseManager manager = new CourseManager();

            Teacher teacher1 = new Teacher("Кочубеев Николай Сергеевич", "T001", "ООП");
            Teacher teacher2 = new Teacher("Курашова Светлана Александровна", "T002", "Физика");

            manager.AddTeacher(teacher1);
            manager.AddTeacher(teacher2);

            OnlineCourse onlineCourse = new OnlineCourse(
                "Основы ООП", 
                "C001", 
                "Zoom", 
                "https://zoom.us/example"
            );

            OfflineCourse offlineCourse = new OfflineCourse(
                "Физика", 
                "C002", 
                "2333", 
                "Кронверский пр.49"
            );

            manager.AddCourse(onlineCourse);
            manager.AddCourse(offlineCourse);

            manager.AssignTeacher("T001", "C001");
            manager.AssignTeacher("T002", "C002");

            Student student1 = new Student("Сидоров Сергей", "S001");
            Student student2 = new Student("Смирнова Анна", "S002");
            Student student3 = new Student("Козлов Дмитрий", "S003");

            onlineCourse.AddStudent(student1);
            onlineCourse.AddStudent(student2);
            offlineCourse.AddStudent(student1);
            offlineCourse.AddStudent(student3);

            manager.DisplayAllCourses();

            Console.WriteLine("\n\nКУРСЫ ПРЕПОДАВАТЕЛЯ Кочубеев Н.С.");
            var teacherCourses = manager.GetTeacherCourses("T001");
            foreach (Course course in teacherCourses)
            {
                course.DisplayInfo();
            }

            Console.WriteLine("\n\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}
