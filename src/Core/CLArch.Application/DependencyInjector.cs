using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CLArch.Application.Interfaces;
using CLArch.Application.Services;
using CLArch.Application.Services.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CLArch.Application
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            //     //Add automapper
            //     //add mediatR
            //     //add pipeline behavior

            services.AddScoped<IMasterServices, MasterServices>();
            services.AddScoped<IProductServices, ProductServices>();
            services.AddScoped<IAuthenticationCommandService, AuthenticationCommandService>();
            services.AddScoped<IAuthenticationQueryService, AuthenticationQueryService>();

            return services;
        }

    }
}