using Microsoft.AspNetCore.Identity;

namespace LibraryManagementSystem.Models
{

    public class Member
    {
        public int MemberId { get; set; }
        public string UserId { get; set; } // Foreign key for ApplicationUser
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; } = false;

        // Navigation property for the related user
        public ApplicationUser User { get; set; }

        // Navigation property for borrowings
        public ICollection<Borrowing> Borrowings { get; set; }
    }
    //public class Member
    //{
    //    public int MemberId { get; set; }
    //    public string UserId { get; set; } // Explicit foreign key
    //    public string FullName { get; set; }
    //    public string Email { get; set; }
    //    public string PhoneNumber { get; set; }
    //    public bool IsActive { get; set; }
    //    public bool IsDeleted { get; set; } = false;
    //    public ApplicationUser User { get; set; } // Navigation property
    //}
}
