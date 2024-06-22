namespace sem13.Models.Request
{
    public class StudentInsertRequest
    {
        public int GradeID { get; set; }
        public string FirsName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Active { get; set; }
    }
}
