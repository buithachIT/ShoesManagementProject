using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shared.Models;
namespace Shared.Models
{
    [Table("product")]
    public class Product
    {
        [Key]
        [Column("id_product")]

        public int IdProduct { get; set; }

        [Required]
        [Column("name_product")]
        public string? NameProduct { get; set; }

        [Required]
        [Column("id_line")]
        public int IdLine { get; set; }

        [Required]
        [Column("id_brand")]
        public int IdBrand { get; set; }

        [Column("description")]
        public string? Description { get; set; }

        [Column("material")]
        [MaxLength(255)]
        public string? Material { get; set; }

        [Column("price")]
        public decimal? Price { get; set; }

        [Column("imageUrl")]
        [MaxLength(255)]
        public string? ImageUrl { get; set; }

        [Column("releasedate")]
        public DateTime? Releasedate { get; set; }

        [Column("status")]
        [MaxLength(50)]
        public string? Status { get; set; }

        [ForeignKey("IdLine")]
        public Line Line { get; set; }
    }
        
}