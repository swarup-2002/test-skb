using LibraryManagementSystem.Common.Helper;
using LibraryManagementSystem.Common.Model;
using LibraryManagementSystem.DTOs.MemberDTO;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Data.Repositories.Abstract
{
    public class MemberRepository : IMemberRepository
    {
        private readonly LibraryContext _context;
        public MemberRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task<Member> GetMemberByEmailAasync(string email)
        {
            return await _context.Members.FirstOrDefaultAsync(m => m.Email == email);
        }
        public async Task<Member> CreateMemberAsync(Member member)
        {
            _context.Members.Add(member);
            await _context.SaveChangesAsync();
            return member;
        }

        public async Task<GenericErrorHandlerModel<string>> DeleteMemberAsync(int id)
        {
            var vResult = new GenericErrorHandlerModel<string>(null);

            // Fetch the existing Member whose IsDeleted Property is False
            var member = await _context.Members
                .Where(m => m.IsDeleted == false && m.MemberId == id)
                .FirstOrDefaultAsync();

            if (member == null)
            {
                vResult.Code = Status.RemoveItemError;
                vResult.Message = "Member not Found";
                return vResult;
            }

            member.IsDeleted = true;
            await _context.SaveChangesAsync();

            vResult.Model = $"Name: {member.FullName}";
            vResult.Code = Status.GenericOk;
            vResult.Message = "Member Successfully Deleted";
            return vResult;
        }

        public async Task<Member?> GetMemberByIdAsync(int id)
        {
            return  _context.Members.FirstOrDefault(m => m.MemberId == id);
        }
    }
}