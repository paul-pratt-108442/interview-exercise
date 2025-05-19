using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.Interview.Server.Data;
using App.Interview.Server.Models;

namespace App.Interview.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StaffController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staff>>> GetStaff()
        {
            return await _context.Staff.ToListAsync();
        }

        [HttpGet("{staffId}/courses")]
        public async Task<ActionResult<IEnumerable<Course>>> GetStaffCourses(int staffId)
        {
            var courses = await _context.Courses
                .Include(c => c.Rosters)
                .Where(c => c.StaffId == staffId)
                .ToListAsync();

            if (!courses.Any())
            {
                return NotFound();
            }

            return courses;
        }
    }
}
