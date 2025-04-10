using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models
{
    [Table("invoicedetail")]
    public class InvoiceDetail
    {
        [Key]
        [Column("id_invoice")]
        public int IdInvoice { get; set; }

        [Column("id_variant")]
        public int IdVariant { get; set; }

        [Column("quantity")]
        public int Quantity { get; set; }

        [Column("sub_total")]
        public int SubTotal { get; set; }

        [ForeignKey("IdInvoice")]
        public Invoice Invoice { get; set; }

        [ForeignKey("IdVariant")]
        public ProductVariant ProductVariant { get; set; }

    }
}
