using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sem13.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace sem13.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly SchoolContext _context;

        public StudentController(SchoolContext context)
        {
            _context = context;
        }

       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _context.Students.Where(s => s.Active).ToListAsync();
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Student>>> SearchStudents(string name, string lastName, string email)
        {
            var query = _context.Students.Where(s => s.Active);

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(s => s.FirsName.Contains(name));
            }

            if (!string.IsNullOrEmpty(lastName))
            {
                query = query.Where(s => s.LastName.Contains(lastName));
            }

            if (!string.IsNullOrEmpty(email))
            {
                query = query.Where(s => s.Email.Contains(email));
            }

            query = query.OrderByDescending(s => s.LastName);

            return await query.ToListAsync();
        }

        [HttpGet("searchByGrade")]
        public async Task<ActionResult<IEnumerable<Student>>> SearchStudentsByGrade(string name, int gradeId)
        {
            var query = _context.Students.Where(s => s.Active);

            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(s => s.FirsName.Contains(name));
            }

            if (gradeId > 0)
            {
                query = query.Where(s => s.GradeID == gradeId);
            }

            query = query.Include(s => s.Grade).OrderByDescending(s => s.Grade.Name);

            return await query.ToListAsync();
        }

        [HttpGet("enrolledStudentsByCourse")]
        public async Task<ActionResult<IEnumerable<Student>>> GetEnrolledStudentsByCourse(string courseName)
        {
            var query = _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .Where(e => e.Course.Active && e.Student.Active);

            if (!string.IsNullOrEmpty(courseName))
            {
                query = query.Where(e => e.Course.Name.Contains(courseName));
            }

            query = query.OrderBy(e => e.Course.Name).ThenBy(e => e.Student.LastName);

            var enrolledStudents = await query.Select(e => new
            {
                Student = e.Student,
                Course = e.Course,
                Enrollment = e
            }).ToListAsync();

            return enrolledStudents.Select(es => es.Student).Distinct().ToList();
        }

        [HttpGet("enrolledStudentsByGrade")]
        public async Task<ActionResult<IEnumerable<Student>>> GetEnrolledStudentsByGrade(int gradeId)
        {
            var query = _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .Where(e => e.Course.Active && e.Student.Active);

            if (gradeId > 0)
            {
                query = query.Where(e => e.Student.GradeID == gradeId);
            }

            query = query.OrderBy(e => e.Course.Name).ThenBy(e => e.Student.LastName);

            var enrolledStudents = await query.Select(e => new
            {
                Student = e.Student,
                Course = e.Course,
                Enrollment = e
            }).ToListAsync();

            return enrolledStudents.Select(es => es.Student).Distinct().ToList();
        }
    }
}
