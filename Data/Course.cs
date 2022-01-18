namespace Data
{
    /// <summary>
    /// A course that has a name, number of credit hours, and a grade. 
    /// </summary>
    public class Course
    {
        /// <summary>
        /// The name of the course.
        /// </summary>
        public string CourseName { get; }

        /// <summary>
        /// Number of credit hours the course is. 
        /// </summary>
        public int CreditHours { get; }

        /// <summary>
        /// Grade recieved for the course.
        /// </summary>
        public Grade LetterGrade { get; }
 
        /// <summary>
        /// Constructor for the Course, setting the values needed. 
        /// </summary>
        /// <param name="name">Course Name</param>
        /// <param name="credits">Credit hours</param>
        /// <param name="grade">Grade for the course.</param>
        public Course(string name, int credits, Grade grade)
        {
            CourseName = name;
            CreditHours = credits;
            LetterGrade = grade; 
        }
    }
}
