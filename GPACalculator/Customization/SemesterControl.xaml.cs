using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Data;

namespace GPACalculator
{
    /// <summary>
    /// Interaction logic for SemesterControl.xaml
    /// </summary>
    public partial class SemesterControl : UserControl
    {
        /// <summary>
        /// Constructor for the Semester Control that displays all courses in the collection. 
        /// </summary>
        public SemesterControl()
        {
            InitializeComponent();
            if (Courses.Count > 0)
            {
                DisplayCourses();   
            }
        }

        /// <summary>
        /// Collection of courses that are in the semester. 
        /// </summary>
        public ObservableCollection<Course> Courses = new ObservableCollection<Course>();

        public void DisplayCourses()
        {
            foreach(Course course in Courses)
            {
                CourseControl courseControl = new CourseControl(course);
                CoursesStackPanel.Children.Add(courseControl);
            }
        }


    }
}
