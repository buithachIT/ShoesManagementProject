using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models
{
    public class CartItemViewModel
    {
        public int Id_Variant { get; set; }
        public int Quantity { get; set; }
        public decimal Sub_Total { get; set; }
        public string? ImageUrl { get; set; }
        public string? ProductName { get; set; }
    }

    public class CheckoutViewModel
    {
        public int Id_User { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerAddress { get; set; }

        public List<CartItemViewModel> Items { get; set; }
    }
}