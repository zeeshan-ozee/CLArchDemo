using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CLArch.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);

        Task<bool> Delete(T entity);
        Task<bool> Delete(Guid id);
        Task<bool> Delete(int id);
        Task<bool> Delete(Expression<Func<T, bool>> where);

        Task<T> Get(Guid id);
        Task<T> Get(int id);
        Task<T> Get(Expression<Func<T, bool>> where);

        Task<T> GetAll(Expression<Func<T, bool>> where);

        List<T> GetAll();
        Task<int> Count(Expression<Func<T, bool>> where);
        Task<int> Count();

        Task<bool> ExistsAny(Expression<Func<T, bool>> where);

        IQueryable<T> Table { get; }

        IQueryable<T> TableNoTracking { get; }

    }
}