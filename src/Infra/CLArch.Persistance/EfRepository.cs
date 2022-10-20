using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using CLArch.Application.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CLArch.Persistance
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        readonly ApplicationContext _context;
        public EfRepository(ApplicationContext context)
        {
            _context = context;
        }

        protected DbSet<TEntity> _entities;
        public virtual DbSet<TEntity> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<TEntity>();

                return _entities;
            }
        }

        protected string GetFullErrorTextAndRollbackEntityChanges(DbUpdateException exception)
        {
            if (_context is DbContext dbContext)
            {
                var entries = dbContext.ChangeTracker.Entries().
                Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

                foreach (var entry in entries)
                {
                    try
                    {
                        entry.State = EntityState.Unchanged;
                    }
                    catch (InvalidOperationException ex)
                    {
                        //
                    }

                }
            }
            try
            {
                _context.SaveChanges();
                return exception.Message;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }


        }

        public IQueryable<TEntity> Table => throw new NotImplementedException();

        public IQueryable<TEntity> TableNoTracking => throw new NotImplementedException();

        public void Add(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> Count(Expression<Func<TEntity, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Task<int> Count()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Expression<Func<TEntity, bool>> where)
        {
            try
            {
                var entities = Entities.Where(where);
                Entities.RemoveRange(entities);
                return Task.FromResult(true);
            }
            catch (DbUpdateException exception)
            {
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception?.InnerException);
            }
        }

        public Task<bool> ExistsAny(Expression<Func<TEntity, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> Get(Expression<Func<TEntity, bool>> where)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetAll(Expression<Func<TEntity, bool>> where)
        {
            throw new NotImplementedException();
        }

        public List<TEntity> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Update(TEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}