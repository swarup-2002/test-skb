using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.DTOs.BookDTO
{
    public class AddBookModel
    {
        public int BookId { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Title cannot exceed 50 characters")]
        public string Title { get; set; }

        [Required]
        public List<int> AuthorIds { get; set; }  // Updated to handle multiple authors that is One to many relationship between Book and Author

        [Required]
        [RegularExpression(@"^\d{3}-\d{1,5}-\d{1,7}-\d{1,7}-\d{1}$", ErrorMessage = "Invalid ISBN format")]
        public string ISBN { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Range(1600, 2100, ErrorMessage = "Publication year must be between 1600 and 2100")]
        public int PublicationYear { get; set; }
    }

    //public class AddBookDTO
    //{
    //    [Required]
    //    [MaxLength(50, ErrorMessage = "Title cannot exceed 50 characters")]
    //    public string Title { get; set; }

    //    [Required]
    //    public int AuthorID { get; set; }

    //    [Required]
    //    [RegularExpression(@"^\d{3}-\d{1,5}-\d{1,7}-\d{1,7}-\d{1}$", ErrorMessage = "Invalid ISBN format")]
    //    public string ISBN { get; set; }

    //    [Required]
    //    public int CategoryId { get; set; }

    //    [Range(1600, 2100, ErrorMessage = "Publication year must be between 1600 and 2100")]
    //    public int PublicationYear { get; set; }
    //}

}
