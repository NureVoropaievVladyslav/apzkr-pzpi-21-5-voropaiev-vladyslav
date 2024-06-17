using Application.Abstractions.Factories;
using Application.Abstractions.Services;
using Infrastructure.Factories;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class InfrastructureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IPondService, PondService>();
        services.AddScoped<IHttpClientFactory, HttpClientFactory>();
        return services;
    }
}