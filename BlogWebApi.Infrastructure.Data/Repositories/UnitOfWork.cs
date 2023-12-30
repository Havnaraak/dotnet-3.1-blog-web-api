using BlogWebApi.Infrastructure.CrossCutting.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BlogWebApi.Infrastructure.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public readonly IDBContext _dbContext;
        private Dictionary<Type, object> _repositories;

        public UnitOfWork(IDBContext dBContext)
        {
            _dbContext = dBContext;
        }

        public Task<int> CommitAsync(CancellationToken cancellationToken = default) =>
            _dbContext.SaveChangesAsync(cancellationToken);

        public void Dispose() => _dbContext?.Dispose();

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            _repositories ??= new Dictionary<Type, object>();
            var type = typeof(TEntity);

            if (_repositories.TryGetValue(type, out var repository))
            {
                return (IRepository<TEntity>)repository;
            }

            _repositories[type] = new Repository<TEntity>(_dbContext);

            return (IRepository<TEntity>)_repositories[type];
        }
    }
}
