using ContosoUniversity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Interfaces
{
    public interface IAsyncRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(string id);
        Task<IList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
