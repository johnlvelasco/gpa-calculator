using System;
using Xunit;
using Data;

namespace DataTests
{
    public class CourseTests
    {
        /// <summary>
        /// Ensures that when creating a new course, that all values:
        /// Course name, credit hours, and grade are set. 
        /// </summary>
        [Fact]
        public void CourseSetsAllValuesCorrectly()
        {
            Course course = new Course("Class 1", 3, Grade.A);
            Assert.Equal("Class 1", course.CourseName);
            Assert.Equal(3, course.CreditHours);
            Assert.Equal(Grade.A, course.LetterGrade); 
        }
    }
}
