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
            if (semester.Courses.Count > 0)
            {
                foreach (Course course in semester.Courses)
                {
                    AddExistingCourse(course); 
                }
                
                return;
            }
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
        /// <param name="sender">The AddNewCourse button</param>
        /// <param name="e">Click event when a user selects the button.</param>
        public void AddCourse(object sender, RoutedEventArgs e)
        {
            AddNewCourse();
        }

        /// <summary>
        /// Simplifies the Adding New Course button and adds a new blank course to the Courses list and the stackpanel. 
        /// </summary>
        private void AddNewCourse()
        {
            Course course = new Course("", 0, Grade.A);
            Courses.Add(course);
            CoursesStackPanel.Children.Insert(CoursesStackPanel.Children.Count-1, new CourseControl(course));
        }
        /// <summary>
        /// Adds an Existing course to the courses list and stackpanel. 
        /// Used when loading a student. 
        /// /// </summary>
        private void AddExistingCourse(Course course)
        {
            Courses.Add(course);
            CourseControl courseControl = new CourseControl(course); 
            courseControl.courseNameText.Text = course.CourseName;

            if (course.CreditHours == 0)
            {
                courseControl.courseCreditHoursText.Text = "";
                courseControl.courseGradeComboBox.SelectedItem = -1; 
            }
            else
            {
                courseControl.courseCreditHoursText.Text = course.CreditHours.ToString();
                //courseControl.courseGradeComboBox.SelectedValue = "A"; 
                //courseControl.courseGradeComboBox.SelectedItem = GradeToString(course.LetterGrade);
                courseControl.courseGradeComboBox.SelectedIndex = (int)course.LetterGrade; 
            }

            CoursesStackPanel.Children.Insert(CoursesStackPanel.Children.Count - 1, courseControl);
        }

        /// <summary>
        /// Converts the grade into a string for the ComboBox to read.
        /// </summary>
        /// <param name="grade">The grade to convert.</param>
        /// <returns>a string for the grade.</returns>
        public string GradeToString(Grade grade)
        {
            if (grade == Grade.A)
                return "A";
            else if (grade == Grade.B)
                return "B";
            else if (grade == Grade.C)
                return "C";
            else if (grade == Grade.D)
                return "D";
            else
                return "F";
        }

        /// <summary>
        /// Removes the course from the course list. 
        /// </summary>
        /// <param name="courseToRemove">the course to remove.</param>
        /// <returns>true if the course is removed, false otherwise</returns>
        public bool RemoveCourse(Course courseToRemove)
        {
            foreach (CourseControl courseControl in CoursesStackPanel.Children)
            {
                if (courseControl.CourseName.Equals(courseToRemove.CourseName) &&
                    courseControl.CourseCreditHours == courseToRemove.CreditHours &&
                    courseControl.CourseGrade == courseToRemove.LetterGrade)
                { 
                    CoursesStackPanel.Children.Remove(courseControl);
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
            SemesterDisplay semesterDisplay = TraverseTreeForSemesterDisplay;
            if (semesterDisplay == null) throw new Exception("TraverseForSemesterDisplay was null in SemesterControl.cs");

            UpdateCourses(); 
            foreach(UIElement element in semesterDisplay.SemesterStackPanel.Children)
            {
                SemesterControl semesterControl = element as SemesterControl;
                semesterDisplay.SemesterControls.Remove(semesterControl); 
                Semester sem = semesterControl.GetSemester; 
                if (sem.Name.Equals(GetSemester.Name))
                {
                    semesterDisplay.SemesterStackPanel.Children.Remove(element);
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
            if (GetSemester == null) return; 
            GetSemester.Name = SemesterLabel.Text;
        }
    }
}
