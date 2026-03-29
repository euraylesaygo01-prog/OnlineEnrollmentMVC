namespace OnlineEnrollmentMVC.Models
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Type { get; set; } = "Minor";
        public int Units { get; set; } = 3;
        public int YearLevel { get; set; } = 1;
        public int Semester { get; set; } = 1;
        public int? CourseId { get; set; }
        public Course? Course { get; set; }
    }
}