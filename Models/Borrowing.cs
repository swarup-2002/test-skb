namespace LibraryManagementSystem.Models
{
    public class Borrowing
    {
        public int BorrowingId { get; set; }
        public int MemberId { get; set; } // Foreign key for Member
        public DateTime BorrowedDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnedDate { get; set; }
        public bool IsOverdue => !ReturnedDate.HasValue && DateTime.Now > DueDate;

        // Navigation property for the related member
        public Member Member { get; set; }

        // Navigation property for the borrowing details (one-to-many relationship)
        public ICollection<BorrowingDetails> BorrowingDetails { get; set; }
    }
}
