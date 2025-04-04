using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    [Table("Image")]
    public class Image
    {
        [Key]
        [Column("id_image")]
        public int IdImage { get; set; }

        [Column("imageUrl")]
        public string ImageUrl { get; set; }

        [Column("is_primary")]
        public bool IsPrimary { get; set; }

        [Column("id_product")]
        public int IdProduct { get; set; }

        [ForeignKey("IdProduct")]
        public virtual Product Product { get; set; }
    }
}
