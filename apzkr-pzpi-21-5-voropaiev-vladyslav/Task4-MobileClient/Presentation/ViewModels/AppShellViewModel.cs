using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Infrastructure.Configurations.Auth;
using Presentation.ViewModels.Base;

namespace Presentation.ViewModels;

public partial class AppShellViewModel : ViewModelBase
{
    private readonly AuthConfiguration _authConfiguration;
    [ObservableProperty]
    private bool _isAuthenticated;
    [ObservableProperty]
    private bool _isLoggedOut;

    public AppShellViewModel(AuthConfiguration authConfiguration)
    {
        _authConfiguration = authConfiguration;
        _authConfiguration.PropertyChanged += TokenChanged;
        IsAuthenticated = _authConfiguration.AccessToken is not null;
        IsLoggedOut = _authConfiguration.AccessToken is null;
    }
    
    private void TokenChanged(object? sender, PropertyChangedEventArgs args)
    {
        if (args.PropertyName == nameof(AuthConfiguration.AccessToken))
        {
            IsAuthenticated = _authConfiguration.AccessToken is not null;
            IsLoggedOut = _authConfiguration.AccessToken is null;
            Preferences.Set("access_token", _authConfiguration.AccessToken);
        }
    }
}