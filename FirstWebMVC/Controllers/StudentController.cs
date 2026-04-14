using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using FirstWebMVC.Data;
using FirstWebMVC.Models.Entities;
using FirstWebMVC.Models.ViewModels;

namespace FirstWebMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ================= READ =================
        public async Task<IActionResult> Index(string searchString)
        {
            var students = await _context.Students
                .Include(s => s.Faculty)
                .Select(s => new StudentVM
                {
                    Id = s.Id,
                    StudentCode = s.StudentCode,
                    FullName = s.FullName,
                    Email = s.Email,
                    FacultyName = s.Faculty!.FacultyName
                })
                .ToListAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                students = students.Where(s =>
                    s.StudentCode == searchString ||
                    s.FullName == searchString)
                    .ToList();

                if (!students.Any())
                {
                    ViewBag.Message = "Không tìm thấy sinh viên bạn cần tìm!";
                    return View("NotFound");
                }
            }

            return View(students);
        }

        // ================= CREATE =================
        public IActionResult Create()
        {
            LoadFaculties();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            if (ModelState.IsValid)
            {
                var existingStudent = await _context.Students
                    .FirstOrDefaultAsync(s => s.StudentCode == student.StudentCode);

                if (existingStudent != null)
                {
                    ViewBag.Message = "Mã sinh viên đã tồn tại trước đó!";
                    return View("NotFound");
                }

                _context.Add(student);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            LoadFaculties();
            return View(student);
        }

        // ================= EDIT =================
        public IActionResult Edit(int id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
            {
                ViewBag.Message = "Không tìm thấy sinh viên!";
                return View("NotFound");
            }

            LoadFaculties();
            return View(student);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                var existingStudent = _context.Students
                    .FirstOrDefault(s => s.StudentCode == student.StudentCode && s.Id != student.Id);

                if (existingStudent != null)
                {
                    ViewBag.Message = "Mã sinh viên đã tồn tại ở sinh viên khác!";
                    return View("NotFound");
                }

                _context.Students.Update(student);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            LoadFaculties();
            return View(student);
        }

        // ================= DELETE =================
        public IActionResult Delete(int id)
        {
            var student = _context.Students
                .Include(s => s.Faculty)
                .FirstOrDefault(s => s.Id == id);

            if (student == null)
            {
                ViewBag.Message = "Không tìm thấy sinh viên để xoá!";
                return View("NotFound");
            }

            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _context.Students.Find(id);

            if (student != null)
            {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
        }

        // ================= HELPER =================
        private void LoadFaculties()
        {
            ViewBag.Faculties = _context.Faculties
                .Select(f => new SelectListItem
                {
                    Value = f.Id.ToString(),
                    Text = f.FacultyName
                }).ToList();
        }
    }
}