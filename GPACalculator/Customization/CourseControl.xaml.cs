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
        private void GradeChangedEventHandler(object sender, TextChangedEventArgs args)
        {
            CourseGrade = courseGradeText.Text; 
        }

        /// <summary>
        /// Constructor for the Course Control that displays the Name, Credit Hours, and Grade for the course. 
        /// </summary>
        public CourseControl(Course c)
        {
            InitializeComponent();
            CourseName = c.CourseName;
            courseNameText.Text = CourseName; 
            
            CourseCreditHours = c.CreditHours.ToString();
            if (CourseCreditHours.Equals("0")) courseCreditHoursText.Text = ""; 
            else courseCreditHoursText.Text = CourseCreditHours; 
            
            CourseGrade = c.LetterGrade.ToString();
            courseGradeText.Text = CourseGrade; 

        }
        /// <summary>
        /// Private backing variable for the name of the Course
        /// </summary>
        private string _courseName; 
        /// <summary>
        /// The name of the course, subject to change when user edits textbox. 
        /// </summary>
        public string CourseName
        {
            get => _courseName; 
            set
            {
                if (_courseName == value) return;
                _courseName = value;
                OnPropertyChanged(nameof(CourseName));
            }
        }
        /// <summary>
        /// Private backing variable for the Course's credit hours.
        /// </summary>
        private string _courseCreditHours;
        /// <summary>
        /// The Credit Hours for the course. 
        /// Subject to change when user changes value. 
        /// </summary>
        public string CourseCreditHours
        {
            get => _courseCreditHours;
            set
            {
                if (_courseCreditHours == value) return;
                _courseCreditHours = value;
                OnPropertyChanged(nameof(CourseCreditHours)); 
            }
        }
        /// <summary>
        /// Private backing variable for the Course's Grade.
        /// </summary>
        private string _courseGrade;
        /// <summary>
        /// The Grade for the course
        /// Subject to change when user changes value. 
        /// </summary>
        public string CourseGrade
        {
            get => _courseGrade; 
            set
            {
                if (_courseGrade == value) return;
                _courseGrade = value;
                OnPropertyChanged(nameof(CourseGrade)); 
            }
        }
        /// <summary>
        /// Deletes the current course from the semester display. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DeleteCourseControl(object sender, RoutedEventArgs e)
        {
            //delete this course from control, so make a method inside of the semester control,
            //that deletes the requested course. 
            SemesterControl semesterControl = TraverseTreeForSemesterControl;
            CourseControl cc = sender as CourseControl;

            semesterControl.RemoveCourse(cc); 

        }
    }
}
