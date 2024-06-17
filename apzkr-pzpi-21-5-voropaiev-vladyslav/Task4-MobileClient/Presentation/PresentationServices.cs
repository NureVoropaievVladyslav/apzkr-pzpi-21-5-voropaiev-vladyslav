using Application.Abstractions.Pages;
using Infrastructure.Configurations.Auth;
using Presentation.ViewModels;
using Presentation.Views;

namespace Presentation;

public static class PresentationServices
{
    public static IServiceCollection AddPresentationServices(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<AppShell>();

        RegisterPages(serviceCollection);
        RegisterViewModels(serviceCollection);
        
        serviceCollection.AddSingleton(_ =>
        {
            return new AuthConfiguration()
            {
                AccessToken = Preferences.Get("access_token", null)
            };
        });

        return serviceCollection;
    }
    
    private static void RegisterPages(IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<IGuardedEntity, LoginPage>();
        serviceCollection.AddScoped<IGuardedEntity, PondsPage>();
    }
    
    private static void RegisterViewModels(IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<AppShellViewModel>();
        serviceCollection.AddScoped<LoginViewModel>();
        serviceCollection.AddScoped<PondViewModel>();
    }
}