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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Data;

namespace GPACalculator
{
    /// <summary>
    /// Interaction logic for ListSwapper.xaml
    /// </summary>
    public partial class ListSwapper : UserControl
    {
        public ListSwapper()
        {
            InitializeComponent();
        }

        public void AddNewStudent(object sender, RoutedEventArgs e)
        {
            StudentCustomization studentCustomization = new StudentCustomization();
            MainWindow main = TraverseTreeForMain;
            main.MainWindowBorder.Child = studentCustomization; 

        }
        /// <summary>
        /// Traverses the tree to find the MainWindow parent. 
        /// </summary>
        private MainWindow TraverseTreeForMain
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


    }
}
