using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    [Table("invoice")]
    public class Invoice
    {
        [Key]
        [Column("id_invoice")]
        public int IdInvoice { get; set; }

        [Column("id_user")]
        public int IdUser { get; set; }

        [Column("customerName")]
        public string CustomerName { get; set; }

        [Column("customerPhone")]
        public string CustomerPhone { get; set; }

        [Column("InvoiceDate")]
        public DateTime InvoiceDate { get; set; }

        [Column("totalAmount")]
        public double TotalAmount { get; set; }

        [Column("status")]
        public string Status { get; set; }

        [Column("customerAddress")]
        public string CustomerAddress { get; set; }

        [ForeignKey("IdUser")]
        public User User { get; set; }

    }
}
