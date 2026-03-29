namespace OnlineEnrollmentMVC.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public decimal TuitionFee { get; set; }
        public decimal MiscFee { get; set; } = 2500;
        public decimal TotalFee { get; set; }
        public string Status { get; set; } = "Unpaid";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? PaidAt { get; set; }
        public Student Student { get; set; } = null!;
    }
}