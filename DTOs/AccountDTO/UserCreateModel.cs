using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.DTOs.AccountDTO
{
    public class UserCreateModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        [StringLength(50)]
        public string PhoneNumber { get; set; }
        public string RoleName { get; set; }
    }
}
