using System;
using System.Collections.Generic;

namespace Data
{
    public class Student
    {
        /// <summary>
        /// List containing all courses taken by a Student.
        /// SHOULD RESEARCH MORE ABOUT STRUCTURES FOR THIS.
        /// </summary>
        public List<Semester> SemestersTaken = new List<Semester>();

        /// <summary>
        /// The Student's Cumulative GPA. 
        /// </summary>
        public double GPA { get; set; }

        /// <summary>
        /// Field to keep track of credits taken by the student in a semester. 
        /// </summary>
        public int TotalCreditsTaken { get; set; }

        /// <summary>
        /// Gets the first name of the student.
        /// Is set within the constructor. 
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// Gets the last name of the student. 
        /// Is set within the constructor. 
        /// </summary>
        public string LastName { get; }

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
        public Student(string first, string last)
        {
            FirstName = first;
            LastName = last;
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
