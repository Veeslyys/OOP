using System;
using System.Collections.Generic;

namespace lab1.Models
{
    // Абстрактный класс с инкапсуляцией
    public abstract class Course
    {
        private string courseName;
        private string courseId;
        private Teacher assignedTeacher;
        private List<Student> students;

        public string CourseName
        {
            get { return courseName; }
            set { courseName = value; }
        }

        public string CourseId
        {
            get { return courseId; }
            set { courseId = value; }
        }

        public Teacher AssignedTeacher
        {
            get { return assignedTeacher; }
            set { assignedTeacher = value; }
        }

        public List<Student> Students
        {
            get { return students; }
        }

        public Course(string courseName, string courseId)
        {
            this.courseName = courseName;
            this.courseId = courseId;
            this.students = new List<Student>();
            this.assignedTeacher = null;
        }

        public void AddStudent(Student student)
        {
            if (student != null)
            {
                students.Add(student);
            }
        }

        public void RemoveStudent(Student student)
        {
            students.Remove(student);
        }

        public abstract void DisplayInfo();
    }
}
