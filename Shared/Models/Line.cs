using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shared.Models;

namespace Shared.Models
{
    [Table("line")]
    public class Line
    {
        [Key]
        [Column("id_line")]
        public int Id { get; set; }

        [Required]
        [Column("name_category")]
        [StringLength(255)]
        public string Name { get; set; } = string.Empty;

        // Khóa ngoại liên kết với Category
        [Column("id_category")]
        public int IdCategory { get; set; }

        [ForeignKey("IdCategory")]
        public Category? Category { get; set; }

        // Quan hệ với Product (1 Line có nhiều Product)
        public ICollection<Product>? Products { get; set; }
    }
}
