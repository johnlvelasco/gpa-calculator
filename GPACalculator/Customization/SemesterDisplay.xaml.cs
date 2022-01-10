using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
        /// Constructor for the semester display control. 
        /// </summary>
        public SemesterDisplay()
        {
            InitializeComponent();            
            Semester semester = new Semester();
            semester.Name = "Semester " + (Semesters.Count + 1).ToString("D1");
            Semesters.Add(semester);

            DataContext = new Student();
            Student student = DataContext as Student;
            student.SemestersTaken.Add(semester);
            DataContext = student;

            SemesterControl sc = new SemesterControl(semester);
            sc.SemesterLabel.Text = semester.Name;
            SemesterStackPanel.Children.Add(sc);
        }

        public void UpdateSemestersTaken()
        {
            StudentCustomization sc = TraverseTreeForStudentCustomization;
            Student student = sc.DataContext as Student;
            student.SemestersTaken = Semesters; 
        }

        /// <summary>
        /// Adds a new semester control to the display. 
        /// </summary>
        /// <param name="sender">s</param>
        /// <param name="e">e</param>
        private void AddSemester(object sender, RoutedEventArgs e)
        {
            Semester semester = new Semester();
            semester.Name = "Semester " + (Semesters.Count + 1).ToString("D1");
            Semesters.Add(semester); 
            StudentCustomization stu = TraverseTreeForStudentCustomization; 
            Student student = stu.DataContext as Student;
            student.SemestersTaken = Semesters;
            //student.SemestersTaken.Add(semester);
            stu.DataContext = student;

            SemesterControl sc = new SemesterControl(semester);
            sc.SemesterLabel.Text = semester.Name;
            SemesterStackPanel.Children.Add(sc);
        }
    }
}
