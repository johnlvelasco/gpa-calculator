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
        public SemesterControl(Semester semester)
        {
            InitializeComponent();
            for(int i=0; i<4; i++)
            {
                AddNewCourse();
            }
        }

        /// <summary>
        /// Collection of courses that are in the semester. 
        /// </summary>
        public ObservableCollection<Course> Courses = new ObservableCollection<Course>();

        /// <summary>
        /// Button that handles when a user wants to add a new course to the semester. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void AddCourse(object sender, RoutedEventArgs e)
        {
            AddNewCourse();
        }

        /// <summary>
        /// Simplifies the Adding New Course button . 
        /// </summary>
        private void AddNewCourse()
        {
            Course c = new Course("", 0, 0);
            Courses.Add(c);
            CoursesStackPanel.Children.Add(new CourseControl(c));
        }

        public bool RemoveCourse(CourseControl cc)
        {
            foreach (Course course in Courses)
            {
                if (course.CourseName.Equals(cc.CourseName) &&
                    course.CreditHours.Equals(cc.CourseCreditHours) &&
                    course.LetterGrade.Equals(cc.CourseGrade))
                { 
                    Courses.Remove(course);
                    CoursesStackPanel.Children.Remove(new CourseControl(course));
                    return true;
                }
                
            }
            return false;
        }

    }
}
