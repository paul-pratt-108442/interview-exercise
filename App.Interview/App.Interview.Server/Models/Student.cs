namespace App.Interview.Server.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public ICollection<Roster> Rosters { get; set; } = new List<Roster>();
    }
}
