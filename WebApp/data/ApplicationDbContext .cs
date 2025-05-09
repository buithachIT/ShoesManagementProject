using Microsoft.EntityFrameworkCore;
using Shared.Models;
using Shared.Models;
namespace WebApp.data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Thêm DbSet cho bảng trong database
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Line> Lines { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ProductVariant> ProductVariants { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public DbSet<Address> Addresses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>()
                .HasKey(c => new { c.IdUser, c.IdVariant });
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<InvoiceDetail>()
                .HasKey(id => new { id.IdInvoice, id.IdVariant });
        }
    }
}