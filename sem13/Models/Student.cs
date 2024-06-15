namespace sem13.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }

        public int GradeID { get; set; }
        public Grade? Grade { get; set; }

    }
}
