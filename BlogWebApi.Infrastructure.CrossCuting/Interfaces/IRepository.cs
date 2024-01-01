using System;
using System.Linq;
using System.Linq.Expressions;

namespace BlogWebApi.Infrastructure.CrossCutting.Interfaces
{
    public interface IRepository<T>
    {
        void Add<TEntity>(TEntity entity) where TEntity : T;

        void Delete<TEntity>(TEntity entity) where TEntity : T;

        void Update<TEntity>(TEntity entity) where TEntity : T;

        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);

        IQueryable<T> GetAll();

        bool Exists(Expression<Func<T, bool>> predicate);
    }
}
