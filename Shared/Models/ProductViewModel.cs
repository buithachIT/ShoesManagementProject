
namespace Shared.Models
{
    public class ProductViewModel
    {
        public List<Product> Products { get; set; }
        public int CurrentCategoryId { get; set; }
        public string CategoryName { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public string SortOrder { get; set; }
    }
}