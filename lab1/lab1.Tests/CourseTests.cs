using Xunit;
using lab1.Models;

namespace lab1.Tests
{
    public class CourseTests
    {
        [Fact]
        public void AddStudent_ValidStudent_StudentAdded()
        {
            var course = new OnlineCourse("ООП", "C001", "Zoom", "https://link");
            var student = new Student("Петров", "S001");
            course.AddStudent(student);
            Assert.Single(course.Students);
        }

        [Fact]
        public void RemoveStudent_StudentRemoved()
        {
            var course = new OnlineCourse("ООП", "C001", "Zoom", "https://link");
            var student = new Student("Петров", "S001");
            course.AddStudent(student);
            course.RemoveStudent(student);
            Assert.Empty(course.Students);
        }

        [Fact]
        public void OnlineCourse_HasCorrectProperties()
        {
            var course = new OnlineCourse("ООП", "C001", "Zoom", "https://link");
            Assert.Equal("Zoom", course.Platform);
            Assert.Equal("https://link", course.Link);
        }

        [Fact]
        public void OfflineCourse_HasCorrectProperties()
        {
            var course = new OfflineCourse("Физика", "C002", "305", "Главный");
            Assert.Equal("305", course.Classroom);
            Assert.Equal("Главный", course.Building);
        }
    }
}
