using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using CLArch.Application.Models.Authentication;
using CLArch.Application.Models.Authentication.Commands;
using CLArch.Application.Models.Authentication.Query;
using Mapster;
using MapsterMapper;

namespace CLArch.WebApi.Mapping
{
    public class AuthMappingConfig : IRegister
    {
        public void Register(TypeAdapterConfig config)
        {
            config.NewConfig<RegisterRequest, RegisterCommand>();
            config.NewConfig<LoginRequest, LoginQuery>();

        }
    }

    public static class DependencyInjector
    {

        public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
        {
            //Mapster configuration
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(Assembly.GetExecutingAssembly());
            services.AddSingleton(config);

            services.AddScoped<IMapper, ServiceMapper>();

            return services;
        }

    }
}