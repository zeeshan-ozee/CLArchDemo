using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLArch.Application.Interfaces;
using CLArch.Domain.Entities.Product;
using CLArch.Domain.Master;
using Microsoft.Extensions.Logging;

namespace CLArch.Persistance
{
    // public class UnitOfWork : IUnitOfWork
    // {
    //     public UnitOfWork(ApplicationContext context, ILogger logger)
    //     {
    //         _context = context;
    //         _logger = logger;
    //     }
    //     //ApplicationContext : DbContext, IApplicationDbContext
    //     ApplicationContext _context;
    //     ILogger _logger;
    //     IGenericRepository<Category> _categoryRepo;
    //     IGenericRepository<AppSetting> _appSettingRepo;
    //     public IGenericRepository<AppSetting> AppSettingRepo => throw new NotImplementedException();

    //     public IGenericRepository<Category> CategoryRepo
    //     {
    //         get
    //         {
    //             if (this._categoryRepo == null)
    //                 _categoryRepo = new GenericRepository<Category>(_context, _logger);

    //             return _categoryRepo;
    //         }
    //     }

    //     public void BeginTransaction()
    //     {
    //         throw new NotImplementedException();
    //     }

    //     public void CommitTransaction()
    //     {
    //         throw new NotImplementedException();
    //     }

    //     public void RollbackTransaction()
    //     {
    //         throw new NotImplementedException();
    //     }

    //     public Task<int> SaveAsync()
    //     {
    //         throw new NotImplementedException();
    //     }
    // }
}