using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models
{
     [Table("brand")]
    public class Brand
    {
        [Key]
        [Column("id_brand")]
        public int IdBrand { get; set; }  // id_brand (Khóa chính, Auto Increment)

        [Required]
        [StringLength(255)]
         [Column("name_brand")]
        public string NameBrand { get; set; } // name_brand (Không được null, tối đa 255 ký tự)
        [Column("info_brand")]
        public string? InfoBrand { get; set; } // info_brand (Có thể null)
        public ICollection<Product>? Products { get; set; }
    }
}