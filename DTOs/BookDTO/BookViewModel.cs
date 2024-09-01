namespace LibraryManagementSystem.DTOs.BookDTO
{
    public class BookViewModel
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public List<int> AuthorIds { get; set; }
        public bool IsAvailable { get; set; }
        public int CategoryId { get; set; }
    }
}
