using Microsoft.EntityFrameworkCore;
using OnlineEdu.DataAccess.Abstract;
using OnlineEdu.DataAccess.Context;

namespace OnlineEdu.DataAccess.Repositories
{
    public class Repository<T>(AppDbContext _context) : IRepository<T> where T : class
    {
        public DbSet<T> Table { get => _context.Set<T>(); }
        public async Task<int> CountAsync()
        {
            return await Table.CountAsync();
        }

        public async Task CreateAsync(T entity)
        {
            await Table.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<int> FilteredCountAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return await Table.CountAsync(predicate);
        }

        public async Task<T> GetByFilterAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return await Table.Where(predicate).FirstOrDefaultAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await Table.FindAsync(id);
        }

        public async Task<List<T>> GetFilteredListAsync(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
        {
            return await Table.Where(predicate).ToListAsync();
        }

        public async Task<List<T>> GetListAsync()
        {
            return await Table.ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            Table.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
