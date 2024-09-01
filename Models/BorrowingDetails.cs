namespace LibraryManagementSystem.Models
{
    public class BorrowingDetails
    {
        public int BorrowingDetailsId { get; set; }
        public int BorrowingId { get; set; } // Foreign key for Borrowing
        public int BookId { get; set; }

        // Navigation property for the related borrowing
        public Borrowing Borrowing { get; set; }
    }
}
