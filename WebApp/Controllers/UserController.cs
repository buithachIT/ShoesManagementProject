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

    public async Task<IActionResult> Profile()
    {
        var userId = int.Parse(HttpContext.Session.GetString("UserId"));
        var user = await _context.Users.FindAsync(userId);
        return View(user);
    }

    public async Task<IActionResult> EditProfile()
    {
        var userIdStr = HttpContext.Session.GetString("UserId");
        if (string.IsNullOrEmpty(userIdStr)) return Redirect("/login");

        int idUser = int.Parse(userIdStr);
        var user = await _context.Users.FirstOrDefaultAsync(u => u.IdUser == idUser);
        if (user == null) return NotFound();

        return View(user);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(User updatedUser)
    {
        var user = await _context.Users.FirstOrDefaultAsync(u => u.IdUser == updatedUser.IdUser);
        if (user == null) return NotFound();

        user.FullName = updatedUser.FullName;
        user.Phone = updatedUser.Phone;

        await _context.SaveChangesAsync();
        return RedirectToAction("Profile");
    }
}
