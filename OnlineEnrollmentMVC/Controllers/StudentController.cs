using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineEnrollmentMVC.Data;
using OnlineEnrollmentMVC.Models;

namespace OnlineEnrollmentMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly AppDbContext _db;
        public StudentController(AppDbContext db) { _db = db; }

        private int? GetStudentId() => HttpContext.Session.GetInt32("UserId");

        public async Task<IActionResult> Dashboard()
        {
            var studentId = GetStudentId();
            if (studentId == null) return RedirectToAction("Login", "Account");

            var student = await _db.Students.FindAsync(studentId);
            if (student == null) return RedirectToAction("Login", "Account");

            var enrollment = await _db.Enrollments
                .Include(e => e.Course)
                .FirstOrDefaultAsync(e => e.StudentId == studentId);

            var payment = await _db.Payments
                .FirstOrDefaultAsync(p => p.StudentId == studentId);

            ViewBag.Enrollment = enrollment;
            ViewBag.Payment = payment;
            return View(student);
        }

        public async Task<IActionResult> EditProfile()
        {
            var studentId = GetStudentId();
            if (studentId == null) return RedirectToAction("Login", "Account");

            var student = await _db.Students.FindAsync(studentId);
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(string phone, string address, string? newPassword, string? confirmPassword)
        {
            var studentId = GetStudentId();
            if (studentId == null) return RedirectToAction("Login", "Account");

            var student = await _db.Students.FindAsync(studentId);
            if (student == null) return RedirectToAction("Login", "Account");

            student.Phone = phone;
            student.Address = address;

            if (!string.IsNullOrWhiteSpace(newPassword))
            {
                if (newPassword != confirmPassword)
                {
                    ViewBag.Error = "Passwords do not match.";
                    return View(student);
                }
                student.Password = newPassword;
            }

            await _db.SaveChangesAsync();
            ViewBag.Success = "Profile updated successfully!";
            return View(student);
        }

        public async Task<IActionResult> Subjects(int year = 1, int semester = 1)
        {
            var studentId = GetStudentId();
            if (studentId == null) return RedirectToAction("Login", "Account");

            var student = await _db.Students.FindAsync(studentId);
            var enrollment = await _db.Enrollments
                .Include(e => e.Course)
                .FirstOrDefaultAsync(e => e.StudentId == studentId);

            if (enrollment == null)
            {
                ViewBag.Error = "You are not enrolled in any program yet.";
                return View();
            }

            var majorSubjects = await _db.Subjects
                .Where(s => s.CourseId == enrollment.CourseId && s.YearLevel == year && s.Semester == semester)
                .ToListAsync();

            var minorSubjects = await _db.Subjects
                .Where(s => s.CourseId == null && s.YearLevel == year && s.Semester == semester)
                .ToListAsync();

            ViewBag.Student = student;
            ViewBag.Enrollment = enrollment;
            ViewBag.MajorSubjects = majorSubjects;
            ViewBag.MinorSubjects = minorSubjects;
            ViewBag.Year = year;
            ViewBag.Semester = semester;
            return View();
        }

        public async Task<IActionResult> PrintEnrollment()
        {
            var studentId = GetStudentId();
            if (studentId == null) return RedirectToAction("Login", "Account");

            var student = await _db.Students.FindAsync(studentId);
            var enrollment = await _db.Enrollments
                .Include(e => e.Course)
                .FirstOrDefaultAsync(e => e.StudentId == studentId);

            var payment = await _db.Payments
                .FirstOrDefaultAsync(p => p.StudentId == studentId);

            ViewBag.Enrollment = enrollment;
            ViewBag.Payment = payment;
            return View(student);
        }
    }
}
