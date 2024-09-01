using LibraryManagementSystem.Common.Model;
using LibraryManagementSystem.DTOs.MemberDTO;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Identity;

namespace LibraryManagementSystem.Data.Repositories.Abstract
{
    public interface IMemberRepository
    {
        Task<Member> CreateMemberAsync(Member member);
        Task<GenericErrorHandlerModel<string>> DeleteMemberAsync(int id);
        Task<Member?> GetMemberByIdAsync(int id);
        //Task<Member> GetMemberByEmailAasync(string email);
        //Task<IdentityResult> AddNewUserAsync(ApplicationUser user, string password);
        //Task<IdentityResult> AddUserRoleAsync(ApplicationUser user, string roleName);
        //Task<IEnumerable<Member>> GetAllMembersAsync();
        //Task<Member> GetMemberByIdAsync(int id);

        //Task UpdateMemberAsync(Member member);

        //Task DeleteMemberAsync(int id);
    }
}
