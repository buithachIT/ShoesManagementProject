using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shared.Models;
namespace Shared.Models
{
    [Table("color")]
    public class Color
    {
        [Key]
        [Column("id_color")]
        public int IdColor { get; set; }

        [Required]
        [Column("color_name")]
        public string NameColor { get; set; }

        [Required]
        [Column("color_code")]
        public string ColorCode { get; set; }
        public ICollection<ProductVariant>? ProductVariant { get; set; }
    }
}
