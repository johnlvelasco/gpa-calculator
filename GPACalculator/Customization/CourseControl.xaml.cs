using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.ComponentModel;
using Data; 

namespace GPACalculator
{
    /// <summary>
    /// Interaction logic for CourseControl.xaml
    /// </summary>
    public partial class CourseControl : UserControl, INotifyPropertyChanged
    {
        private SemesterControl TraverseTreeForSemesterControl
        {
            get
            {
                DependencyObject parent = this;
                do
                {
                    parent = LogicalTreeHelper.GetParent(parent); 
                }
                while (!(parent is SemesterControl || parent is null));
                return parent as SemesterControl;
            }
        }

        /// <summary>
        /// Event that handles when a property is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged; 

        /// <summary>
        /// Notifies of a property change for the given property name. 
        /// </summary>
        /// <param name="propertyName">Name of the property to check for the change.</param>
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); 
        }
        /// <summary>
        /// Handles when the user changes the name of the course. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void NameChangedEventHandler(object sender, TextChangedEventArgs args)
        {
            CourseName = courseNameText.Text;

        }
        /// <summary>
        /// Handles when the user changes the number of credit hours for the course. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void CreditHoursChangedEventHandler(object sender, TextChangedEventArgs args)
        {
            CourseCreditHours = courseCreditHoursText.Text;
        }
        /// <summary>
        /// Handles when the user changes the Grade for the course. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void GradeChangedEventHandler(object sender, SelectionChangedEventArgs args)
        {
            CourseGrade = courseGradeComboBox.SelectedItem.ToString(); 
        }

        /// <summary>
        /// Constructor for the Course Control that displays the Name, Credit Hours, and Grade for the course. 
        /// </summary>
        public CourseControl(Course c)
        {
            InitializeComponent();
            if (c.CreditHours.Equals("0")) courseCreditHoursText.Text = ""; 
            //else courseCreditHoursText.Text = c.CreditHours.ToString(); 
        }
        /// <summary>
        /// Private backing variable for the name of the Course
        /// </summary>
        private string _courseName = ""; 
        /// <summary>
        /// The name of the course, subject to change when user edits textbox. 
        /// </summary>
        public string CourseName
        {
            get => _courseName; 
            set
            {
                if (_courseName.Equals(value)) return;
                _courseName = value;
                OnPropertyChanged(nameof(CourseName));
            }
        }
        /// <summary>
        /// Private backing variable for the Course's credit hours.
        /// </summary>
        private string _courseCreditHours = "";
        /// <summary>
        /// The Credit Hours for the course. 
        /// Subject to change when user changes value. 
        /// </summary>
        public string CourseCreditHours
        {
            get => _courseCreditHours;
            set
            {
                if (_courseCreditHours.Equals(value)) return;
                _courseCreditHours = value;
                OnPropertyChanged(nameof(CourseCreditHours)); 
            }
        }
        /// <summary>
        /// Private backing variable for the Course's Grade.
        /// </summary>
        private string _courseGrade = "";
        /// <summary>
        /// The Grade for the course
        /// Subject to change when user changes value. 
        /// </summary>
        public string CourseGrade
        {
            get => _courseGrade;
            set
            {
                if (_courseGrade.Equals(value)) return;
                _courseGrade = value;
                OnPropertyChanged(nameof(CourseGrade)); 
            }
        }
        /// <summary>
        /// Converts the CourseGrade from a string to a Grade.
        /// </summary>
        /// <param name="s">string to convert.</param>
        /// <returns>A Grade for the string retrieved. </returns>
        public Grade StringToGrade(string s)
        {
            if (s.Equals("A"))
                return Grade.A;
            else if (s.Equals("B"))
                return Grade.B;
            else if (s.Equals("C"))
                return Grade.C;
            else if (s.Equals("D"))
                return Grade.D;
            else
                return Grade.F; 
        }

        public int StringToCreditHours(string s)
        {
            if (String.IsNullOrEmpty(s))
                return 0;
            else
                return Int32.Parse(s); 
        }

        /// <summary>
        /// Deletes the current course from the semester display. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteCourseControl(object sender, RoutedEventArgs e)
        {
            SemesterControl semesterControl = TraverseTreeForSemesterControl;
            semesterControl.UpdateCourses(); 
            Course course = new Course(CourseName, StringToCreditHours(CourseCreditHours), StringToGrade(CourseGrade));
            semesterControl.RemoveCourse(course); 
            
        }
    }
}
