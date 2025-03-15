using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.data;
using Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApp.Controllers;

public class HomeController : Controller
{    private readonly ApplicationDbContext _context;

    
     public HomeController(ApplicationDbContext context)
    {
        _context = context; 
    }
    
    public IActionResult Index()

    {
        ViewData["Categories"] = _context.Categories
        .Include(c => c.Lines) 
        .ToList();
        var products =  _context.Products
        .OrderByDescending(p => p.Releasedate)
        .Take(5)
        .ToList();

        return View(products);

    }

    public IActionResult GetCategory()
        {
            var categories = _context.Categories
                .Include(c => c.Lines) // Nếu có bảng Lines liên kết
                .ToList();

            return View(categories);
        }
         public override void OnActionExecuting(ActionExecutingContext context)
        {
            ViewData["Categories"] = _context.Categories
                .Include(c => c.Lines)
                .ToList();

            base.OnActionExecuting(context);
        }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
