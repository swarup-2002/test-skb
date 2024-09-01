using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.DTOs.MemberDTO
{
    public class MemberCreateModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        //[Required]
        //public string UserName { get; set; }
        [Required]
        public string FullName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }

        [StringLength(10)]
        [Required]
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        //public List<string> RoleNames { get; set; }
    }
}
