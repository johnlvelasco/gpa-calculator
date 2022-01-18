using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Data; 

namespace GPACalculator
{
    /// <summary>
    /// Interaction logic for DisplayStudentControl.xaml
    /// </summary>
    public partial class DisplayStudentControl : UserControl
    {
        /// <summary>
        /// Constructor for displaying a student control, setting all text properties for the textblocks.
        /// </summary>
        /// <param name="student">The student to display.</param>
        public DisplayStudentControl(Student student)
        {
            InitializeComponent();
            Student = student;
            textStudentName.Text = student.FullName;
            textStudentCreditHours.Text = student.TotalCreditHoursTaken.ToString();
            textStudentGPA.Text = student.GPA.ToString("0.0");
        }

        /// <summary>
        /// The student used in the displaycontrol. 
        /// </summary>
        public Student Student { get; }

        

        
    }
}
