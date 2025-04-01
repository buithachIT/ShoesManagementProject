using Shared.Models;
namespace Shared.Models
{
    public class UserEditViewModel
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public int? Phone { get; set; }
        public string NewPassword { get; set; }
        public bool IsActive { get; set; }
        public bool EmailValue { get; set; }
    }
}