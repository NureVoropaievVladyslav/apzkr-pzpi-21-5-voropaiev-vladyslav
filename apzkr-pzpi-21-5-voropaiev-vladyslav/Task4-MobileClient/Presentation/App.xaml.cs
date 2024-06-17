namespace Presentation;

public partial class App : Microsoft.Maui.Controls.Application
{
    public App(AppShell appShell)
    {
        InitializeComponent();

        MainPage = appShell;
    }
}