using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ScientificDatabase.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<List<T>> GetItemsAsync();
        Task<List<T>> GetListAsync(Expression<Func<T, bool>> predicate);
        Task<T> GetItemAsync(int id);

        Task<long> UpdateItemAsync(T entity);

        Task DeleteItemAsync(T entity);

        Task DeleteItemAsync(int id);

        Task<long> InsertItemAsync(T entity);

        IQueryable<T> GetItemsWithoutExecution();
    }
}
