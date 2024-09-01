using System.ComponentModel.DataAnnotations;
namespace LibraryManagementSystem.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int PublicationYear { get; set; }
        public bool IsAvailable { get; set; }

        // Foreign key for Category
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        // Navigation property for many-to-many relationship with Author
        public ICollection<Author> Authors { get; set; }
    }


    //public class Book
    //{
    //    public int BookId { get; set; }
    //    public string Title { get; set; }
    //    public string AuthorID { get; set; }
    //    public string ISBN { get; set; }
    //    public string Genre { get; set; }
    //    public int PublicationYear { get; set; }
    //    public bool IsAvailable { get; set; }
    //}
}
