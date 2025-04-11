using Microsoft.AspNetCore.Mvc;
using Shared.Models; // Import model User
using WebApp.data; // Import DbContext
using Microsoft.AspNetCore.Http;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Controllers
{
    public class CartController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context) : base(context)
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
            var userIdString = HttpContext.Session.GetString("UserId");
            Console.WriteLine("Checkkkkkkkkkk User>>>>>>>>>", userIdString);

            if (string.IsNullOrEmpty(userIdString))
            {
                return Redirect("/login");
            }

            int idUser = int.Parse(userIdString);

            var existingCartItem = await _context.Carts
                .FirstOrDefaultAsync(c => c.IdUser == idUser && c.IdVariant == idVariant);

            if (existingCartItem != null)
            {
                existingCartItem.Quantity += quantity;
            }
            else
            {
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


            //Luu vao session
            var variant = await _context.ProductVariants
                .Include(v => v.Product)
                .Include(v => v.Images)
                .FirstOrDefaultAsync(v => v.IdVariant == idVariant);
            Console.WriteLine($"Variant ID: {variant.IdVariant}, Imagekkkkkkkkkkkk Count>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>: {variant.Images?.Count}{variant.Images.FirstOrDefault()?.ImageUrl}");

            decimal subTotal = variant.Product.Price * quantity;


            string image = variant.Images != null && variant.Images.Count > 0
                ? variant.Images.First().ImageUrl
                : "default.png";

            string name = variant.Product.NameProduct;
            var sessionCart = HttpContext.Session.GetObjectFromJson<List<CartItemViewModel>>("Cart") ?? new List<CartItemViewModel>();

            var existingSessionItem = sessionCart.FirstOrDefault(c => c.Id_Variant == idVariant);

            if (existingSessionItem != null)
            {
                existingSessionItem.Quantity += quantity;
                existingSessionItem.Sub_Total += subTotal;
            }
            else
            {
                Console.WriteLine($"Variant>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>lllllllllllllkkkkkkk: {image}");
                sessionCart.Add(new CartItemViewModel
                {
                    ProductName = name,
                    ImageUrl = image,
                    Id_Variant = idVariant,
                    Quantity = quantity,
                    Sub_Total = subTotal
                });
            }

            HttpContext.Session.SetObjectAsJson("Cart", sessionCart);
            var debugCart = HttpContext.Session.GetObjectFromJson<List<CartItemViewModel>>("Cart");
            foreach (var item in debugCart)
            {
                Console.WriteLine(">>>> Debug Cart Item: " + item.ImageUrl);
            }
            return RedirectToAction("Index");
        }
    }
}