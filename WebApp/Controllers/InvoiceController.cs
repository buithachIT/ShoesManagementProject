using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.data;
using Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Filters;
namespace WebApp.Controllers;

public class InvoiceController : BaseController
{
    private readonly ApplicationDbContext _context;

    public InvoiceController(ApplicationDbContext context) : base(context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Checkout()
    {
        var cart = HttpContext.Session.GetObjectFromJson<List<CartItemViewModel>>("Cart");

        if (cart == null || !cart.Any())
        {
            Console.WriteLine("Cart is null or empty>>>>>>>>>>>>"); // Kiểm tra
            TempData["Error"] = "Giỏ hàng trống!";
            return RedirectToAction("Index", "Cart");
        }
        var userIdString = HttpContext.Session.GetString("UserId");
        Console.WriteLine("Checkkkkkkkkkk User>>>>>>>>>" + userIdString);
        if (string.IsNullOrEmpty(userIdString))
        {
            return Redirect("/login");
        }

        int Id_User = int.Parse(userIdString);
        var checkoutModel = new CheckoutViewModel
        {
            Id_User = Id_User,
            Items = cart.Select(item => new CartItemViewModel
            {
                Id_Variant = item.Id_Variant,
                Quantity = item.Quantity,
                Sub_Total = item.Sub_Total
            }).ToList()
        };

        return View(checkoutModel);


    }

    [HttpPost]
    public async Task<IActionResult> Checkout(CheckoutViewModel model)
    {
        if (!ModelState.IsValid)
        {
            Console.WriteLine("Vui lòng nhập4 đũ thong tin=>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
            TempData["Error"] = "Vui lòng nhập đầy đủ thông tin.";
            return View(model);
        }

        // Tạo đơn hàng (Invoice)
        var invoice = new Invoice
        {
            IdUser = model.Id_User,
            CustomerName = model.CustomerName,
            CustomerPhone = model.CustomerPhone,
            CustomerAddress = model.CustomerAddress,
            InvoiceDate = DateTime.Now,
            Status = "Đang xử lý"
        };
        _context.Invoices.Add(invoice);
        await _context.SaveChangesAsync(); // Lưu để có ID hóa đơn

        // Tạo các dòng chi tiết đơn hàng (InvoiceDetail)
        foreach (var item in model.Items)
        {
            var detail = new InvoiceDetail
            {
                IdInvoice = invoice.IdInvoice,
                IdVariant = item.Id_Variant,
                Quantity = item.Quantity,
                SubTotal = item.Sub_Total
            };
            _context.InvoiceDetails.Add(detail);
        }

        await _context.SaveChangesAsync();

        var cartItems = _context.Carts.Where(c => c.IdUser == invoice.IdUser);
        _context.Carts.RemoveRange(cartItems);
        await _context.SaveChangesAsync();
        HttpContext.Session.Remove("Cart");

        TempData["Success"] = "Đặt hàng thành công!";
        TempData["ClearCart"] = true;
        return RedirectToAction("Index", "Home");
    }

    public IActionResult CheckoutSuccess()
    {
        return View();
    }
}
