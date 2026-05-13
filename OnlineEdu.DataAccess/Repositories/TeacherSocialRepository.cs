using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;
using OnlineEdu.Entity.Entities;

namespace OnlineEdu.DataAccess.Repositories
{
    public class TeacherSocialRepository(AppDbContext _context) : ITeacherSocialRepository
    {
        public async Task<List<TeacherSocial>> GetTeacherSocialsByIdAsync(int id)
        {
            return await _context.TeacherSocials.Include(x => x.SocialMedia).Where(y => y.TeacherId == id).ToListAsync();
        }
    }
}
