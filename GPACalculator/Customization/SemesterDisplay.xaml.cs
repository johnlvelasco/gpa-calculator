using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Data;

namespace GPACalculator
{
    /// <summary>
    /// Interaction logic for SemesterDisplay.xaml
    /// </summary>
    public partial class SemesterDisplay : UserControl
    {
        /// <summary>
        /// Traverses the tree for the StudentCustomization parent. 
        /// </summary>
        public StudentCustomization TraverseTreeForStudentCustomization 
        {
            get
            {
                DependencyObject parent = this;
                do
                {
                    parent = LogicalTreeHelper.GetParent(parent);
                }
                while (!(parent is StudentCustomization || parent is null));
                return (StudentCustomization)parent; 
            }
        }

        /// <summary>
        /// Collection of semesters to display as Controls on the Listview. 
        /// </summary>
        public List<Semester> Semesters = new List<Semester>();

        /// <summary>
        /// Collection of SemesterControls used in the SemesterDisplay.
        /// </summary>
        public List<SemesterControl> SemesterControls = new List<SemesterControl>(); 

        /// <summary>
        /// Constructor for the semester display control. 
        /// </summary>
        public SemesterDisplay()
        {
            InitializeComponent();            
            Semester semester = new Semester();
            semester.Name = "Semester " + (Semesters.Count + 1).ToString("D1");
            Semesters.Add(semester);

            //Could add to semesters taken when completing the student. 
            DataContext = new Student();
            Student student = DataContext as Student;
            student.SemestersTaken.Add(semester);
            DataContext = student;

            SemesterControl sc = new SemesterControl(semester);
            SemesterControls.Add(sc); 
            sc.SemesterLabel.Text = semester.Name;
            SemesterStackPanel.Children.Add(sc);
        }

        /// <summary>
        /// Updates the SemestersTaken property of the student. 
        /// </summary>
        public void UpdateSemestersTaken()
        {
            StudentCustomization sc = TraverseTreeForStudentCustomization;
            Student student = sc.DataContext as Student;
            student.SemestersTaken = Semesters; 
        }

        /// <summary>
        /// Adds a new semester control to the display. 
        /// </summary>
        /// <param name="sender">the Add New Semester Button</param>
        /// <param name="e">the event where the users selects the add new semester button. </param>
        private void AddSemester(object sender, RoutedEventArgs e)
        {
            Semester semester = new Semester();
            semester.Name = "Semester " + (Semesters.Count + 1).ToString("D1");
            Semesters.Add(semester); 
            StudentCustomization stu = TraverseTreeForStudentCustomization; 
            Student student = stu.DataContext as Student;
            student.SemestersTaken = Semesters;
            stu.DataContext = student;

            SemesterControl sc = new SemesterControl(semester);
            SemesterControls.Add(sc); 
            sc.SemesterLabel.Text = semester.Name;
            SemesterStackPanel.Children.Add(sc);
        }
    }
}
