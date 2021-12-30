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
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); 
        }
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
        /// List of Courses in the semester used to calculate Semester GPA. 
        /// </summary>
        public List<Course> Courses = new List<Course>();

        /// <summary>
        /// private backing variable for the semester's total credit hours
        /// </summary>
        private int _totalCreditHours; 

        /// <summary>
        /// THe total credit hours for the semester. 
        /// </summary>
        public int TotalCreditHours
        {
            get => _totalCreditHours;
            set
            {
                if (_totalCreditHours == value) return;
                _totalCreditHours = value;
                OnPropertyChanged(nameof(TotalCreditHours));
            }
        }
        /// <summary>
        /// Calculates the GPA for the current semester. 
        /// </summary>
        /// <returns>The GPA as a double, will be formatted as a two decimal number.</returns>
        public double CalculateSemesterGPA()
        {
            return 0; 
        }
    }
}
