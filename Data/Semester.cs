using System;
using System.Collections.Generic;
using System.ComponentModel; 

namespace Data
{
    /// <summary>
    /// A semester which contains a Name property, a List of Courses, 
    /// and the total grade points and credit hours. 
    /// </summary>
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
        /// Private backing variable for the semester's grade points.
        /// </summary>
        private int _semesterGradePoints = 0; 

        /// <summary>
        /// Grade points used for calculating semester GPA
        /// </summary>
        public int SemesterGradePoints
        {
            get => _semesterGradePoints; 
            set
            {
                if (value == _semesterGradePoints) return;
                _semesterGradePoints = value;
                OnPropertyChanged(nameof(SemesterGradePoints)); 
            }
        }
        /// <summary>
        /// Private backing variable for the semester's credit hours taken. 
        /// </summary>
        private int _semesterCreditHours = 0; 

        /// <summary>
        /// THe total credit hours for the semester. 
        /// </summary>
        public int SemesterCreditHours
        {
            get => _semesterCreditHours; 
            set
            {
                if (value == _semesterCreditHours) return;
                _semesterCreditHours = value;
                OnPropertyChanged(nameof(SemesterCreditHours)); 
            }
        }

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
    }
}
