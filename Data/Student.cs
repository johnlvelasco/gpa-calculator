using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Data
{
    public class Student : INotifyPropertyChanged
    {
        /// <summary>
        /// Handles when a property is changed, needs to be invoked.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged; 
        /// <summary>
        /// Invokes the propertychanged event handler using the name of the property that was changed. 
        /// </summary>
        /// <param name="propertyName">the name of the property.</param>
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); 
        }
        /// <summary>
        /// List containing all courses taken by a Student.
        /// SHOULD RESEARCH MORE ABOUT STRUCTURES FOR THIS.
        /// </summary>
        public List<Semester> SemestersTaken = new List<Semester>();

        /// <summary>
        /// Field to keep track of the grade points used to calculate GPA.
        /// </summary>
        public int TotalGradePoints = 0; 

        /// <summary>
        /// Field to keep track of credits taken by the student in a semester. 
        /// </summary>
        public int TotalCreditHoursTaken = 0;

        /// <summary>
        /// Private backing variable for gpa
        /// </summary>
        private double _gpa; 

        /// <summary>
        /// The Student's Cumulative GPA. 
        /// </summary>
        public double GPA
        {
            get => _gpa; 
            set
            {
                if (_gpa == value) return;
                _gpa = value;
                OnPropertyChanged(nameof(GPA)); 
            }
        }
        /// <summary>
        /// Private backing variable for the Student's name. 
        /// </summary>
        private string _fullName = ""; 

        /// <summary>
        /// Returns the full name of the student, combining the first and last name. 
        /// </summary>
        public string FullName
        {
            get => _fullName; 
            set
            {
                if (value == _fullName) return;
                _fullName = value;
                OnPropertyChanged(FullName); 
            }
        }

        /// <summary>
        /// The School Year standing that the student is.
        /// </summary>
        public SchoolYear Standing
        {
            get
            {
                if (TotalCreditHoursTaken < 30)
                {
                    return SchoolYear.Freshman; 
                }
                else if (TotalCreditHoursTaken < 60)
                {
                    return SchoolYear.Sophomore;
                }
                else if (TotalCreditHoursTaken < 90)
                {
                    return SchoolYear.Junior; 
                }
                else
                {
                    return SchoolYear.Senior; 
                }
            }
        }
    }
}
