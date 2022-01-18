using System;
using System.Collections.Generic;
using System.Windows;
using Data;
using System.IO;
using Newtonsoft.Json; 

namespace GPACalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Main window constructor, sets the datacontext for the project to be the list of students.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            DataContext = Students;
            if (Students.Count == 0)
            {
                //try reading thru the json. 
            }
        }

        /// <summary>
        /// List of the students for the JSON database.
        /// </summary>
        public List<Student> Students = new List<Student>();

        /// <summary>
        /// The JSON string given when serializing the list of students. 
        /// </summary>
        private string JsonString; 

        /// <summary>
        /// Updates the JSON database file with the list of students. 
        /// </summary>
        public void UpdateJSON()
        {
            JsonString = JsonConvert.SerializeObject(Students, Formatting.Indented);
            File.WriteAllText(@"C:\Users\johnv\source\repos\gpa-calculator\student-database", JsonString);
        }
        /// <summary>
        /// Fills the empty Students list with the Database of Students. 
        /// </summary>
        public void FillStudents()
        {
            Students = JsonConvert.DeserializeObject<List<Student>>(JsonString); 
        }
    }
}
