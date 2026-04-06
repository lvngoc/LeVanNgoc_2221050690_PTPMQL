using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FirstWebMVC.Data;
using FirstWebMVC.Models.Entities;

namespace FirstWebMVC.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // READ - Hiển thị danh sách sinh viên
        public async Task<IActionResult> Index(string searchString)
{
    var students = await _context.Students.ToListAsync();

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

        // Hiển thị form thêm sinh viên
        public IActionResult Create()
        {
            return View();
        }

        // Nhận dữ liệu từ form
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

    return View(student);
}

        // ================= UPDATE =================

        // Hiển thị form chỉnh sửa
        public IActionResult Edit(int id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // Lưu dữ liệu chỉnh sửa
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

    return View(student);
    }

        // ================= DELETE =================

        // Hiển thị xác nhận xoá
        public IActionResult Delete(int id)
        {
            var student = _context.Students.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                ViewBag.Message = "Không tìm thấy sinh viên để xoá!";
                return View("NotFound");
                }
                return View(student);
}
                
                // POST: Xác nhận xoá
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
                }
}