using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.Interview.Server.Data;
using App.Interview.Server.Models;

namespace App.Interview.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CoursesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            return await _context.Courses
                .Include(c => c.Staff)
                .ToListAsync();
        }
    }
}
