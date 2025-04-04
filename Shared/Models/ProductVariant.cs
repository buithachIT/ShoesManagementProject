using System;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shared.Models;

namespace Shared.Models
{
    [Table("product_variant")]
    public class ProductVariant
    {
        [Key]
        [Column("id_variant")]
        public int IdVariant { get; set; }

        [Column("id_product")]
        public int IdProduct { get; set; }

        [Column("id_color")]
        public int IdColor { get; set; }

        [Column("id_size")]
        public int IdSize { get; set; }


        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("expired_date")]
        public DateTime ExpiredDate { get; set; }

        [ForeignKey("IdProduct")]
        public Product Product { get; set; }

        [ForeignKey("IdColor")]
        public Color Color { get; set; }

        [ForeignKey("IdSize")]
        public Size Size { get; set; }

        public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    }
}
