using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLArch.Domain.Entities.Product;
using CLArch.Domain.Master;
using Microsoft.EntityFrameworkCore;

namespace CLArch.Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<AppSetting> TodoItems { get; set; }
        DbSet<Category> Categories { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        Task<int> SaveChangesAsync(CancellationToken token);
    }
}