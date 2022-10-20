using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLArch.Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CLArch.Persistance
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("MyConnection"),
                b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName));


            });

            services.AddScoped<IApplicationDbContext>(provider => provider.GetService<ApplicationContext>());

            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;

        }

    }
}