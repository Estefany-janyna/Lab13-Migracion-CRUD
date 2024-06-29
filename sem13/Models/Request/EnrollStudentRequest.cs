namespace sem13.Models.Request
{
    public class EnrollStudentRequest
    {
        public int StudentID { get; set; }
        public List<int> CourseIds { get; set; }
    }
}
