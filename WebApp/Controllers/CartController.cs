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



            var colorSizeList = cartItems
       .GroupBy(v => v.IdColor)
       .Select(group => new
       {
           ColorId = group.Key,
           ColorName = group.First().Color.NameColor,
           ColorHex = group.First().Color.ColorCode,

           Sizes = group.Select(v => new
           {
               v.IdSize,
               v.Size.SizeValue,
               Quantity = v.Quantity,
               VariantId = v.IdVariant
           }).ToList(),

           Images = group.SelectMany(v => v.Images.Select(img => img.ImageUrl)).Distinct().ToList()
       })
       .ToList();

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


        // GET: api/cart - Lấy giỏ hàng
        // [HttpGet]
        // public async Task<IActionResult> GetCart(string userId)
        // {
        //     var cart = await _context.Carts
        //         .Include(c => c.CartItems)
        //         .ThenInclude(ci => ci.Product)
        //         .FirstOrDefaultAsync(c => c.UserId == userId);

        //     if (cart == null)
        //         return NotFound(new { message = "Giỏ hàng trống" });

        //     return Ok(cart);
        // }

        // POST: api/cart - Thêm sản phẩm vào giỏ hàng
        // [HttpPost]
        // public async Task<IActionResult> AddToCart(string userId, int productId, int quantity)
        // {
        //     var cart = await _context.Carts
        //         .Include(c => c.CartItems)
        //         .FirstOrDefaultAsync(c => c.UserId == userId);

        //     if (cart == null)
        //     {
        //         cart = new Cart { UserId = userId };
        //         _context.Carts.Add(cart);
        //         await _context.SaveChangesAsync();
        //     }

        //     var product = await _context.Products.FindAsync(productId);
        //     if (product == null)
        //         return NotFound(new { message = "Sản phẩm không tồn tại" });

        //     var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
        //     if (cartItem != null)
        //     {
        //         cartItem.Quantity += quantity;
        //     }
        //     else
        //     {
        //         cart.CartItems.Add(new CartItem { ProductId = productId, Quantity = quantity });
        //     }

        //     await _context.SaveChangesAsync();
        //     return Ok(cart);
        // }

        // PUT: api/cart/{id} - Cập nhật số lượng sản phẩm
        // [HttpPut("{id}")]
        // public async Task<IActionResult> UpdateCartItem(int id, int quantity)
        // {
        //     var cartItem = await _context.CartItems.FindAsync(id);
        //     if (cartItem == null)
        //         return NotFound(new { message = "Không tìm thấy sản phẩm trong giỏ hàng" });

        //     cartItem.Quantity = quantity;
        //     await _context.SaveChangesAsync();

        //     return Ok(cartItem);
        // }

        // DELETE: api/cart/{id} - Xóa sản phẩm khỏi giỏ hàng
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> RemoveFromCart(int id)
        // {
        //     var cartItem = await _context.CartItems.FindAsync(id);
        //     if (cartItem == null)
        //         return NotFound(new { message = "Không tìm thấy sản phẩm trong giỏ hàng" });

        //     _context.CartItems.Remove(cartItem);
        //     await _context.SaveChangesAsync();

        //     return Ok(new { message = "Đã xóa sản phẩm khỏi giỏ hàng" });
        // }
    }
}
