using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLArch.Application.Interfaces;
using CLArch.Domain.Entities.Product;
using CLArch.Domain.Master;

namespace CLArch.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(ApplicationContext context)
        {
            _context = context;
        }
        //ApplicationContext : DbContext, IApplicationDbContext
        ApplicationContext _context;
        IRepository<Category> _categoryRepo;
        IRepository<AppSetting> _appSettingRepo;
        public IRepository<AppSetting> AppSettingRepo => throw new NotImplementedException();

        public IRepository<Category> CategoryRepo
        {
            get
            {
                if (this._categoryRepo == null)
                    _categoryRepo = new EfRepository<Category>(_context);

                return _categoryRepo;
            }
        }

        public void BeginTransaction()
        {
            throw new NotImplementedException();
        }

        public void CommitTransaction()
        {
            throw new NotImplementedException();
        }

        public void RollbackTransaction()
        {
            throw new NotImplementedException();
        }

        public Task<int> SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}