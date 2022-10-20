using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CLArch.Application.Interfaces;
using CLArch.Domain.Master;
using CLArch.Domain.Entities.Product;
using CLArch.Domain.Common;
namespace CLArch.Persistance
{
    public class ApplicationContext : DbContext, IApplicationDbContext
    {

        public ApplicationContext() { }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=DBName;Integrated Security=True");

        }

        public Task<int> SaveChangesAsync(CancellationToken token)
        {

            foreach (var entry in ChangeTracker.Entries<IAuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = "N/A";
                        entry.Entity.CreatedOn = DateTime.UtcNow;
                        break;
                    // case EntityState.Deleted:
                    //     break;
                    // case EntityState.Detached:
                    //     break;
                    case EntityState.Modified:
                        entry.Entity.ModifieddBy = "N/A";
                        entry.Entity.ModifiedOn = DateTime.UtcNow;
                        break;
                        // case EntityState.Unchanged:
                        //     break;
                }
            }
            return base.SaveChangesAsync();

        }

        public DbSet<AppSetting> TodoItems { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DbSet<Category> Categories { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}

