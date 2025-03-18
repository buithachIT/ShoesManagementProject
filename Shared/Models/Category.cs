using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models
{
    [Table("category")]
    public class Category
    {
        [Key]
        [Column("id_category")]
        public int Id { get; set; }

        [Required]
        [Column("name_category")]
        [StringLength(255)]
        public string Name { get; set; } = string.Empty;
        public ICollection<Line>? Lines { get; set; }
    }
}
