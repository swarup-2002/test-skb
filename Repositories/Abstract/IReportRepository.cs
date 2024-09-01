using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Data.Repositories.Abstract
{
    public interface IReportRepository
    {
        Task<IEnumerable<Borrowing>> GetOverdueBooksAsync();
        Task<IEnumerable<Borrowing>> GetBorrowingHistoryByMemberIdAsync(int memberId);
    }
}
