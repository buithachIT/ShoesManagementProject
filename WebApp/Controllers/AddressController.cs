using Microsoft.AspNetCore.Mvc;
using Shared.Models; // Import model User
using WebApp.data; // Import DbContext
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Controllers
{
    public class AddressController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddressController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var userIdStr = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userIdStr)) return Redirect("/login");

            int userId = int.Parse(userIdStr);
            var addresses = _context.Addresses
                .Where(a => a.IdUser == userId)
                .Include(a => a.User)
                .AsNoTracking()
                .ToList();

            return View(addresses);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Address address)
        {
            var userIdStr = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userIdStr)) return Redirect("/login");

            address.IdUser = int.Parse(userIdStr);
            _context.Add(address);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var address = _context.Addresses.Find(id);
            if (address == null) return NotFound();
            return View(address);
        }

        [HttpPost]
        public IActionResult Edit(Address updatedAddress)
        {
            _context.Update(updatedAddress);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var addr = await _context.Addresses.FindAsync(id);
            if (addr != null)
            {
                _context.Addresses.Remove(addr);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}