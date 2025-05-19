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

            // Seed Professors (Staff)
            modelBuilder.Entity<Models.Staff>().HasData(
                new Models.Staff { StaffId = 1, FirstName = "Minerva", LastName = "McGonagall" },
                new Models.Staff { StaffId = 2, FirstName = "Severus", LastName = "Snape" },
                new Models.Staff { StaffId = 3, FirstName = "Filius", LastName = "Flitwick" },
                new Models.Staff { StaffId = 4, FirstName = "Pomona", LastName = "Sprout" },
                new Models.Staff { StaffId = 5, FirstName = "Remus", LastName = "Lupin" },
                new Models.Staff { StaffId = 6, FirstName = "Rubeus", LastName = "Hagrid" }
            );

            // Seed Students
            modelBuilder.Entity<Models.Student>().HasData(
                // Original Core Students
                new Models.Student { StudentId = 1, FirstName = "Harry", LastName = "Potter" },
                new Models.Student { StudentId = 2, FirstName = "Hermione", LastName = "Granger" },
                new Models.Student { StudentId = 3, FirstName = "Ron", LastName = "Weasley" },
                new Models.Student { StudentId = 4, FirstName = "Draco", LastName = "Malfoy" },
                new Models.Student { StudentId = 5, FirstName = "Neville", LastName = "Longbottom" },
                new Models.Student { StudentId = 6, FirstName = "Luna", LastName = "Lovegood" },
                new Models.Student { StudentId = 7, FirstName = "Ginny", LastName = "Weasley" },
                new Models.Student { StudentId = 8, FirstName = "Cho", LastName = "Chang" },
                new Models.Student { StudentId = 9, FirstName = "Cedric", LastName = "Diggory" },
                new Models.Student { StudentId = 10, FirstName = "Fred", LastName = "Weasley" },
                
                // Additional Gryffindor Students
                new Models.Student { StudentId = 11, FirstName = "George", LastName = "Weasley" },
                new Models.Student { StudentId = 12, FirstName = "Seamus", LastName = "Finnigan" },
                new Models.Student { StudentId = 13, FirstName = "Dean", LastName = "Thomas" },
                new Models.Student { StudentId = 14, FirstName = "Lavender", LastName = "Brown" },
                new Models.Student { StudentId = 15, FirstName = "Parvati", LastName = "Patil" },
                new Models.Student { StudentId = 16, FirstName = "Katie", LastName = "Bell" },
                new Models.Student { StudentId = 17, FirstName = "Angelina", LastName = "Johnson" },
                new Models.Student { StudentId = 18, FirstName = "Oliver", LastName = "Wood" },

                // Additional Slytherin Students
                new Models.Student { StudentId = 19, FirstName = "Vincent", LastName = "Crabbe" },
                new Models.Student { StudentId = 20, FirstName = "Gregory", LastName = "Goyle" },
                new Models.Student { StudentId = 21, FirstName = "Pansy", LastName = "Parkinson" },
                new Models.Student { StudentId = 22, FirstName = "Blaise", LastName = "Zabini" },
                new Models.Student { StudentId = 23, FirstName = "Theodore", LastName = "Nott" },
                new Models.Student { StudentId = 24, FirstName = "Millicent", LastName = "Bulstrode" },
                new Models.Student { StudentId = 25, FirstName = "Daphne", LastName = "Greengrass" },

                // Additional Ravenclaw Students
                new Models.Student { StudentId = 26, FirstName = "Padma", LastName = "Patil" },
                new Models.Student { StudentId = 27, FirstName = "Michael", LastName = "Corner" },
                new Models.Student { StudentId = 28, FirstName = "Terry", LastName = "Boot" },
                new Models.Student { StudentId = 29, FirstName = "Anthony", LastName = "Goldstein" },
                new Models.Student { StudentId = 30, FirstName = "Marietta", LastName = "Edgecombe" },
                new Models.Student { StudentId = 31, FirstName = "Roger", LastName = "Davies" },

                // Additional Hufflepuff Students
                new Models.Student { StudentId = 32, FirstName = "Hannah", LastName = "Abbott" },
                new Models.Student { StudentId = 33, FirstName = "Susan", LastName = "Bones" },
                new Models.Student { StudentId = 34, FirstName = "Justin", LastName = "Finch-Fletchley" },
                new Models.Student { StudentId = 35, FirstName = "Ernie", LastName = "Macmillan" },
                new Models.Student { StudentId = 36, FirstName = "Zacharias", LastName = "Smith" },
                new Models.Student { StudentId = 37, FirstName = "Wayne", LastName = "Hopkins" }
            );

            // Seed Courses
            modelBuilder.Entity<Models.Course>().HasData(
                // Transfiguration by House
                new Models.Course { CourseId = 1, CourseName = "Transfiguration - Gryffindor", StaffId = 1 },
                new Models.Course { CourseId = 2, CourseName = "Transfiguration - Slytherin", StaffId = 1 },
                new Models.Course { CourseId = 3, CourseName = "Transfiguration - Ravenclaw", StaffId = 1 },
                new Models.Course { CourseId = 4, CourseName = "Transfiguration - Hufflepuff", StaffId = 1 },

                // Potions - Combined Classes
                new Models.Course { CourseId = 5, CourseName = "Potions - Gryffindor & Slytherin", StaffId = 2 },
                new Models.Course { CourseId = 6, CourseName = "Potions - Hufflepuff & Ravenclaw", StaffId = 2 },

                // Charms by House
                new Models.Course { CourseId = 7, CourseName = "Charms - Gryffindor", StaffId = 3 },
                new Models.Course { CourseId = 8, CourseName = "Charms - Slytherin", StaffId = 3 },
                new Models.Course { CourseId = 9, CourseName = "Charms - Ravenclaw", StaffId = 3 },
                new Models.Course { CourseId = 10, CourseName = "Charms - Hufflepuff", StaffId = 3 },

                // Herbology - Combined Classes
                new Models.Course { CourseId = 11, CourseName = "Herbology - Gryffindor & Hufflepuff", StaffId = 4 },
                new Models.Course { CourseId = 12, CourseName = "Herbology - Slytherin & Ravenclaw", StaffId = 4 },

                // Defense Against the Dark Arts - Combined Classes
                new Models.Course { CourseId = 13, CourseName = "Defense Against Dark Arts - Gryffindor & Ravenclaw", StaffId = 5 },
                new Models.Course { CourseId = 14, CourseName = "Defense Against Dark Arts - Hufflepuff & Slytherin", StaffId = 5 },

                // Care of Magical Creatures - Combined Classes
                new Models.Course { CourseId = 15, CourseName = "Care of Magical Creatures - Gryffindor & Slytherin", StaffId = 6 },
                new Models.Course { CourseId = 16, CourseName = "Care of Magical Creatures - Hufflepuff & Ravenclaw", StaffId = 6 }
            );

            // Seed Course Rosters
            modelBuilder.Entity<Models.Roster>().HasData(
                // Transfiguration - Gryffindor
                new Models.Roster { CourseId = 1, StudentId = 1 },  // Harry
                new Models.Roster { CourseId = 1, StudentId = 2 },  // Hermione
                new Models.Roster { CourseId = 1, StudentId = 3 },  // Ron
                new Models.Roster { CourseId = 1, StudentId = 10 }, // Fred
                new Models.Roster { CourseId = 1, StudentId = 11 }, // George
                new Models.Roster { CourseId = 1, StudentId = 12 }, // Seamus
                new Models.Roster { CourseId = 1, StudentId = 13 }, // Dean
                new Models.Roster { CourseId = 1, StudentId = 14 }, // Lavender
                new Models.Roster { CourseId = 1, StudentId = 15 }, // Parvati

                // Transfiguration - Slytherin
                new Models.Roster { CourseId = 2, StudentId = 4 },  // Draco
                new Models.Roster { CourseId = 2, StudentId = 19 }, // Crabbe
                new Models.Roster { CourseId = 2, StudentId = 20 }, // Goyle
                new Models.Roster { CourseId = 2, StudentId = 21 }, // Pansy
                new Models.Roster { CourseId = 2, StudentId = 22 }, // Blaise
                new Models.Roster { CourseId = 2, StudentId = 23 }, // Theodore
                new Models.Roster { CourseId = 2, StudentId = 24 }, // Millicent
                new Models.Roster { CourseId = 2, StudentId = 25 }, // Daphne

                // Transfiguration - Ravenclaw
                new Models.Roster { CourseId = 3, StudentId = 6 },  // Luna
                new Models.Roster { CourseId = 3, StudentId = 8 },  // Cho
                new Models.Roster { CourseId = 3, StudentId = 26 }, // Padma
                new Models.Roster { CourseId = 3, StudentId = 27 }, // Michael
                new Models.Roster { CourseId = 3, StudentId = 28 }, // Terry
                new Models.Roster { CourseId = 3, StudentId = 29 }, // Anthony
                new Models.Roster { CourseId = 3, StudentId = 30 }, // Marietta
                new Models.Roster { CourseId = 3, StudentId = 31 }, // Roger

                // Transfiguration - Hufflepuff
                new Models.Roster { CourseId = 4, StudentId = 9 },  // Cedric
                new Models.Roster { CourseId = 4, StudentId = 32 }, // Hannah
                new Models.Roster { CourseId = 4, StudentId = 33 }, // Susan
                new Models.Roster { CourseId = 4, StudentId = 34 }, // Justin
                new Models.Roster { CourseId = 4, StudentId = 35 }, // Ernie
                new Models.Roster { CourseId = 4, StudentId = 36 }, // Zacharias
                new Models.Roster { CourseId = 4, StudentId = 37 }, // Wayne

                // Potions - Gryffindor & Slytherin
                new Models.Roster { CourseId = 5, StudentId = 1 },  // Harry
                new Models.Roster { CourseId = 5, StudentId = 2 },  // Hermione
                new Models.Roster { CourseId = 5, StudentId = 3 },  // Ron
                new Models.Roster { CourseId = 5, StudentId = 5 },  // Neville
                new Models.Roster { CourseId = 5, StudentId = 4 },  // Draco
                new Models.Roster { CourseId = 5, StudentId = 19 }, // Crabbe
                new Models.Roster { CourseId = 5, StudentId = 20 }, // Goyle
                new Models.Roster { CourseId = 5, StudentId = 21 }, // Pansy
                new Models.Roster { CourseId = 5, StudentId = 22 }, // Blaise
                new Models.Roster { CourseId = 5, StudentId = 23 }, // Theodore

                // Potions - Hufflepuff & Ravenclaw
                new Models.Roster { CourseId = 6, StudentId = 6 },  // Luna
                new Models.Roster { CourseId = 6, StudentId = 8 },  // Cho
                new Models.Roster { CourseId = 6, StudentId = 26 }, // Padma
                new Models.Roster { CourseId = 6, StudentId = 27 }, // Michael
                new Models.Roster { CourseId = 6, StudentId = 32 }, // Hannah
                new Models.Roster { CourseId = 6, StudentId = 33 }, // Susan
                new Models.Roster { CourseId = 6, StudentId = 34 }, // Justin
                new Models.Roster { CourseId = 6, StudentId = 35 }, // Ernie

                // Charms - Gryffindor
                new Models.Roster { CourseId = 7, StudentId = 1 },  // Harry
                new Models.Roster { CourseId = 7, StudentId = 2 },  // Hermione
                new Models.Roster { CourseId = 7, StudentId = 3 },  // Ron
                new Models.Roster { CourseId = 7, StudentId = 5 },  // Neville
                new Models.Roster { CourseId = 7, StudentId = 10 }, // Fred
                new Models.Roster { CourseId = 7, StudentId = 11 }, // George
                new Models.Roster { CourseId = 7, StudentId = 12 }, // Seamus
                new Models.Roster { CourseId = 7, StudentId = 13 }, // Dean
                new Models.Roster { CourseId = 7, StudentId = 14 }, // Lavender
                new Models.Roster { CourseId = 7, StudentId = 15 }, // Parvati
                new Models.Roster { CourseId = 7, StudentId = 16 }, // Katie
                new Models.Roster { CourseId = 7, StudentId = 17 }, // Angelina

                // Charms - Slytherin
                new Models.Roster { CourseId = 8, StudentId = 4 },  // Draco
                new Models.Roster { CourseId = 8, StudentId = 19 }, // Crabbe
                new Models.Roster { CourseId = 8, StudentId = 20 }, // Goyle
                new Models.Roster { CourseId = 8, StudentId = 21 }, // Pansy
                new Models.Roster { CourseId = 8, StudentId = 22 }, // Blaise
                new Models.Roster { CourseId = 8, StudentId = 23 }, // Theodore
                new Models.Roster { CourseId = 8, StudentId = 24 }, // Millicent
                new Models.Roster { CourseId = 8, StudentId = 25 }, // Daphne

                // Charms - Ravenclaw
                new Models.Roster { CourseId = 9, StudentId = 6 },  // Luna
                new Models.Roster { CourseId = 9, StudentId = 8 },  // Cho
                new Models.Roster { CourseId = 9, StudentId = 26 }, // Padma
                new Models.Roster { CourseId = 9, StudentId = 27 }, // Michael
                new Models.Roster { CourseId = 9, StudentId = 28 }, // Terry
                new Models.Roster { CourseId = 9, StudentId = 29 }, // Anthony
                new Models.Roster { CourseId = 9, StudentId = 30 }, // Marietta
                new Models.Roster { CourseId = 9, StudentId = 31 }, // Roger

                // Charms - Hufflepuff
                new Models.Roster { CourseId = 10, StudentId = 9 },  // Cedric
                new Models.Roster { CourseId = 10, StudentId = 32 }, // Hannah
                new Models.Roster { CourseId = 10, StudentId = 33 }, // Susan
                new Models.Roster { CourseId = 10, StudentId = 34 }, // Justin
                new Models.Roster { CourseId = 10, StudentId = 35 }, // Ernie
                new Models.Roster { CourseId = 10, StudentId = 36 }, // Zacharias
                new Models.Roster { CourseId = 10, StudentId = 37 }, // Wayne

                // Herbology - Gryffindor & Hufflepuff
                new Models.Roster { CourseId = 11, StudentId = 1 }, // Harry
                new Models.Roster { CourseId = 11, StudentId = 2 }, // Hermione
                new Models.Roster { CourseId = 11, StudentId = 3 }, // Ron
                new Models.Roster { CourseId = 11, StudentId = 5 }, // Neville
                new Models.Roster { CourseId = 11, StudentId = 32 }, // Hannah
                new Models.Roster { CourseId = 11, StudentId = 33 }, // Susan
                new Models.Roster { CourseId = 11, StudentId = 34 }, // Justin
                new Models.Roster { CourseId = 11, StudentId = 35 }, // Ernie

                // Herbology - Slytherin & Ravenclaw
                new Models.Roster { CourseId = 12, StudentId = 4 },  // Draco
                new Models.Roster { CourseId = 12, StudentId = 19 }, // Crabbe
                new Models.Roster { CourseId = 12, StudentId = 20 }, // Goyle
                new Models.Roster { CourseId = 12, StudentId = 21 }, // Pansy
                new Models.Roster { CourseId = 12, StudentId = 6 },  // Luna
                new Models.Roster { CourseId = 12, StudentId = 8 },  // Cho
                new Models.Roster { CourseId = 12, StudentId = 26 }, // Padma
                new Models.Roster { CourseId = 12, StudentId = 27 }, // Michael
                new Models.Roster { CourseId = 12, StudentId = 28 }, // Terry
                new Models.Roster { CourseId = 12, StudentId = 31 }, // Roger

                // Defense Against Dark Arts - Gryffindor & Ravenclaw
                new Models.Roster { CourseId = 13, StudentId = 1 }, // Harry
                new Models.Roster { CourseId = 13, StudentId = 2 }, // Hermione
                new Models.Roster { CourseId = 13, StudentId = 3 }, // Ron
                new Models.Roster { CourseId = 13, StudentId = 6 }, // Luna
                new Models.Roster { CourseId = 13, StudentId = 8 }, // Cho
                new Models.Roster { CourseId = 13, StudentId = 28 }, // Terry
                new Models.Roster { CourseId = 13, StudentId = 29 }, // Anthony

                // Defense Against Dark Arts - Hufflepuff & Slytherin
                new Models.Roster { CourseId = 14, StudentId = 4 },  // Draco
                new Models.Roster { CourseId = 14, StudentId = 21 }, // Pansy
                new Models.Roster { CourseId = 14, StudentId = 22 }, // Blaise
                new Models.Roster { CourseId = 14, StudentId = 23 }, // Theodore
                new Models.Roster { CourseId = 14, StudentId = 9 },  // Cedric
                new Models.Roster { CourseId = 14, StudentId = 32 }, // Hannah
                new Models.Roster { CourseId = 14, StudentId = 33 }, // Susan
                new Models.Roster { CourseId = 14, StudentId = 34 }, // Justin
                new Models.Roster { CourseId = 14, StudentId = 35 }, // Ernie
                new Models.Roster { CourseId = 14, StudentId = 36 }, // Zacharias

                // Care of Magical Creatures - Gryffindor & Slytherin
                new Models.Roster { CourseId = 15, StudentId = 1 }, // Harry
                new Models.Roster { CourseId = 15, StudentId = 2 }, // Hermione
                new Models.Roster { CourseId = 15, StudentId = 3 }, // Ron
                new Models.Roster { CourseId = 15, StudentId = 4 }, // Draco
                new Models.Roster { CourseId = 15, StudentId = 19 }, // Crabbe
                new Models.Roster { CourseId = 15, StudentId = 20 }, // Goyle
                new Models.Roster { CourseId = 15, StudentId = 21 }, // Pansy
                new Models.Roster { CourseId = 15, StudentId = 22 },  // Blaise

                // Care of Magical Creatures - Hufflepuff & Ravenclaw
                new Models.Roster { CourseId = 16, StudentId = 6 },  // Luna
                new Models.Roster { CourseId = 16, StudentId = 8 },  // Cho
                new Models.Roster { CourseId = 16, StudentId = 26 }, // Padma
                new Models.Roster { CourseId = 16, StudentId = 27 }, // Michael
                new Models.Roster { CourseId = 16, StudentId = 9 },  // Cedric
                new Models.Roster { CourseId = 16, StudentId = 32 }, // Hannah
                new Models.Roster { CourseId = 16, StudentId = 33 }, // Susan
                new Models.Roster { CourseId = 16, StudentId = 34 }, // Justin
                new Models.Roster { CourseId = 16, StudentId = 35 }, // Ernie
                new Models.Roster { CourseId = 16, StudentId = 36 }  // Zacharias
            );
        }
    }
}
