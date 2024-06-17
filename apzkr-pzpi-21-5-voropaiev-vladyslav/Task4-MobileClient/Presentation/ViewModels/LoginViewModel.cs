using System.Windows.Input;
using Application.Abstractions.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Presentation.ViewModels.Base;

namespace Presentation.ViewModels;

public partial class LoginViewModel : ViewModelBase
{
    private readonly IAuthService _authService;

    [ObservableProperty]
    private string _login = "";
    
    [ObservableProperty]
    private string _password = "";
    
    [ObservableProperty]
    private ICollection<string> _errors = [];
    
    public ICommand LoginCommand { get; set; }
    
    public LoginViewModel(IAuthService authService)
    {
        _authService = authService;
        
        LoginCommand = new AsyncRelayCommand(LoginAsync);
    }

    private async Task LoginAsync(CancellationToken cancellationToken)
    {
        Errors = [];
        if (string.IsNullOrEmpty(Login))
        {
            Errors.Add("Login is empty");
        }
        if (string.IsNullOrEmpty(Password))
        {
            Errors.Add("Password is empty");
        }

        if (Errors.Count == 0)
        {
            await _authService.LoginAsync(Login, Password, cancellationToken);
        }
    }
}