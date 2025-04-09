using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace Shared.Models
{
    [Table("cart")]
    public class Cart
    {
        [Key, Column("id_user", Order = 0)]
        public int IdUser { get; set; }

        [Key, Column("id_variant", Order = 1)]
        public int IdVariant { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("created_date")]
        public DateTime CreatedDate { get; set; }

        // Navigation đến bảng ProductVariant
        [ForeignKey("IdVariant")]
        public ProductVariant Variant { get; set; }
        
    }
}
