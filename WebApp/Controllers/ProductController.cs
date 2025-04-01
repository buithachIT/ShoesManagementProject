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

[Route("Product/ByCategory/{id}/{lineId?}/{pageNumber:int?}")]
public async Task<IActionResult> ByCategory(int id, int? lineId, int? idBrand, string material,[FromQuery] int pageSize = 9, [FromQuery] int pageNumber = 1)
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

    int skip = (pageNumber - 1) * pageSize;
    var pagedProducts = await productsQuery
        .Skip(skip)
        .Take(pageSize)
        .ToListAsync();

     
    var totalItems = await _context.Products.CountAsync(p => p.IdProduct == id);
    int totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
    var viewModel = new PaginationViewModel<Product>
    {
        Items = pagedProducts,
        PageNumber = pageNumber,
        PageSize = pageSize,
        TotalItems = totalItems
    };

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
              
    ViewData["Categories"] = _context.Categories.ToList();
    ViewData["Lines"] = _context.Lines.ToList();
    ViewData["Category"] = categoryName;
    ViewData["Lines"] = lines;
    ViewData["Brands"] = brands;
    ViewData["Materials"] = materials;
    ViewData["SelectedLine"] = lineId;
    ViewData["SelectedBrand"] = idBrand;
    ViewData["SelectedMaterial"] = material;
    ViewData["CategoryId"] = id;

    
    var routeValues = new Dictionary<string, object>
{
    { "id", id },
    { "lineId", lineId ?? (object)DBNull.Value },
    { "idBrand", idBrand ?? (object)DBNull.Value },
    { "material", material ?? (object)DBNull.Value }
};
    return View(viewModel);
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
