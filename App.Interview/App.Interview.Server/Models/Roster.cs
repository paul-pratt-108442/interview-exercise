namespace App.Interview.Server.Models
{
    public class Roster
    {
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        public int StudentId { get; set; }
        public Student? Student { get; set; }
    }
}
