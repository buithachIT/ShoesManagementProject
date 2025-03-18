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
public IActionResult ByCategory(int page = 1)
{
    int pageSize = 10; 
    var totalItems = _context.Products.Count();
    var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

    var products = _context.Products
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .ToList();

    var paginationModel = new PaginationModel
    {
        CurrentPage = page,
        TotalPages = totalPages
    };

    ViewData["Pagination"] = paginationModel;
    return View(products);
}

    [Route("Product/ByCategory/{id}/{lineId?}")]
public async Task<IActionResult> ByCategory(int id, int? lineId, int? idBrand, string material, int page = 1, int pageSize = 10)
{
 
    var productsQuery = _context.Products
        .Include(p => p.Line)
        .ThenInclude(l => l.Category)
        .Where(p => p.Line.IdCategory == id)
        .AsQueryable(); 

    if (lineId.HasValue)
    {
        productsQuery = productsQuery.Where(p => p.IdLine == lineId.Value);
    }


    if (idBrand.HasValue)
    {
        productsQuery = productsQuery.Where(p => p.IdBrand == idBrand.Value);
    }

   
    if (!string.IsNullOrEmpty(material?.Trim()))
    {
        var materialsList = material.Split(',').Select(m => m.Trim()).ToList();
        productsQuery = productsQuery.Where(p => materialsList.Any(mat => EF.Functions.Like(p.Material, $"%{mat}%")));
    }

   
    int totalProducts = await productsQuery.CountAsync();


    var pagedProducts = await productsQuery
        .Skip((page - 1) * pageSize)
        .Take(pageSize)
        .ToListAsync();

    var categoryName = await _context.Categories
        .Where(c => c.Id == id)
        .Select(c => c.Name)
        .FirstOrDefaultAsync() ?? "Không xác định";


    var lines = await _context.Lines
        .Where(l => l.IdCategory == id)
        .ToListAsync();

    var brands = await _context.Brands.ToListAsync();

   
    var materials = await _context.Products
        .Select(p => p.Material)
        .Where(m => !string.IsNullOrEmpty(m))
        .Distinct()
        .ToListAsync();

    ViewData["Category"] = categoryName;
    ViewData["Lines"] = lines;
    ViewData["Brands"] = brands;
    ViewData["Materials"] = materials;
    ViewData["SelectedLine"] = lineId;
    ViewData["SelectedBrand"] = idBrand;
    ViewData["SelectedMaterial"] = material;
    ViewData["CategoryId"] = id;

    ViewData["TotalPages"] = (int)Math.Ceiling((double)totalProducts / pageSize);
    ViewData["CurrentPage"] = page;
    ViewData["PageSize"] = pageSize;
    var routeValues = new Dictionary<string, object>
{
    { "id", id },
    { "lineId", lineId ?? (object)DBNull.Value },
    { "idBrand", idBrand ?? (object)DBNull.Value },
    { "material", material ?? (object)DBNull.Value }
};

    return View(pagedProducts);
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
