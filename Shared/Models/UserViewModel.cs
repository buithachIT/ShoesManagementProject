using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Shared.Models
{
    public class UserViewModel
    {
        public int IdUser { get; set; }
        public string Email { get; set; }
        public string Fullname { get; set; }
        public int? Phone { get; set; }
        public string ProfileImage { get; set; }
    }
}