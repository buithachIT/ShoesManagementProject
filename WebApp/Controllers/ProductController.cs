using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApp.data;
using WebApp.Models;

public class ProductController : Controller
{
    private readonly ApplicationDbContext _context;

    private readonly ILogger<ProductController> _logger;

public ProductController(ApplicationDbContext context, ILogger<ProductController> logger)
{
    _context = context;
    _logger = logger;
}

public async Task<IActionResult> NewProducts()
{
    var products = await _context.Products
        .OrderByDescending(p => p.Releasedate)
        .Take(5)
        .ToListAsync();

    _logger.LogInformation($"Số sản phẩm lấy được: {products.Count}");
    foreach (var p in products)
    {
        _logger.LogInformation($"Tên sản phẩm: {p.NameProduct} - Ngày phát hành: {p.Releasedate}");
    }

    return PartialView("_NewProducts", products);
}
}
