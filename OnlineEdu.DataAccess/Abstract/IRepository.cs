using System.Linq.Expressions;

namespace OnlineEdu.DataAccess.Abstract
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetListAsync();
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<int> CountAsync();
        Task<List<T>> GetFilteredListAsync(Expression<Func<T, bool>> predicate);
        Task<int> FilteredCountAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> predicate);
    }
}
