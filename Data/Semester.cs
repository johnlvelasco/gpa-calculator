using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel; 

namespace Data
{
    public class Semester : INotifyPropertyChanged
    {
        /// <summary>
        /// PropertyChanged event handling when a property is changed. 
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged; 
        /// <summary>
        /// Invokes property changed for the given property name. 
        /// </summary>
        /// <param name="propertyName">The name of the property to check for changes.</param>
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); 
        }
        /// <summary>
        /// Grade points used for calculating semester GPA
        /// </summary>
        public int SemesterGradePoints = 0;

        /// <summary>
        /// THe total credit hours for the semester. 
        /// </summary>
        public int TotalCreditHours = 0; 

        /// <summary>
        /// List of Courses in the semester used to calculate Semester GPA. 
        /// </summary>
        public List<Course> Courses = new List<Course>();

        /// <summary>
        /// private backing variable for the name property. 
        /// </summary>
        private string _name = "";

        /// <summary>
        /// Name of the semester. Defaulted by system and changed(set) by user. 
        /// </summary>
        public string Name
        {
            get => _name; 
            set
            {
                if (_name == value) return;
                _name = value;
                OnPropertyChanged(nameof(Name)); 
            }
        }

        /// <summary>
        /// Gets the grade points for the given grade, used in calculating GPA. 
        /// </summary>
        /// <param name="grade">the grade used to determine grade points</param>
        /// <param name="credits">the credits of the course to determine grade points.</param>
        /// <returns>the grade points for the course.</returns>
        public int GetCourseGradePoints(Grade grade, int credits)
        {
            int points = 0; 
            if (grade == Grade.A) points += 4;
            else if (grade == Grade.B) points += 3;
            else if (grade == Grade.C) points += 2;
            else if (grade == Grade.D) points += 1;

            return points * credits; 
        }

        /// <summary>
        /// Calculates the GPA for the current semester. 
        /// </summary>
        /// <returns>The GPA as a double, will be formatted as a two decimal number.</returns>
        public double CalculateSemesterGPA()
        {
            foreach (Course c in Courses)
            {
                TotalCreditHours += c.CreditHours;
                SemesterGradePoints += GetCourseGradePoints(c.LetterGrade, c.CreditHours); 
            }
            if (TotalCreditHours == 0) return 0;
            return SemesterGradePoints / TotalCreditHours; 
        }
    }
}
