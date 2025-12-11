using Xunit;
using lab1.Models;
using lab1.Services;

namespace lab1.Tests
{
    public class CourseManagerTests
    {
        [Fact]
        public void AddCourse_CourseAdded()
        {
            var manager = new CourseManager();
            var course = new OnlineCourse("ООП", "C001", "Zoom", "link");
            manager.AddCourse(course);
            Assert.Single(manager.Courses);
        }

        [Fact]
        public void RemoveCourse_CourseRemoved()
        {
            var manager = new CourseManager();
            var course = new OnlineCourse("ООП", "C001", "Zoom", "link");
            manager.AddCourse(course);
            manager.RemoveCourse("C001");
            Assert.Empty(manager.Courses);
        }

        [Fact]
        public void AssignTeacher_TeacherAssigned()
        {
            var manager = new CourseManager();
            var teacher = new Teacher("Иванов", "T001", "ООП");
            var course = new OnlineCourse("ООП", "C001", "Zoom", "link");
            manager.AddTeacher(teacher);
            manager.AddCourse(course);
            manager.AssignTeacher("T001", "C001");
            Assert.Equal("T001", course.AssignedTeacher.TeacherId);
        }

        [Fact]
        public void GetTeacherCourses_ReturnsCourses()
        {
            var manager = new CourseManager();
            var teacher = new Teacher("Иванов", "T001", "ООП");
            var course1 = new OnlineCourse("ООП", "C001", "Zoom", "link");
            var course2 = new OfflineCourse("Физика", "C002", "305", "Главный");
            manager.AddTeacher(teacher);
            manager.AddCourse(course1);
            manager.AddCourse(course2);
            manager.AssignTeacher("T001", "C001");
            manager.AssignTeacher("T001", "C002");
            var courses = manager.GetTeacherCourses("T001");
            Assert.Equal(2, courses.Count);
        }
    }
}
