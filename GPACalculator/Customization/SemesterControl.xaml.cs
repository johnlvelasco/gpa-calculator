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
        public List<Course> Courses = new List<Course>();

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
            Course c = new Course("", 0, Grade.A);
            Courses.Add(c);
            CoursesStackPanel.Children.Add(new CourseControl(c));
        }

        /// <summary>
        /// Removes the course from the course list. 
        /// </summary>
        /// <param name="courseToRemove">the course to remove.</param>
        /// <returns>true if the course is removed, false otherwise</returns>
        public bool RemoveCourse(Course courseToRemove)
        {
            foreach (CourseControl cc in CoursesStackPanel.Children)
            {
                if (cc.CourseName.Equals(courseToRemove.CourseName) &&
                    cc.CourseCreditHours == courseToRemove.CreditHours &&
                    cc.CourseGrade == courseToRemove.LetterGrade)
                { 
                    CoursesStackPanel.Children.Remove(cc);
                    return true;
                }
            }
            return false;
        }                       
        /// <summary>
        /// Updates Courses list for the semester.
        /// </summary>
        public void UpdateCourses()
        {
            List<Course> newList = new List<Course>(); 
            foreach (CourseControl cc in CoursesStackPanel.Children)
            {
                Course newCourse = new Course(cc.CourseName, cc.CourseCreditHours, cc.CourseGrade);
                newList.Add(newCourse); 
            }
            Courses = newList; 
        }
    }
}
