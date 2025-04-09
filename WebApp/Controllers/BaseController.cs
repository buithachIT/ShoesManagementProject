using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using WebApp.data;


public class BaseController : Controller
{
    protected readonly ApplicationDbContext _context;

    public BaseController(ApplicationDbContext context)
    {
        _context = context;
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        ViewData["Categories"] = _context.Categories.Include(c => c.Lines).ToList();
        ViewData["Lines"] = _context.Lines.ToList();
        ViewData["Materials"] = _context.Products
            .Where(p => !string.IsNullOrEmpty(p.Material))
            .Select(p => p.Material)
            .Distinct()
            .ToList();

        base.OnActionExecuting(context);
    }
}
