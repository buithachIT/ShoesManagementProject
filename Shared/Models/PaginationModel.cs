using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Shared.Models;

namespace Shared.Models
{
    public class PaginationModel
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
    }
}