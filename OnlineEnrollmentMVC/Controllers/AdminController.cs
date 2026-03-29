using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using OnlineEnrollmentMVC.Data;
using OnlineEnrollmentMVC.Models;

namespace OnlineEnrollmentMVC.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _db;
        public AdminController(AppDbContext db) { _db = db; }

        public async Task<IActionResult> Index()
        {
            if (HttpContext.Session.GetString("UserType") != "Admin")
                return RedirectToAction("Login", "Account");

            var students = await _db.Students.ToListAsync();
            var courses = await _db.Courses.ToListAsync();
            var payments = await _db.Payments.ToListAsync();
            ViewBag.Courses = courses;
            ViewBag.Payments = payments;
            return View(students);
        }

        public async Task<IActionResult> StudentDetails(int id)
        {
            if (HttpContext.Session.GetString("UserType") != "Admin")
                return RedirectToAction("Login", "Account");

            var student = await _db.Students.FindAsync(id);
            if (student == null) return NotFound();

            var enrollments = await _db.Enrollments
                .Include(e => e.Course)
                .Where(e => e.StudentId == id)
                .ToListAsync();

            ViewBag.Enrollments = enrollments;
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus(int studentId, string status)
        {
            var student = await _db.Students.FindAsync(studentId);
            if (student != null)
            {
                student.Status = status;
                await _db.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteStudent(int studentId)
        {
            var student = await _db.Students.FindAsync(studentId);
            if (student != null)
            {
                // Delete related enrollments first
                var enrollments = _db.Enrollments.Where(e => e.StudentId == studentId);
                _db.Enrollments.RemoveRange(enrollments);

                // Delete related payments
                var payments = _db.Payments.Where(p => p.StudentId == studentId);
                _db.Payments.RemoveRange(payments);

                // Delete student
                _db.Students.Remove(student);
                await _db.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> AddCourse(string name, string department, int units, int slots)
        {
            var course = new Course
            {
                Name = name,
                Department = department,
                Units = units,
                Slots = slots,
                IsActive = true
            };
            _db.Courses.Add(course);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> EditCourse(int id, string name, string department, int units, int slots)
        {
            var course = await _db.Courses.FindAsync(id);
            if (course != null)
            {
                course.Name = name;
                course.Department = department;
                course.Units = units;
                course.Slots = slots;
                await _db.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> ToggleCourse(int id)
        {
            var course = await _db.Courses.FindAsync(id);
            if (course != null)
            {
                course.IsActive = !course.IsActive;
                await _db.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> MarkAsPaid(int paymentId)
        {
            if (HttpContext.Session.GetString("UserType") != "Admin")
                return RedirectToAction("Login", "Account");

            var payment = await _db.Payments.FindAsync(paymentId);
            if (payment != null)
            {
                payment.Status = "Paid";
                payment.PaidAt = DateTime.Now;
                await _db.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

    }
}