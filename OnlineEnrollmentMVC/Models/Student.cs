namespace OnlineEnrollmentMVC.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
        public string Phone { get; set; } = "";
        public string Address { get; set; } = "";
        public string Program { get; set; } = "";
        public string StudentNumber { get; set; } = "";
        public DateTime BirthDate { get; set; }
        public string Status { get; set; } = "Pending";
        public DateTime RegisteredAt { get; set; } = DateTime.Now;
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}