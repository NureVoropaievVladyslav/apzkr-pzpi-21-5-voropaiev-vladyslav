using Application.Abstractions.Pages;
using Domain.Guards;
using Presentation.ViewModels;

namespace Presentation.Views;

public partial class LoginPage : ContentPage, IGuardedEntity
{
    public LoginPage(LoginViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }

    public IEnumerable<Guard> Guards => [Guard.OnlyIfLogout];
}