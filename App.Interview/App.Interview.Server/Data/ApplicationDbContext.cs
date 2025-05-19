using Microsoft.EntityFrameworkCore;

namespace App.Interview.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Student> Students { get; set; }
        public DbSet<Models.Staff> Staff { get; set; }
        public DbSet<Models.Course> Courses { get; set; }
        public DbSet<Models.Roster> Rosters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Roster>()
                .HasKey(r => new { r.CourseId, r.StudentId });

            // Seed data
            modelBuilder.Entity<Models.Staff>().HasData(
                new Models.Staff { StaffId = 1, FirstName = "John", LastName = "Doe" },
                new Models.Staff { StaffId = 2, FirstName = "Jane", LastName = "Smith" }
            );

            modelBuilder.Entity<Models.Student>().HasData(
                new Models.Student { StudentId = 1, FirstName = "Alice", LastName = "Johnson" },
                new Models.Student { StudentId = 2, FirstName = "Bob", LastName = "Williams" },
                new Models.Student { StudentId = 3, FirstName = "Charlie", LastName = "Brown" }
            );

            modelBuilder.Entity<Models.Course>().HasData(
                new Models.Course { CourseId = 1, CourseName = "Mathematics", StaffId = 1 },
                new Models.Course { CourseId = 2, CourseName = "Physics", StaffId = 2 },
                new Models.Course { CourseId = 3, CourseName = "Chemistry", StaffId = 1 }
            );

            modelBuilder.Entity<Models.Roster>().HasData(
                new Models.Roster { CourseId = 1, StudentId = 1 },
                new Models.Roster { CourseId = 1, StudentId = 2 },
                new Models.Roster { CourseId = 2, StudentId = 2 },
                new Models.Roster { CourseId = 2, StudentId = 3 },
                new Models.Roster { CourseId = 3, StudentId = 1 }
            );
        }
    }
}
