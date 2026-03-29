using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using OnlineEnrollmentMVC.Data;
using OnlineEnrollmentMVC.Models;

namespace OnlineEnrollmentMVC.Controllers
{
    public class CoursesController : Controller
    {
        private readonly AppDbContext _db;
        public CoursesController(AppDbContext db) { _db = db; }

        public async Task<IActionResult> Index(int studentId)
        {
            var student = await _db.Students.FindAsync(studentId);
            if (student == null) return RedirectToAction("Login", "Account");

            var courses = await _db.Courses.Where(c => c.IsActive).ToListAsync();
            ViewBag.Student = student;
            ViewBag.StudentId = studentId;
            return View(courses);
        }

        public async Task<IActionResult> Subjects(int courseId, int year = 1, int semester = 1)
        {
            var majorSubjects = await _db.Subjects
                .Where(s => s.CourseId == courseId && s.YearLevel == year && s.Semester == semester)
                .Select(s => new { s.Name, s.Units })
                .ToListAsync();

            var minorSubjects = await _db.Subjects
                .Where(s => s.CourseId == null && s.YearLevel == year && s.Semester == semester)
                .Select(s => new { s.Name, s.Units })
                .ToListAsync();

            return Json(new { major = majorSubjects, minor = minorSubjects });
        }

        [HttpPost]
        public async Task<IActionResult> Enroll(int studentId, int courseId)
        {
            var existing = await _db.Enrollments
                .FirstOrDefaultAsync(e => e.StudentId == studentId);

            if (existing != null)
            {
                var oldCourse = await _db.Courses.FindAsync(existing.CourseId);
                if (oldCourse != null) oldCourse.EnrolledCount--;
                _db.Enrollments.Remove(existing);

                var oldPayment = await _db.Payments.FirstOrDefaultAsync(p => p.StudentId == studentId);
                if (oldPayment != null) _db.Payments.Remove(oldPayment);
            }

            var enrollment = new Enrollment
            {
                StudentId = studentId,
                CourseId = courseId,
                EnrolledAt = DateTime.Now
            };
            _db.Enrollments.Add(enrollment);

            var course = await _db.Courses.FindAsync(courseId);
            if (course != null)
            {
                course.EnrolledCount++;
                var student = await _db.Students.FindAsync(studentId);
                if (student != null) student.Program = course.Name;

                var tuition = course.Units * 1200;
                var payment = new Payment
                {
                    StudentId = studentId,
                    TuitionFee = tuition,
                    MiscFee = 2500,
                    TotalFee = tuition + 2500,
                    Status = "Unpaid",
                    CreatedAt = DateTime.Now
                };
                _db.Payments.Add(payment);
            }

            await _db.SaveChangesAsync();
            return RedirectToAction("Dashboard", "Student");
        }

        public IActionResult Success(int studentId)
        {
            ViewBag.StudentId = studentId;
            return View();
        }
    }
}