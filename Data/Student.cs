using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Data
{
    public class Student : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged; 

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); 
        }
        /// <summary>
        /// List containing all courses taken by a Student.
        /// SHOULD RESEARCH MORE ABOUT STRUCTURES FOR THIS.
        /// </summary>
        public List<Semester> SemestersTaken = new List<Semester>();

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

        private int _totalCreditsTaken; 
        /// <summary>
        /// Field to keep track of credits taken by the student in a semester. 
        /// </summary>
        public int TotalCreditsTaken
        {
            get => _totalCreditsTaken; 
            set
            {
                if (_totalCreditsTaken == value) return;
                _totalCreditsTaken = value;
                OnPropertyChanged(nameof(TotalCreditsTaken)); 
            }
        }

        private string _firstName;
        /// <summary>
        /// Gets the first name of the student.
        /// Is set within the constructor. 
        /// </summary>
        public string FirstName
        {
            get => _firstName;
            set
            {
                if (_firstName == value) return;
                _firstName = value;
                OnPropertyChanged(nameof(FirstName)); 
            }
        }

        private string _lastName; 
        /// <summary>
        /// Gets the last name of the student. 
        /// Is set within the constructor. 
        /// </summary>
        public string LastName
        {
            get => _lastName; 
            set
            {
                if (_lastName == value) return;
                _lastName = value;
                OnPropertyChanged(nameof(LastName)); 
            }
        }

        /// <summary>
        /// Returns the full name of the student, combining the first and last name. 
        /// </summary>
        public string FullName
        {
            get => FirstName + " " + LastName; 
        }


        /// <summary>
        /// The School Year standing that the student is.
        /// </summary>
        public SchoolYear Standing
        {
            get
            {
                if (TotalCreditsTaken < 30)
                {
                    return SchoolYear.Freshman; 
                }
                else if (TotalCreditsTaken < 60)
                {
                    return SchoolYear.Sophomore;
                }
                else if (TotalCreditsTaken < 90)
                {
                    return SchoolYear.Junior; 
                }
                else
                {
                    return SchoolYear.Senior; 
                }
            }
        }
        /// <summary>
        /// Constructor for a new Student. Setting the first and last name. 
        /// </summary>
        /// <param name="first">the student's first name</param>
        /// <param name="last">the student's last name</param>
        public Student()
        {

        }         

        /// <summary>
        /// Calculates the GPA for the student by iterating through its taken semesters list. 
        /// </summary>
        /// <returns>A two decimal GPA for all semesters taken.</returns>
        public double CalculateStudentGPA()
        {
            return 0; 
        }
    }
}
