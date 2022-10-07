using Microsoft.EntityFrameworkCore;

namespace BlazorAppCodingDroplets.Data
{
    public class MemberServices
    {
        private readonly TestDbContext _context;
        public MemberServices(TestDbContext context)
        {
            _context = context;
        }

        public Task<List<Member>?> GetMembersAsync()
        {
            return _context.Members.ToListAsync();
        }

        public Task<Member?> GetMemberByIdAsync(int id)
        {
            return _context.Members.FirstOrDefaultAsync(x => x.Id.Equals(id));
        }

        public async Task AddMemberAsync(Member member)
        {
            await _context.Members.AddAsync(member);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMemberAsync(Member member)
        {
            var dbMember = await _context.Members.FirstOrDefaultAsync(x => x.Id.Equals(member.Id));
            if (dbMember == null) throw new ArgumentNullException($"Id为{member.Id}的Member未找到");

            dbMember.Name = member.Name;
            dbMember.Email=member.Email;
            dbMember.Age = member.Age;
            dbMember.JoiningDate=member.JoiningDate;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMemberAsync(int id)
        {
            var dbMember = await _context.Members.FirstOrDefaultAsync(x => x.Id.Equals(id));
            if (dbMember == null) throw new ArgumentNullException($"Id为{id}的Member未找到");
            _context.Members.Remove(dbMember);
            await _context.SaveChangesAsync();
        }
    }
}
