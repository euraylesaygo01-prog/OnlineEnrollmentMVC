using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using OnlineEnrollmentMVC.Data;
using OnlineEnrollmentMVC.Models;

namespace OnlineEnrollmentMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _db;
        public AccountController(AppDbContext db) { _db = db; }

        public IActionResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var admin = await _db.AdminUsers.FirstOrDefaultAsync(a => a.Email == email && a.Password == password);
            if (admin != null)
            {
                HttpContext.Session.SetString("UserType", "Admin");
                HttpContext.Session.SetInt32("UserId", admin.Id);
                return RedirectToAction("Index", "Admin");
            }

            var student = await _db.Students.FirstOrDefaultAsync(s => s.Email == email && s.Password == password);
            if (student != null)
            {
                HttpContext.Session.SetString("UserType", "Student");
                HttpContext.Session.SetInt32("UserId", student.Id);
                return RedirectToAction("Dashboard", "Student");
            }

            ViewBag.Error = "Invalid email or password.";
            return View();
        }

        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(Student model, string confirmPassword)
        {
            if (model.Password != confirmPassword)
            {
                ViewBag.Error = "Passwords do not match.";
                return View(model);
            }

            var exists = await _db.Students.AnyAsync(s => s.Email == model.Email);
            if (exists)
            {
                ViewBag.Error = "Email already registered.";
                return View(model);
            }

            var count = await _db.Students.CountAsync();
            model.StudentNumber = $"2024-{(count + 1):D5}";
            model.Status = "Pending";
            model.RegisteredAt = DateTime.Now;

            _db.Students.Add(model);
            await _db.SaveChangesAsync();

            return RedirectToAction("Confirmation", new { firstName = model.FirstName });
        }

        public IActionResult Confirmation(string firstName)
        {
            ViewBag.FirstName = firstName;
            return View();
        }

        public IActionResult ForgotPassword() => View();

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            var student = await _db.Students.FirstOrDefaultAsync(s => s.Email == email);
            if (student == null)
            {
                ViewBag.Error = "No account found with that email.";
                return View();
            }
            HttpContext.Session.SetInt32("ResetStudentId", student.Id);
            return RedirectToAction("ResetPassword");
        }

        public IActionResult ResetPassword() => View();

        [HttpPost]
        public async Task<IActionResult> ResetPassword(string newPassword, string confirmPassword)
        {
            if (newPassword != confirmPassword)
            {
                ViewBag.Error = "Passwords do not match.";
                return View();
            }

            var studentId = HttpContext.Session.GetInt32("ResetStudentId");
            if (studentId == null) return RedirectToAction("ForgotPassword");

            var student = await _db.Students.FindAsync(studentId);
            if (student != null)
            {
                student.Password = newPassword;
                await _db.SaveChangesAsync();
            }

            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }
    }
}