using System;
using System.ComponentModel;
using Xunit;
using Data; 

namespace DataTests
{
    /// <summary>
    /// Testing class for the Semester.cs class in Data
    /// </summary>
    public class SemesterTests
    {
        /// <summary>
        /// Checks if the Semester.cs class implements the property changed event handler.
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyPropertyChanged()
        {
            var semester = new Semester();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(semester);
        }
        /// <summary>
        /// Checks that the default value for name is correct.
        /// </summary>
        [Fact]
        public void NameShouldBeCorrect()
        {
            var semester = new Semester();
            Assert.Equal("", semester.Name);
        }
        /// <summary>
        /// Checks whether the Property Name is set.
        /// </summary>
        [Fact]
        public void ShouldBeAbleToSetName()
        {
            var semester = new Semester();
            semester.Name = "test";
            Assert.Equal("test", semester.Name);
        }
        /// <summary>
        /// Ensures that the List containing the semester's courses is initially empty.
        /// </summary>
        [Fact]
        public void CoursesShouldBeEmpty()
        {
            var semester = new Semester();
            Assert.Empty(semester.Courses);
        }
        /// <summary>
        /// Checks if the intial value of total credit hours is correct.
        /// </summary>
        [Fact]
        public void TotalCreditHoursShouldBeCorrect()
        {
            var semester = new Semester();
            Assert.Equal(0, semester.TotalCreditHours);
        }
    }
}
