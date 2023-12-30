using System;
using System.Threading;
using System.Threading.Tasks;

namespace BlogWebApi.Infrastructure.CrossCutting.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;

        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}
