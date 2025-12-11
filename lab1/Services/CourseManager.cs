using System;
using System.Collections.Generic;
using lab1.Models;

namespace lab1.Services
{
    public class CourseManager

    {
        private List<Course> courses;
        private List<Teacher> teachers;

        public List<Course> Courses
        {
            get { return courses; }
        }

        public List<Teacher> Teachers
        {
            get { return teachers; }
        }

        public CourseManager()
        {
            courses = new List<Course>();
            teachers = new List<Teacher>();
        }

        public void AddCourse(Course course)
        {
            courses.Add(course);
        }

        public void RemoveCourse(string courseId)
        {
            Course course = courses.Find(c => c.CourseId == courseId);
            if (course != null)
            {
                courses.Remove(course);
            }
        }

        public void AddTeacher(Teacher teacher)
        {
            teachers.Add(teacher);
        }

        public void AssignTeacher(string teacherId, string courseId)
        {
            Teacher teacher = teachers.Find(t => t.TeacherId == teacherId);
            Course course = courses.Find(c => c.CourseId == courseId);

            if (teacher != null && course != null)
            {
                course.AssignedTeacher = teacher;
            }
        }

        public List<Course> GetTeacherCourses(string teacherId)
        {
            List<Course> result = new List<Course>();

            foreach (Course course in courses)
            {
                if (course.AssignedTeacher != null && course.AssignedTeacher.TeacherId == teacherId)
                {
                    result.Add(course);
                }
            }

            return result;
        }

        public void DisplayAllCourses()
        {
            Console.WriteLine("\nВСЕ КУРСЫ");
            foreach (Course course in courses)
            {
                course.DisplayInfo();
            }
        }
    }
}
