using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using sem13.Models.Request;
using sem13.Models;
using Azure.Core;

namespace sem13.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Grade2Controller : Controller
    {
        private readonly SchoolContext _context;

        public Grade2Controller(SchoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetActiveGrades()
        {
            var activeGrades = _context.Grades.Where(c => c.Active).ToList();

            return Ok(activeGrades);
        }

        [HttpPost]
        public void Insert(GradeInsertRequest request)
        {
            Grade grade = new Grade();
            grade.Name = request.Name;
            grade.Description = request.Description;
            grade.Active = true;
            _context.Grades.Add(grade);
            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void Delete(GradeDeleteRequest request)
        {
            var grade = _context.Grades.Find(request.Id);

            grade.Active = false;
            _context.Grades.Update(grade);
            _context.SaveChanges();

     
        }


    }
}
