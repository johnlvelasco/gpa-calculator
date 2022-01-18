using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using Data;

namespace GPACalculator
{
    /// <summary>
    /// Interaction logic for ListSwapper.xaml
    /// </summary>
    public partial class ListSwapper : UserControl
    {
        /// <summary>
        /// Traverses the tree to find the MainWindow parent. 
        /// </summary>
        private MainWindow TraverseTreeForMainWindow
        {
            get
            {
                DependencyObject parent = this;
                do
                {
                    parent = LogicalTreeHelper.GetParent(parent);
                } while (!(parent is null || parent is MainWindow));
                return parent as MainWindow;
            }
        }
        /// <summary>
        /// Constructor for the list swapper control.
        /// </summary>
        public ListSwapper()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Loads the students provided by the datacontext.
        /// Adding them to the ListBox as DisplayStudentControls.
        /// </summary>
        /// <param name="sender">LoadStudents button</param>
        /// <param name="e">Event where the user clicks the button.</param>
        public void LoadStudents(object sender, RoutedEventArgs e)
        {            
            List<Student> StoredStudents = DataContext as List<Student>;
            if (DataContext == null || StoredStudents.Count == 0) return;
            StudentDisplayStackPanel.Items.Clear(); 
            foreach (Student student in StoredStudents)
            {
                DisplayStudentControl dsc = new DisplayStudentControl(student);
                dsc.AddHandler(MouseDoubleClickEvent, new RoutedEventHandler(OnMouseDoubleClick)); 
                StudentDisplayStackPanel.Items.Add(dsc); 
            }
        }

        /// <summary>
        /// Switches the screen to Student Customization to add a new student.
        /// </summary>
        /// <param name="sender">Add new student button</param>
        /// <param name="e">Event where the user clicks the button.</param>
        public void AddNewStudent(object sender, RoutedEventArgs e)
        {            
            Student student = new Student();
            StudentCustomization studentCustomization = new StudentCustomization(student);
            studentCustomization.DataContext = student;
            MainWindow main = TraverseTreeForMainWindow;
            main.MainWindowBorder.Child = studentCustomization; 
        }

        /// <summary>
        /// Double click event that loads the selected student in the listbox. 
        /// </summary>
        /// <param name="sender">The selected DisplayStudentControl</param>
        /// <param name="e">a double click.</param>
        private void OnMouseDoubleClick(object sender, RoutedEventArgs e)
        {
            //load the student selected.
            DisplayStudentControl dsc = sender as DisplayStudentControl;
            Student studentToLoad = dsc.Student;
            StudentCustomization studentCustomization = new StudentCustomization(studentToLoad);
            studentCustomization.DataContext = studentToLoad;
            MainWindow main = TraverseTreeForMainWindow;
            main.MainWindowBorder.Child = studentCustomization; 
        }
    }
}
