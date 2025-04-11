using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Shared.Models
{
    [Table("address")]
    public class Address
    {
        [Key]
        [Column("id_address")]
        public int IdAddress { get; set; }

        [Column("id_user")]
        public int IdUser { get; set; }

        [Column("province")]
        public string? Province { get; set; }

        [Column("district")]
        public string? District { get; set; }

        [Column("ward")]
        public string? Ward { get; set; }

        [Column("street")]
        public string? Street { get; set; }

        [Column("address_type")]
        public string? AddressType { get; set; }

        [ForeignKey("IdUser")]
        public User User { get; set; }
    }
}