using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Data.Repositories.Abstract
{
    public interface IBorrowingRepository
    {
        Task<IEnumerable<Borrowing>> GetAllBorrowingsAsync();
        Task<Borrowing> GetBorrowingByIdAsync(int id);
        Task AddBorrowingAsync(Borrowing borrowing);
        Task UpdateBorrowingAsync(Borrowing borrowing);
        Task DeleteBorrowingAsync(int id);
    }
}
