using System;
using System.ComponentModel;
using Xunit;
using Data;

namespace DataTests
{
    /// <summary>
    /// Testing for the Student.cs class
    /// </summary>
    public class StudentTests
    {
        /// <summary>
        /// Ensures the PropertyChanged is assignable in the Student class.
        /// </summary>
        [Fact]
        public void ShouldImplementINotifyPropertyChanged()
        {
            var student = new Student();
            Assert.IsAssignableFrom<INotifyPropertyChanged>(student);
        }
        /// <summary>
        /// Ensures that the SemestersTaken List is intially empty.
        /// </summary>
        [Fact]
        public void SemestersTakenShouldBeEmpty()
        {
            var student = new Student();
            Assert.Empty(student.SemestersTaken); 
        }
        /// <summary>
        /// Ensures the inital value of GPA is correct.
        /// </summary>
        [Fact]
        public void GPAShouldReturnCorrectValue()
        {
            var student = new Student();
            Assert.Equal(0, student.GPA); 
        } 
        /// <summary>
        /// Checks if the GPA property is able to be set.
        /// </summary>
        [Fact]
        public void ShouldBeAbleToSetGPA()
        {
            var student = new Student();
            student.GPA = 3.3;
            Assert.Equal(3.3, student.GPA); 
        }
        /// <summary>
        /// Ensures the intial value of TotalCreditsTaken is correct.
        /// </summary>
        [Fact]
        public void TotalCreditsTakenShouldReturnCorrectValue()
        {
            var student = new Student();
            Assert.Equal(0, student.TotalCreditHoursTaken); 
        }
        /// <summary>
        /// Ensures the value of FullName is correct.
        /// </summary>
        [Fact]
        public void FullNameShouldReturnCorrectValue()
        {
            var student = new Student();
            Assert.Equal("", student.FullName); 
        }
        /// <summary>
        /// Ensures the value of FullName is correct.
        /// </summary>
        [Fact]
        public void ShouldBeAbleToSetFullName()
        {
            var student = new Student();
            student.FullName = "John Doe"; 
            Assert.Equal("John Doe", student.FullName);
        }
        /// <summary>
        /// Checks whether the Standing property returns the correct schoolyear for the credithours set.
        /// </summary>
        /// <param name="credits">Credit hours to set.</param>
        /// <param name="expectedYear">The expected SchoolYear standing.</param>
        [Theory]
        [InlineData(0, SchoolYear.Freshman)]
        [InlineData(30, SchoolYear.Sophomore)]
        [InlineData(60, SchoolYear.Junior)]
        [InlineData(90, SchoolYear.Senior)]
        public void StandingShouldReturnCorrectValue(int credits, SchoolYear expectedYear)
        {
            var student = new Student();
            student.TotalCreditHoursTaken = credits;
            Assert.Equal(expectedYear, student.Standing); 
        }

    }
}
