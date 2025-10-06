using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation.WPFApp.ViewModels;
using Presentation.WPFApp.Views;
using System.Windows;

namespace Presentation.WPFApp;

public partial class App : Application
{
    private IHost? _host;

    public App()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddSingleton<IUserService, UserService>();

                services.AddSingleton<MainViewModel>();
                services.AddSingleton<MainWindow>();

                services.AddTransient<UserListViewModel>();
                services.AddTransient<UserListView>();

                services.AddTransient<UserAddViewModel>();
                services.AddTransient<UserAddView>();

                services.AddTransient<UserEditViewModel>();
                services.AddTransient<UserEditView>();
            })
            .Build();
    }


    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var mainViewModel = _host!.Services.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _host!.Services.GetRequiredService<UserListViewModel>();

        var window = _host!.Services.GetRequiredService<MainWindow>();
        window.DataContext = mainViewModel;

        window.Show();
    }
}
