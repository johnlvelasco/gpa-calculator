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
            Course c = new Course("", 0, 0);
            Courses.Add(c);
            CoursesStackPanel.Children.Add(new CourseControl(c));
        }

        public bool RemoveCourse(Course courseToRemove)
        {
            foreach (Course course in Courses)
            {
                if (course.CourseName.Equals(courseToRemove.CourseName) &&
                    course.CreditHours.Equals(courseToRemove.CreditHours) &&
                    course.LetterGrade.Equals(courseToRemove.LetterGrade))
                { 
                    Courses.Remove(course);
                    CoursesStackPanel.Children.Remove(new CourseControl(course));
                    return true;
                }
                
            }
            return false;
        }

        public void UpdateCourses()
        {
            List<Course> oldList = Courses;
            List<Course> newList = new List<Course>(); 
            foreach (CourseControl cc in CoursesStackPanel.Children)
            {
                foreach(Course course in oldList)
                {
                    if (cc.CourseName.Equals(course.CourseName) &&
                        cc.CourseCreditHours.Equals(course.CreditHours.ToString()) &&
                        cc.CourseGrade.Equals(course.LetterGrade.ToString()))
                    {
                        Course newCourse = new Course(cc.courseNameText.Text,
                            cc.StringToCreditHours(cc.courseCreditHoursText.Text),
                            cc.StringToGrade(cc.courseGradeComboBox.Text));
                        newList.Add(newCourse);
                        break;
                    }
                }
            }
            Courses = newList; 
        }


    }
}
