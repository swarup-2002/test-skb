namespace LibraryManagementSystem.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }

        // Navigation property for the one-to-many relationship with Book
        public ICollection<Book> Books { get; set; }
    }
}