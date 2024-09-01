using LibraryManagementSystem.DTOs.BookDTO;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Data.Repositories.Abstract
{
    public interface IBookRepository
    {
        Task<IEnumerable<BookViewModel>> GetAllBooksAsync();
        Task<BookViewModel> GetBookByIdAsync(int id);
        Task<BookViewModel> AddBookAsync(AddBookModel bookDTO);
        Task<BookViewModel> UpdateBookAsync(UpdateBookModel book);
        Task<bool> DeleteBookAsync(int id);
        Task<IEnumerable<BookViewModel>> FilterBooksAsync(
            string title,
            string authorId,
            string isbn,
            int? publicationYear,
            bool? isAvailable,
            int? category);
    }
}
