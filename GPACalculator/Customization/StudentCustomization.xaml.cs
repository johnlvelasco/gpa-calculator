using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using Data;

namespace GPACalculator
{
    /// <summary>
    /// Interaction logic for StudentCustomization.xaml
    /// </summary>
    public partial class StudentCustomization : UserControl
    {
        public StudentCustomization()
        {
            InitializeComponent();
        }

        private void CompleteStudent(object sender, RoutedEventArgs e)
        {
            Student student = DataContext as Student;
            string[] firstlast = StudentNameTextBox.Text.Split();
            student.FirstName = firstlast[0];
            student.LastName = firstlast[1]; 
        }
    }
}
