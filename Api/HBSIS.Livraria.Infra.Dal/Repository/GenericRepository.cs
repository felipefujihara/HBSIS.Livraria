using HBSIS.Livraria.Infra.Dal.Context;
using HBSIS.Livraria.Infra.Dal.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace HBSIS.Livraria.Infra.Dal.Repository
{
    public abstract class GenericRepository<T> : IRepository<T> where T : class
    {
        protected BookStoreContext Db;
        protected DbSet<T> DbSet;

        protected GenericRepository(BookStoreContext context)
        {
            Db = context;
            DbSet = Db.Set<T>();
        }

        public Task AddAsync(T obj)
        {
            return DbSet.AddAsync(obj);
        }

        public Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate)
        {
            return DbSet.FirstOrDefaultAsync(predicate);
        }

        public Task<T> GetSingleAsync(Expression<Func<T, bool>> predicate, params string[] includes)
        {
            var ret = DbSet.Where(predicate);

            foreach (var item in includes)
            {
                ret = ret.Include(item);
            }

            return ret.FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> predicate, params string[] includes)
        {
            var ret = DbSet.Where(predicate);

            foreach (var item in includes)
            {
                ret = ret.Include(item);
            }

            return await ret.Where(predicate).ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync().ConfigureAwait(false);
        }

        public async Task<IEnumerable<T>> GetAllAsync(string include)
        {
            return await DbSet.Include(include).ToListAsync().ConfigureAwait(false);
        }

        public Task<int> SaveChangesAsync()
        {
            return Db.SaveChangesAsync();
        }

        public void Delete(T obj)
        {
            DbSet.Remove(obj);
        }
    }
}
