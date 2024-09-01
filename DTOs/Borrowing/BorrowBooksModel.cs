namespace LibraryManagementSystem.DTOs.Borrowing
{
    public class BorrowBooksModel
    {
        public int MemberId { get; set; }
        public List<int> BookIds { get; set; }
    }
}
