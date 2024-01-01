using BlogWebApi.Infrastructure.CrossCutting.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace BlogWebApi.Infrastructure.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbSet<T> _dbSet;

        public Repository(IDBContext dbContext)
        {
            _dbSet = dbContext.Set<T>();
        }

        public void Add<TEntity>(TEntity entity) where TEntity : T => _dbSet.Add(entity);

        public void Delete<TEntity>(TEntity entity) where TEntity : T => _dbSet.Remove(entity);
        
        public void Update<TEntity>(TEntity entity) where TEntity : T => _dbSet.Update(entity);

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public IQueryable<T> GetAll()
        {
            return _dbSet;
        }

        public bool Exists(Expression<Func<T, bool>> predicate)
        {
            return _dbSet.Any(predicate);
        }
    }
}
