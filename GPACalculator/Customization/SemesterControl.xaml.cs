using System;
using System.Collections.Generic;
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
        /// Traverses the tree for the SemesterDisplay parent 
        /// Which should always be the first parent. 
        /// </summary>
        private SemesterDisplay TraverseTreeForSemesterDisplay
        {
            get
            {
                DependencyObject parent = this;
                do
                {
                    parent = LogicalTreeHelper.GetParent(parent);
                }
                while (!(parent is SemesterDisplay || parent is null));
                return (SemesterDisplay)parent; 
            }
        }
        /// <summary>
        /// Gets the semester that is displayed in the control.
        /// </summary>
        public Semester GetSemester { get; }

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
            semester.Courses = Courses; 
            GetSemester = semester; 
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
            CoursesStackPanel.Children.Insert(CoursesStackPanel.Children.Count-1, new CourseControl(c));
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
            foreach (UIElement element in CoursesStackPanel.Children)
            {
                if (element is Button) break;
                CourseControl cc = element as CourseControl; 
                Course newCourse = new Course(cc.CourseName, cc.CourseCreditHours, cc.CourseGrade);
                newList.Add(newCourse); 
            }
            Courses = newList;
            GetSemester.Courses = Courses;
        }

        /// <summary>
        /// Removes the current semester from the SemesterDisplay control parent.
        /// </summary>
        /// <param name="sender">the SemesterControl UserControl</param>
        /// <param name="e">The Remove Semester Button</param>
        private void RemoveSemester(object sender, RoutedEventArgs e)
        {
            SemesterDisplay sd = TraverseTreeForSemesterDisplay;
            if (sd == null) throw new Exception("TraverseForSemesterDisplay was null in SemesterControl.cs");

            UpdateCourses(); 
            foreach(UIElement element in sd.SemesterStackPanel.Children)
            {
                SemesterControl sc = element as SemesterControl;
                Semester sem = sc.GetSemester; 
                if (sem.Name.Equals(GetSemester.Name))
                {
                    sd.SemesterStackPanel.Children.Remove(element);
                    break;
                }
            }
        }

        /// <summary>
        /// Text Changed Event Handler that handles when a user updates the name of the semester
        /// </summary>
        /// <param name="sender">the semester name text box.</param>
        /// <param name="args">event args for a text changed event.</param>
        private void SemesterNameChangedEventHandler(object sender, TextChangedEventArgs args)
        {
            GetSemester.Name = SemesterLabel.Text; 
        }
    }
}
