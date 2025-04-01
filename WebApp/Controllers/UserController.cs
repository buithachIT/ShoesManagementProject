using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApp.data;
using Shared.Models;
using Org.BouncyCastle.Crypto.Generators;

public class UserController : Controller
{
    private readonly ApplicationDbContext _context;

    public UserController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View();
    }
    public async Task<IActionResult> Edit(int id)
    {
        var user = await _context.User.FindAsync(id);
        if (user == null) return NotFound();

        var model = new UserEditViewModel
        {
            Id = user.IdUser,
            Fullname = user.FullName,
            Email = user.Email,
            Phone = user.Phone,

        };

        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(UserEditViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var user = await _context.User.FindAsync(model.Id);
        if (user == null) return NotFound();

        user.FullName = model.Fullname;
        user.Email = model.Email;
        user.Phone = model.Phone;
        
        // Cập nhật mật khẩu nếu có nhập mới
        if (!string.IsNullOrEmpty(model.NewPassword))
        {
            user.PasswordHash = model.NewPassword;
        }

        _context.User.Update(user);
        await _context.SaveChangesAsync();

        return RedirectToAction("Edit", new { id = model.Id });
    }
}
