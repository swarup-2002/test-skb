namespace LibraryManagementSystem.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string Name { get; set; }

        // Navigation property for many-to-many relationship with Book
        public ICollection<Book> Books { get; set; }
    }
}
