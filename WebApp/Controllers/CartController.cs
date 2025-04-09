using Microsoft.AspNetCore.Mvc;
using Shared.Models; // Import model User
using WebApp.data; // Import DbContext
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var userIdString = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userIdString))
            {
                return Redirect("/login");
            }

            int idUser = int.Parse(userIdString);
            var cartItems = await _context.Carts
                .Where(c => c.IdUser == idUser)
                .Include(c => c.Variant)
                    .ThenInclude(pv => pv.Product)
                .Include(c => c.Variant.Color)
                .Include(c => c.Variant.Size)
                .Include(c => c.Variant.Images)
                .ToListAsync();



            return View(cartItems);
        }


        public async Task<IActionResult> AddToCart(int idVariant, int quantity)
        {
            // Lấy ID user từ session
            int idUser = int.Parse(HttpContext.Session.GetString("UserId"));

            // Kiểm tra đã có sản phẩm đó trong cart chưa
            var existingCartItem = await _context.Carts
                .FirstOrDefaultAsync(c => c.IdUser == idUser && c.IdVariant == idVariant);

            if (existingCartItem != null)
            {
                // Nếu có thì cộng dồn số lượng
                existingCartItem.Quantity += quantity;
            }
            else
            {
                // Nếu chưa có thì thêm mới
                var newCartItem = new Cart
                {
                    IdUser = idUser,
                    IdVariant = idVariant,
                    Quantity = quantity,
                    CreatedDate = DateTime.Now
                };

                _context.Carts.Add(newCartItem);
            }

            await _context.SaveChangesAsync();
            ViewBag.CartCount = _context.Carts.Where(c => c.IdUser == idUser).Sum(c => c.Quantity);

            return RedirectToAction("Index"); // hoặc chuyển hướng tới trang giỏ hàng
        }
    }
}
