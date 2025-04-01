using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    [Table("role")]
    public class Role
    {
        [Key]
        [Column("id_role")]
        public int IdRole { get; set; }

        [Required]
        [Column("name_role")]
        public string NameRole { get; set; }

        [Required]
        [Column("description")]
        public string Description { get; set; }

        public ICollection<User>? Users { get; set; }
    }
}
