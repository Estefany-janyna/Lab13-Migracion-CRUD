using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using sem13.Models;
using sem13.Models.Request;
using System.Diagnostics;

namespace sem13.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Course2Controller : ControllerBase
    {
        private readonly SchoolContext _context;

        public Course2Controller(SchoolContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetActiveCourses()
        {
            var activeCourses = _context.Courses.Where(c => c.Active).ToList();

            return Ok(activeCourses);
        }


        [HttpPost]
        public void Insert(CourseInsertRequest request)
        {
            Course course = new Course();
            course.Name = request.Name;
            course.Credit = request.Credit;
            course.Active = true;

            _context.Courses.Add(course);
            _context.SaveChanges();
        }


        [HttpDelete("{id}")]
        public void Delete(CourseDeleteRequest request)
        {
            var course = _context.Courses.Find(request.Id);

            course.Active = false;
            _context.Courses.Update(course);
            _context.SaveChanges();


        }

        [HttpPost]
        public void DeleteList(ListCourseDeleteRequest request)
        {
            foreach (var courseId in request.CourseIds)
            {
                var course = _context.Courses.Find(courseId);
                if (course != null)
                {
                    course.Active = false;
                    _context.Courses.Update(course);

                }
            }
            _context.SaveChanges();
        }



    }
}
