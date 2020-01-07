using ContosoUniversity.Interfaces;
using ContosoUniversity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Data
{
    public class EfRepository<T> : IAsyncRepository<T> where T : BaseEntity
    {
        protected readonly SchoolContext _dbContext;

        public EfRepository(SchoolContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual async Task<T> GetByIdAsync(string id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        public async Task<IList<T>> ListAllAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            entity.Id = Guid.NewGuid().ToString();
            _dbContext.Set<T>().Add(entity);
            await _dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
