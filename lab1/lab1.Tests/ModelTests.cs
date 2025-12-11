using Xunit;
using lab1.Models;

namespace lab1.Tests
{
    public class StudentTests
    {
        [Fact]
        public void Student_PropertiesSet()
        {
            var student = new Student("Петров", "S001");
            Assert.Equal("Петров", student.Name);
            Assert.Equal("S001", student.StudentId);
        }
    }

    public class TeacherTests
    {
        [Fact]
        public void Teacher_PropertiesSet()
        {
            var teacher = new Teacher("Иванов", "T001", "ООП");
            Assert.Equal("Иванов", teacher.Name);
            Assert.Equal("T001", teacher.TeacherId);
            Assert.Equal("ООП", teacher.Specialization);
        }
    }
}
