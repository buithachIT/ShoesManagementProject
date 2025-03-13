using Microsoft.EntityFrameworkCore;
using  WebApp.Models;
namespace WebApp.data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Thêm DbSet cho bảng trong database
        public DbSet<User> User { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}