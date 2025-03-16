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
    [Route("Product/ByCategory/{id}/{lineId?}")]
public async Task<IActionResult> ByCategory(int id, int? lineId, int? idBrand, string material)
{
    var products = _context.Products
        .Include(p => p.Line)
        .ThenInclude(l => l.Category)
        .Where(p => p.Line.IdCategory == id);

    // Lọc theo dòng sản phẩm
    if (lineId.HasValue)
    {
        products = products.Where(p => p.IdLine == lineId.Value);
    }

    // Lọc theo thương hiệu
    if (idBrand.HasValue)
    {
        products = products.Where(p => p.IdBrand == idBrand.Value);
    }

    // Lọc theo chất liệu
    if (!string.IsNullOrEmpty(material?.Trim()))
    {
        var materialsList = material.Split(',').Select(m => m.Trim()).ToList();
        products = products.Where(p => materialsList.Any(mat => p.Material.Contains(mat)));
    }

    // Lấy thông tin danh mục
    var categoryName = await _context.Categories
        .Where(c => c.Id == id)
        .Select(c => c.Name)
        .FirstOrDefaultAsync();

    // Lấy danh sách dòng sản phẩm
    var lines = await _context.Lines
        .Where(l => l.IdCategory == id)
        .ToListAsync();

    // Lấy danh sách thương hiệu
    var brands = await _context.Brands.ToListAsync();

    // Lấy danh sách chất liệu
    var materials = await _context.Products
        .Select(p => p.Material)
        .Distinct()
        .ToListAsync();

    // Đảm bảo dữ liệu không bị null
    ViewData["Category"] = categoryName ?? "Không xác định";
    ViewData["Lines"] = lines ?? new List<Line>();
    ViewData["Brands"] = brands ?? new List<Brand>();
    ViewData["Materials"] = materials ?? new List<string>();
    ViewData["SelectedLine"] = lineId;
    ViewData["SelectedBrand"] = idBrand;
    ViewData["SelectedMaterial"] = material;
     ViewData["CategoryId"] = id; 

    return View(await products.ToListAsync());
}
public IActionResult Filter(int? id, int? idLine, int? idBrand, string material)
{
    return RedirectToAction("ByCategory", new
    {
        id = id,
        lineId = idLine,
        idBrand = idBrand,
        material = material
    });
}

}

