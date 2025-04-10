using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shared.Models;

namespace Shared.Models
{
    [Table("size")]
    public class Size
    {
        [Key]
        [Column("id_size")]
        public int IdSize { get; set; }

        [Required]
        [Column("size_value")]
        public decimal SizeValue { get; set; }

        [Required]
        [Column("type")]
        public string Type { get; set; }

        public ICollection<ProductVariant>? ProductVariants { get; set; }

        public override string ToString()
        {
            return $"{Type} - {SizeValue:0.##}";
        }
    }
}

