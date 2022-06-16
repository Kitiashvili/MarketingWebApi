using Marketing.Domain.Repositories;
using Marketing.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Marketing.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly MarketingDbContext _context;

        public GenericRepository(MarketingDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Delete(TEntity entity)
        {
            _context.Remove(entity);
            return (await _context.SaveChangesAsync()) >= 0 ? true : false;
        }
        public async Task<IEnumerable<TEntity>> FindByConditionAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await Task.Run(() =>
            _context.Set<TEntity>().Where(predicate));
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.FindAsync<TEntity>(id);
        }

        public async Task<bool> Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return (await _context.SaveChangesAsync()) >= 0 ? true : false;
        }
        public IQueryable<TEntity> Query()
        {
            return _context.Set<TEntity>();
        }

    }
}
