using Application.Abstractions.Pages;
using Domain.Guards;
using Presentation.ViewModels;

namespace Presentation;

public partial class AppShell : Shell
{
    public AppShell(IEnumerable<IGuardedEntity> pages, AppShellViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;

        Items.Clear();

        foreach (var page in pages)
        {
            HandleGuards(page);
        }
    }
    private void HandleGuards(IGuardedEntity page)
    {
        var pageAsContentPage = page as ContentPage;
        if (pageAsContentPage is null)
        {
            return;
        }

        var flyoutItem = new FlyoutItem();

        flyoutItem.Items.Add(pageAsContentPage);
        flyoutItem.Title = pageAsContentPage.Title;

        if (page.Guards.Contains(Guard.LoginRequired))
        {
            flyoutItem.SetBinding(FlyoutItem.IsVisibleProperty, nameof(AppShellViewModel.IsAuthenticated));
        }
        if (page.Guards.Contains(Guard.OnlyIfLogout))
        {
            flyoutItem.SetBinding(FlyoutItem.IsVisibleProperty, nameof(AppShellViewModel.IsLoggedOut));
        }

        Items.Add(flyoutItem);
    }
}