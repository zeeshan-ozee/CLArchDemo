using CLArch.Application.Interfaces;
using CLArch.Application.Interfaces.Authentication;
using CLArch.Infrastructure.Authentication;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CLArch.Infrastructure;
public static class DependencyInjector
{
    public static IServiceCollection AddInfrastrcture(this IServiceCollection services, IConfiguration configuration)
    {

        services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.Section_Name));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<INotificationService, NotificationSender>();

        return services;
    }
}