using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Data;
using Newtonsoft.Json;
using System.IO; 

namespace GPACalculator
{
    /// <summary>
    /// Interaction logic for StudentCustomization.xaml
    /// </summary>
    public partial class StudentCustomization : UserControl
    {
        /// <summary>
        /// Traverses the Tree for the MainWindow parent to swap the window. 
        /// </summary>
        public MainWindow TraverseTreeForMainWindow
        {
            get
            {
                DependencyObject parent = this;
                do
                {
                    parent = LogicalTreeHelper.GetParent(parent);
                }
                while (!(parent is MainWindow || parent is null));
                return parent as MainWindow;
            }
        }

        /// <summary>
        /// Constructs a new Student Customization Control for customizing a new or existing student's GPA. 
        /// </summary>
        public StudentCustomization(Student student)
        {
            InitializeComponent();
            if (student.SemestersTaken.Count > 0) LoadStudent(student);
        }
        /// <summary>
        /// Loads an existing student's customization page. 
        /// </summary>
        /// <param name="student">The existing student to upload.</param>
        private void LoadStudent(Student student)
        {
            StudentNameTextBox.Text = student.FullName;
            textGPADisplay.Text = student.GPA.ToString("0.0"); 
            SemesterDisplay sd = SemesterDisplayBorder.Child as SemesterDisplay;
            sd.Semesters.Clear(); 
            sd.SemesterControls.Clear();
            sd.SemesterStackPanel.Children.Clear(); 
            foreach (Semester sem in student.SemestersTaken)
            {
                SemesterControl sc = new SemesterControl(sem);
                sc.SemesterLabel.Text = sem.Name; 
                sd.SemesterControls.Add(sc);
                sd.SemesterStackPanel.Children.Add(sc);
                sd.Semesters.Add(sem); 
            }
        }

        /// <summary>
        /// Completes the student, sending its new information to a database/text doc.
        /// Should implement some form of encryption method to safeguard information. 
        /// </summary>
        /// <param name="sender">Student Customization UserControl.</param>
        /// <param name="e">The Complete Student button.</param>
        private void CompleteStudent(object sender, RoutedEventArgs e)
        {
            Student student = DataContext as Student;
            student.FullName = StudentNameTextBox.Text;
            CalculateGPA(sender, e);
            UpdateSemestersTaken();
            SemesterDisplay sd = SemesterDisplayBorder.Child as SemesterDisplay;
            sd.UpdateSemestersTaken(); 

            MainWindow main = TraverseTreeForMainWindow;
            main.Students.Add(student);
            main.UpdateJSON(); 
            main.MainWindowBorder.Child = new StudentSelection(); 
        }

        /// <summary>
        /// Gets the grade points for the given grade, used in calculating GPA. 
        /// </summary>
        /// <param name="grade">the grade used to determine grade points</param>
        /// <param name="credits">the credits of the course to determine grade points.</param>
        /// <returns>the grade points for the course.</returns>
        public double GetCourseGradePoints(Grade grade, int credits)
        {
            int points = 0;
            if (grade == Grade.A) points += 4;
            else if (grade == Grade.B) points += 3;
            else if (grade == Grade.C) points += 2;
            else if (grade == Grade.D) points += 1;

            return points * credits;
        }
        /// <summary>
        /// Updates the GPA Display on the Student Customization screen.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculateGPA(object sender, RoutedEventArgs e)
        {
            Student student = DataContext as Student; 
            double creditHoursTaken = 0;
            double gradePoints = 0;
            SemesterDisplay sd = SemesterDisplayBorder.Child as SemesterDisplay;
            
            if (sd.SemesterStackPanel.Children.Count == 0) return;
            
            foreach (UIElement element in sd.SemesterStackPanel.Children)
            {
                SemesterControl sc = element as SemesterControl;
                sc.UpdateCourses(); 
                foreach (Course course in sc.Courses)
                {
                    creditHoursTaken += (double)course.CreditHours;
                    gradePoints += GetCourseGradePoints(course.LetterGrade, course.CreditHours);
                }
            }
            if (creditHoursTaken == 0)
            {
                student.GPA = 0.0;
                textGPADisplay.Text = "0.0"; 
                return; 
            }
            student.TotalGradePoints = (int)gradePoints;
            student.TotalCreditHoursTaken = (int)creditHoursTaken; 
            student.GPA = gradePoints / creditHoursTaken;
            textGPADisplay.Text = student.GPA.ToString("0.0");
        }

        /// <summary>
        /// Updates the List used to track a students semesters taken.
        /// Used for loading an existing student. 
        /// </summary>
        private void UpdateSemestersTaken()
        {
            List<Semester> semesters = new List<Semester>();
            SemesterDisplay sd = SemesterDisplayBorder.Child as SemesterDisplay;

            foreach (UIElement element in sd.SemesterStackPanel.Children)
            {
                SemesterControl sc = element as SemesterControl;
                sc.UpdateCourses(); 
                semesters.Add(sc.GetSemester);
            }
            Student student = DataContext as Student;
            student.SemestersTaken = semesters;
        }
    }
}
