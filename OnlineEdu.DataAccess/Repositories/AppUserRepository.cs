using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Repositories
{
    public class AppUserRepository(AppDbContext _context) : IAppUserRepository
    {
        public async Task<List<AppUser>> GetUsersWithSocials()
        {
            return await _context.Users.Include(x => x.TeacherSocials).ToListAsync();
        }
    }
}
