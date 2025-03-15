using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using WebApp.data;
using Shared.Models;
public class ProductController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProductController(ApplicationDbContext context)
    {
        _context = context;
    }
[Route("Product/ByCategory/{id}")]
[Route("Product/ByCategory/{id}/{lineId?}")]
public async Task<IActionResult> ByCategory(int id, int? lineId)
{
    var products = _context.Products
        .Include(p => p.Line)
        .ThenInclude(l => l.Category)
        .Where(p => p.Line.IdCategory == id);

    string? lineName = null; // Khai báo biến để lưu tên dòng sản phẩm

    if (lineId.HasValue)
    {
        products = products.Where(p => p.IdLine == lineId.Value);
        lineName = await _context.Lines
            .Where(l => l.Id == lineId.Value)
            .Select(l => l.Name)
            .FirstOrDefaultAsync();
    }

    var categoryName = await _context.Categories
        .Where(c => c.Id == id)
        .Select(c => c.Name)
        .FirstOrDefaultAsync();

    var lines = await _context.Lines
        .Where(l => l.IdCategory == id)
        .ToListAsync();

    ViewData["Category"] = categoryName;
    ViewData["Lines"] = lines;
    ViewData["SelectedLine"] = lineId;
    ViewData["LineName"] = lineName; // Lưu tên dòng sản phẩm vào ViewData
ViewData["Categories"] = _context.Categories.Include(c => c.Lines).ToList();

    return View(await products.ToListAsync());
}


    [HttpGet]
public IActionResult Index(decimal? minPrice, decimal? maxPrice, bool? inStock, DateTime? releaseDate, string material)
{
    var products = _context.Products.AsQueryable();

    if (minPrice.HasValue)
    {
        products = products.Where(p => p.Price >= minPrice.Value);
    }

    if (maxPrice.HasValue)
    {
        products = products.Where(p => p.Price <= maxPrice.Value);
    }

    // if (inStock.HasValue)
    // {
    //     products = products.Where(p => p.Status == inStock.Value);
    // }

    // if (releaseDate.HasValue)
    // {
    //     products = products.Where(p => p.Releasedate.Date == releaseDate.Value.Date);
    // }

    if (!string.IsNullOrEmpty(material))
    {
        products = products.Where(p => p.Material.Contains(material));
    }

    var materials = _context.Products.Select(p => p.Material).Distinct().ToList();
    ViewData["Materials"] = materials;

    return View(products.ToList());
}

}
