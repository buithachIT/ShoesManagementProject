// using Microsoft.AspNetCore.Mvc;
// using Shared.Models; // Import model User
// using WebApp.data; // Import DbContext
// using Microsoft.AspNetCore.Http;
// using System.Linq;

// namespace WebApp.Controllers
// {
//     public class CartController : Controller
//     {
//         private readonly ApplicationDbContext _context;

//         public CartController(ApplicationDbContext context)
//         {
//             _context = context;
//         }
//     public async Task<IActionResult> Index(string userId)
//     {
//         var cart = await _context.Carts
//             .Include(c => c.CartItems)
//             .ThenInclude(ci => ci.Product)
//             .FirstOrDefaultAsync(c => c.UserId == userId);

//         if (cart == null)
//             cart = new Cart { CartItems = new List<CartItem>() };

//         return View(cart);
//     }

//     // GET: api/cart - Lấy giỏ hàng
//         // [HttpGet]
//         // public async Task<IActionResult> GetCart(string userId)
//         // {
//         //     var cart = await _context.Carts
//         //         .Include(c => c.CartItems)
//         //         .ThenInclude(ci => ci.Product)
//         //         .FirstOrDefaultAsync(c => c.UserId == userId);

//         //     if (cart == null)
//         //         return NotFound(new { message = "Giỏ hàng trống" });

//         //     return Ok(cart);
//         // }

//         // POST: api/cart - Thêm sản phẩm vào giỏ hàng
//         // [HttpPost]
//         // public async Task<IActionResult> AddToCart(string userId, int productId, int quantity)
//         // {
//         //     var cart = await _context.Carts
//         //         .Include(c => c.CartItems)
//         //         .FirstOrDefaultAsync(c => c.UserId == userId);

//         //     if (cart == null)
//         //     {
//         //         cart = new Cart { UserId = userId };
//         //         _context.Carts.Add(cart);
//         //         await _context.SaveChangesAsync();
//         //     }

//         //     var product = await _context.Products.FindAsync(productId);
//         //     if (product == null)
//         //         return NotFound(new { message = "Sản phẩm không tồn tại" });

//         //     var cartItem = cart.CartItems.FirstOrDefault(ci => ci.ProductId == productId);
//         //     if (cartItem != null)
//         //     {
//         //         cartItem.Quantity += quantity;
//         //     }
//         //     else
//         //     {
//         //         cart.CartItems.Add(new CartItem { ProductId = productId, Quantity = quantity });
//         //     }

//         //     await _context.SaveChangesAsync();
//         //     return Ok(cart);
//         // }

//         // PUT: api/cart/{id} - Cập nhật số lượng sản phẩm
//         // [HttpPut("{id}")]
//         // public async Task<IActionResult> UpdateCartItem(int id, int quantity)
//         // {
//         //     var cartItem = await _context.CartItems.FindAsync(id);
//         //     if (cartItem == null)
//         //         return NotFound(new { message = "Không tìm thấy sản phẩm trong giỏ hàng" });

//         //     cartItem.Quantity = quantity;
//         //     await _context.SaveChangesAsync();

//         //     return Ok(cartItem);
//         // }

//         // DELETE: api/cart/{id} - Xóa sản phẩm khỏi giỏ hàng
//         // [HttpDelete("{id}")]
//         // public async Task<IActionResult> RemoveFromCart(int id)
//         // {
//         //     var cartItem = await _context.CartItems.FindAsync(id);
//         //     if (cartItem == null)
//         //         return NotFound(new { message = "Không tìm thấy sản phẩm trong giỏ hàng" });

//         //     _context.CartItems.Remove(cartItem);
//         //     await _context.SaveChangesAsync();

//         //     return Ok(new { message = "Đã xóa sản phẩm khỏi giỏ hàng" });
//         // }
//     }
// }
