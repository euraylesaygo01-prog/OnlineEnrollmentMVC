namespace OnlineEnrollmentMVC.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Code { get; set; } = "";
        public string Name { get; set; } = "";
        public string Department { get; set; } = "";
        public string Schedule { get; set; } = "";
        public int Units { get; set; }
        public int Slots { get; set; }
        public int EnrolledCount { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public ICollection<Subject> Subjects { get; set; } = new List<Subject>();
    }
}
