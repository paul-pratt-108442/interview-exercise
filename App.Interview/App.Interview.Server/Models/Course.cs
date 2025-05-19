namespace App.Interview.Server.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; } = string.Empty;
        public int StaffId { get; set; }
        public Staff? Staff { get; set; }
        public ICollection<Roster> Rosters { get; set; } = new List<Roster>();
    }
}
