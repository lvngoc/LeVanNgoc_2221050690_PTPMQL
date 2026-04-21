using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FirstWebMVC.Data;
using FirstWebMVC.Models.Entities;

namespace FirstWebMVC.Controllers
{
    public class OrderDetailController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrderDetailController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ================= INDEX =================
        public async Task<IActionResult> Index()
        {
            var data = _context.OrderDetail
                .Include(o => o.Order)
                    .ThenInclude(o => o.Customer)
                .Include(o => o.Product);

            return View(await data.ToListAsync());
        }

        // ================= DETAILS =================
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var orderDetail = await _context.OrderDetail
                .Include(o => o.Order)
                    .ThenInclude(o => o.Customer)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (orderDetail == null) return NotFound();

            return View(orderDetail);
        }

        // ================= CREATE =================
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(
                _context.Order.Include(o => o.Customer),
                "Id",
                "Id"
            );

            ViewData["ProductId"] = new SelectList(
                _context.Product,
                "Id",
                "ProductName"
            );

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,ProductId,Quantity")] OrderDetail orderDetail)
        {
            if (ModelState.IsValid)
            {
                // 🔥 LẤY GIÁ TỰ ĐỘNG
                var product = await _context.Product.FindAsync(orderDetail.ProductId);
                if (product != null)
                {
                    orderDetail.Price = product.Price;
                }

                _context.Add(orderDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Id", orderDetail.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "ProductName", orderDetail.ProductId);

            return View(orderDetail);
        }

        // ================= EDIT =================
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var orderDetail = await _context.OrderDetail.FindAsync(id);
            if (orderDetail == null) return NotFound();

            ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Id", orderDetail.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "ProductName", orderDetail.ProductId);

            return View(orderDetail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,OrderId,ProductId,Quantity")] OrderDetail orderDetail)
        {
            if (id != orderDetail.Id) return NotFound();

            if (ModelState.IsValid)
            {
                var product = await _context.Product.FindAsync(orderDetail.ProductId);
                if (product != null)
                {
                    orderDetail.Price = product.Price;
                }

                _context.Update(orderDetail);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            ViewData["OrderId"] = new SelectList(_context.Order, "Id", "Id", orderDetail.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Product, "Id", "ProductName", orderDetail.ProductId);

            return View(orderDetail);
        }

        // ================= DELETE =================
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var orderDetail = await _context.OrderDetail
                .Include(o => o.Order)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (orderDetail == null) return NotFound();

            return View(orderDetail);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderDetail = await _context.OrderDetail.FindAsync(id);

            if (orderDetail != null)
            {
                _context.OrderDetail.Remove(orderDetail);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderDetailExists(int id)
        {
            return _context.OrderDetail.Any(e => e.Id == id);
        }
    }
}