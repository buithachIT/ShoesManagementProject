using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    [Table("image")]
    public class Image
    {
        [Key]
        [Column("id_image")]
        public int IdImage { get; set; }

        [Column("imageUrl")]
        public required string ImageUrl { get; set; }

        [Column("isPrimary")]
        public bool IsPrimary { get; set; }

        [Column("id_variant")]
        public int IdVariant { get; set; }

        [Column("id_product")]

        public int IdProduct { get; set; }

        [Column("id_color")]

        public int IdColor { get; set; }

        [ForeignKey("IdProduct")]
        public virtual Product Product { get; set; }
        [ForeignKey("IdColor")]
        public virtual Color Color { get; set; }


        [ForeignKey("IdVariant")]
        public virtual ProductVariant ProductVariant { get; set; }
    }
}
