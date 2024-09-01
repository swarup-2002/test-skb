using Microsoft.AspNetCore.Identity;

namespace LibraryManagementSystem.Models
{
    public class ApplicationUser : IdentityUser
    {
        // You can add additional properties here if needed
        public virtual ICollection<Member> Members { get; set; }
    }
}
