using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models
{
     [Table("brand")]
    public class Brand
    {
        [Key]
        [Column("id_brand")]
        public int Id { get; set; }  // id_brand (Khóa chính, Auto Increment)

        [Required]
        [StringLength(255)]
         [Column("name_brand")]
        public string Name { get; set; } // name_brand (Không được null, tối đa 255 ký tự)
        [Column("info_brand")]
        public string? Info { get; set; } // info_brand (Có thể null)
    }
}