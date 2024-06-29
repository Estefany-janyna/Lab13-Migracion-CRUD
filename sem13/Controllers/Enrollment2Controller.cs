using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sem13.Models;
using sem13.Models.Request;
namespace sem13.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Enrollment2Controller : ControllerBase
    {
        private readonly SchoolContext _context;

        public Enrollment2Controller(SchoolContext context)
        {
            _context = context;
        }
        [HttpPost]
        public void Insert(EnrollStudentRequest request)
        {
            var student = _context.Students.Find(request.StudentID);
            if (student == null)
            {
                
                Console.WriteLine("Campo nulo");
            }

            foreach (var courseId in request.CourseIds)
            {
                var course = _context.Courses.Find(courseId);
                if (course != null)
                {
                    var enrollment = new Enrollment
                    {
                        StudentID = request.StudentID,
                        CourseID = courseId
                    };
                    _context.Enrollments.Add(enrollment);
                }
            }
            _context.SaveChanges();
         }

        }
    }
