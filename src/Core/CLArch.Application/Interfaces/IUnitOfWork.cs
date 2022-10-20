using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLArch.Domain.Entities.Product;
using CLArch.Domain.Master;

namespace CLArch.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IRepository<AppSetting> AppSettingRepo { get; }

        IRepository<Category> CategoryRepo { get; }

        Task<int> SaveAsync();

        void BeginTransaction();
        void CommitTransaction();

        void RollbackTransaction();
    }
}