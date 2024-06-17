using System.ComponentModel;

namespace Infrastructure.Configurations.Auth;

public class AuthConfiguration : INotifyPropertyChanged
{
    private string? _accessToken;
    public string? AccessToken 
    {
        get => _accessToken;
        set
        {
            _accessToken = value;
            PropertyChanged?.Invoke(null, new PropertyChangedEventArgs(nameof(AccessToken)));
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
}