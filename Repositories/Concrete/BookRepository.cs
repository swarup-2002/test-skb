using AutoMapper;
using LibraryManagementSystem.DTOs.BookDTO;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Data.Repositories.Abstract
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;
        private readonly IMapper _mapper;

        public BookRepository(LibraryContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<BookViewModel>> GetAllBooksAsync()
        {
            // Retrieve all books with their associated authors
            var books = await _context.Books
                                      .Include(b => b.Authors)
                                      .ToListAsync();

            // Map the list of Book entities to ShowBookDTO
            var mappedBooks = _mapper.Map<List<BookViewModel>>(books);
            return mappedBooks;

            // Manually populate the AuthorIds property for each DTO
            //foreach (var mappedBook in mappedBooks)
            //{
            //    // Use the Authors property of the Book entity to set AuthorIds
            //    var book = books.First(b => b.BookId == mappedBook.BookId);
            //    mappedBook.AuthorIds = book.Authors.Select(a => a.AuthorId).ToList();
            //}
        }

        public async Task<BookViewModel> GetBookByIdAsync(int id)
        {
            var book =  await _context.Books
                .Include(b => b.Authors)    // This .Include(b => b.Authors) include the Icollection<Author> entity into the Query result book
                .FirstOrDefaultAsync(b => b.BookId == id);

            if (book == null)
            {
                return null;
            }

            var mapped = _mapper.Map<BookViewModel>(book);

            // Manually map the list of AuthorIds to the ShowBookDTO.
            //mapped.AuthorIds = book.Authors.Select(a => a.AuthorId).ToList();
            // a => a.AuthorId: This is a lambda expression. It defines a function that takes
            // each Author object (a) from the book.Authors collection and returns its AuthorId

            return mapped;
        }


        public async Task<BookViewModel> AddBookAsync(AddBookModel bookDTO)
        {
            // Map AddBookDTO to Book
            var mappedBook = _mapper.Map<Book>(bookDTO);

            // Fetch the authors based on AuthorIds provided in the DTO
            // Only authors that exist in the Authors table will be returned
            var authors = await _context.Authors
                                        .Where(a => bookDTO.AuthorIds.Contains(a.AuthorId))
                                        .ToListAsync();

            // Handle the case where no valid authors are found
            if (authors.Count == 0)
            {
                throw new Exception("No valid authors found for the provided AuthorIds.");
            }

            // Link the valid authors to the book
            mappedBook.Authors = authors;


            // Add the book to the context and save changes
            _context.Books.Add(mappedBook);
            await _context.SaveChangesAsync();

            // Map the saved Book entity to ShowBookDTO to include associated authors
            var result = _mapper.Map<BookViewModel>(mappedBook);
            return result;
        }

        //public async Task<string> UpdateBookAsync(UpdateBookDTO book)
        //{
        //    var existingBook = await _context.Books.FindAsync(book.Id);
        //    existingBook.IsAvailable = book.IsAvailable;
        //    await _context.SaveChangesAsync();
        //    return "Update successfull";
        //}

        public async Task<BookViewModel> UpdateBookAsync(UpdateBookModel book)
        {
            var existingBook = await _context.Books.FindAsync(book.Id);

            existingBook.IsAvailable = book.IsAvailable;

            await _context.SaveChangesAsync();
            var mapped = _mapper.Map<BookViewModel>(existingBook);
            return mapped;
        }
        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        //public async Task<IEnumerable<ShowBookDTO>> FilterBooksAsync(
        //    string title, 
        //    string authorId, 
        //    string isbn, 
        //    string genre, 
        //    int? publicationYear, 
        //    bool? isAvailable)
        //{
        //    var query = _context.Books.AsQueryable();

        //    query = query
        //        .Where(item => string.IsNullOrEmpty(title) || item.Title.Contains(title))
        //        .Where(item => string.IsNullOrEmpty(authorId) || item == authorId)
        //        .Where(item => string.IsNullOrEmpty(isbn) || item.ISBN == isbn)
        //        .Where(item => string.IsNullOrEmpty(genre) || item.Genre.Contains(genre))
        //        .Where(item => !publicationYear.HasValue || item.PublicationYear == publicationYear.Value)
        //        .Where(item => !isAvailable.HasValue || item.IsAvailable == isAvailable.Value);

        //    /*
        //    if (!string.IsNullOrEmpty(title))
        //    {
        //        query = query.Where(b => b.Title.Contains(title));
        //    }

        //    if (!string.IsNullOrEmpty(authorId))
        //    {
        //        query = query.Where(b => b.AuthorID == authorId);
        //    }

        //    if (!string.IsNullOrEmpty(isbn))
        //    {
        //        query = query.Where(b => b.ISBN == isbn);
        //    }

        //    if (!string.IsNullOrEmpty(genre))
        //    {
        //        query = query.Where(b => b.Genre.Contains(genre));
        //    }

        //    if (publicationYear.HasValue)
        //    {
        //        query = query.Where(b => b.PublicationYear == publicationYear.Value);
        //    }

        //    if (isAvailable.HasValue)
        //    {
        //        query = query.Where(b => b.IsAvailable == isAvailable.Value);
        //    }*/

        //    var books = await query.ToListAsync();
        //    var mappedBooks = _mapper.Map<IEnumerable<ShowBookDTO>>(books);
        //    return mappedBooks;
        //}

        public async Task<IEnumerable<BookViewModel>> FilterBooksAsync(
            string title,
            string authorId,
            string isbn,
            int? publicationYear,
            bool? isAvailable,
            int? category)
        {
            var query = _context.Books
                .Include(b => b.Authors)  // Include authors in the query
                .AsQueryable();

            // Filter by title
            if (!string.IsNullOrEmpty(title))
            {
                query = query.Where(b => b.Title.Contains(title));
            }

            // Filter by authorId
            if (!string.IsNullOrEmpty(authorId))
            {
                query = query.Where(b => b.Authors.Any(a => a.AuthorId.ToString() == authorId));
            }

            // Filter by ISBN
            if (!string.IsNullOrEmpty(isbn))
            {
                query = query.Where(b => b.ISBN == isbn);
            }


            // Filter by publication year
            if (publicationYear.HasValue)
            {
                query = query.Where(b => b.PublicationYear == publicationYear.Value);
            }

            // Filter by availability
            if (isAvailable.HasValue)
            {
                query = query.Where(b => b.IsAvailable == isAvailable.Value);
            }

            if(category.HasValue)
            {
                query = query.Where(b => b.CategoryId == category);
            }

            // Execute the query and map the result to DTOs
            var books = await query.ToListAsync();
            var mappedBooks = _mapper.Map<IEnumerable<BookViewModel>>(books);
            return mappedBooks;
        }

    }
}
