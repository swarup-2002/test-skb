namespace LibraryManagementSystem.DTOs.MemberDTO
{
    public class MemberViewModel
    {
        public int MemberId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsActive { get; set; }
    }
}
