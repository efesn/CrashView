using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CrashView.Data.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        //Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<T> GetByIdAsync(int id);
        Task InsertAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }
}
