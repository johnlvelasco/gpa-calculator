using System;
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
        /// <summary>
        /// Traverses the tree for the semester control parent that all course controls have.
        /// </summary>
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
        /// Traverses the tree for the SemesterDisplay parent.
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
                return parent as SemesterDisplay;
            }
        }
        /// <summary>
        /// Event that handles when a property is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// The Semester Display that all courses are nested under. 
        /// </summary>
        private SemesterDisplay SemesterDisplay => TraverseTreeForSemesterDisplay; 

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
            if (SemesterDisplay == null) return;
            SemesterDisplay.UpdateSemestersTaken();
        }
        /// <summary>
        /// Handles when the user changes the number of credit hours for the course. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void CreditHoursChangedEventHandler(object sender, TextChangedEventArgs args)
        {
            if (courseCreditHoursText.Text.Equals("")) return;
            char[] chars = courseCreditHoursText.Text.ToCharArray();

            if (chars[0] > 57 || chars[0] < 48) courseCreditHoursText.Text = "";
            else
            {
                CourseCreditHours = Int32.Parse(chars[0].ToString());
                courseCreditHoursText.Text = chars[0].ToString(); 
            }



            if (SemesterDisplay == null) return;
            SemesterDisplay.UpdateSemestersTaken();

        }
        /// <summary>
        /// Handles when the user changes the Grade for the course. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void GradeChangedEventHandler(object sender, SelectionChangedEventArgs args)
        {
            string grade = ((ComboBoxItem)courseGradeComboBox.SelectedItem).Content.ToString();
            CourseGrade = StringToGrade(grade);
            if (SemesterDisplay == null) return;
            SemesterDisplay.UpdateSemestersTaken();
        }

        /// <summary>
        /// Constructor for the Course Control that displays the Name, Credit Hours, and Grade for the course. 
        /// </summary>
        public CourseControl(Course c)
        {
            InitializeComponent();
            if (c.CreditHours.Equals("0")) courseCreditHoursText.Text = ""; 
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
        private int _courseCreditHours = 0;
        /// <summary>
        /// The Credit Hours for the course. 
        /// Subject to change when user changes value. 
        /// </summary>
        public int CourseCreditHours
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
        private Grade _courseGrade = Grade.A;
        /// <summary>
        /// The Grade for the course
        /// Subject to change when user changes value. 
        /// </summary>
        public Grade CourseGrade
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

        /// <summary>
        /// Deletes the current course from the semester display. 
        /// </summary>
        /// <param name="sender">the red X to delete the course.</param>
        /// <param name="e">event of user clicking delete course button.</param>
        private void DeleteCourseControl(object sender, RoutedEventArgs e)
        {
            SemesterControl semesterControl = TraverseTreeForSemesterControl;
            semesterControl.UpdateCourses(); 
            Course course = new Course(CourseName, CourseCreditHours, CourseGrade);
            semesterControl.RemoveCourse(course); 
        }
    }
}
