namespace sem13.Models.Request
{
    public class StudentInsertListRequest
    {
        public int GradeID { get; set; }
        public List<StudentInsertRequest> Students { get; set; }
    }
}
