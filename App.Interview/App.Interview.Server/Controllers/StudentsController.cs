using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.Interview.Server.Data;
using App.Interview.Server.Models;

namespace App.Interview.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }

        [HttpGet("{studentId}/courses")]
        public async Task<ActionResult<IEnumerable<Course>>> GetStudentCourses(int studentId)
        {
            var courses = await _context.Courses
                .Include(c => c.Staff)
                .Where(c => c.Rosters.Any(r => r.StudentId == studentId))
                .ToListAsync();

            if (!courses.Any())
            {
                return NotFound();
            }

            return courses;
        }
    }
}
