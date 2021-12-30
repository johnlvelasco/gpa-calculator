using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class StudentDatabase
    {
        /// <summary>
        /// List of all students in the Database. 
        /// </summary>
        public List<Student> All; 

        public StudentDatabase()
        {
            //Have it read from a database file that holds the information of a person. 
            //For now, it will be new database
            All = new List<Student>(); 
        }
    }
}
