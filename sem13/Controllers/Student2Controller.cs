using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sem13.Models.Request;
using sem13.Models;
using Microsoft.EntityFrameworkCore;



namespace sem13.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Student2Controller : ControllerBase
    {
        private readonly SchoolContext _context;

        public Student2Controller(SchoolContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Insert(StudentInsertRequest request)
        {
            Student student = new Student
            {
                GradeID = request.GradeID,
                FirsName = request.FirsName,
                LastName = request.LastName,
                Phone = request.Phone,
                Email = request.Email,
                Active = true
            };

            _context.Students.Add(student);
            _context.SaveChanges();

            return Ok("Student inserted successfully.");
        }

        [HttpPost]
        public IActionResult UpdateContact(ContactUpdateRequest request)
        {
            var student = _context.Students.Find(request.Id);
            if (student == null)
            {
                return NotFound("Student not found.");
            }

            student.Phone = request.Phone;
            student.Email = request.Email;
            _context.Students.Update(student);
            _context.SaveChanges();

            return Ok("Contact information updated successfully.");
        }

        [HttpPost]
        public IActionResult UpdatePerson(DataUpdateRequest request)
        {
            var student = _context.Students.Find(request.StudentID);
            if (student == null)
            {
                return NotFound("Student not found.");
            }

            student.FirsName = request.FirsName;
            student.LastName = request.LastName;
            _context.Students.Update(student);
            _context.SaveChanges();

            return Ok("Personal information updated successfully.");
        }
    }
}
