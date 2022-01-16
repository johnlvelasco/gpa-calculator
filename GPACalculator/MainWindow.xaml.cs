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
        public MainWindow()
        {
            InitializeComponent();
            if (Students.Count == 0)
            {
                //try reading thru the json. 
            }
        }

        /// <summary>
        /// List of the students for the JSON database.
        /// </summary>
        public List<Student> Students = new List<Student>();

        private string JsonString; 

        /// <summary>
        /// Updates the JSON database file with the list of students. 
        /// </summary>
        public void UpdateJSON()
        {
            JsonString = JsonConvert.SerializeObject(Students);
            File.WriteAllText(@"C:\Users\johnv\source\repos\gpa-calculator\student-database", JsonString);
        }
        /// <summary>
        /// Fills the empty Students list with the Database of Students. 
        /// </summary>
        public void FillStudents()
        {
            Students = JsonConvert.DeserializeObject<List<Student>>(JsonString); 
        }

        //Serialization & Deserialization for a single Student. 
        /*
        string jsonString = JsonConvert.SerializeObject(student);
        File.WriteAllText(@"C:\Users\johnv\source\repos\gpa-calculator\student-database", jsonString);

            Student deserialStudent = JsonConvert.DeserializeObject<Student>(jsonString);
        */
    }
}
