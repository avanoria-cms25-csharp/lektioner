using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

namespace Presentation;

public partial class App : Application
{
    private IHost _host;

    public App()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices(services => 
            { 
                services.AddSingleton<IFileRepository, FileRepository>();
                services.AddSingleton<IUserService, UserService>();
                services.AddSingleton<MainWindow>();
            })
            .Build();
    }


    protected override async void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var userService = _host.Services.GetRequiredService<IUserService>();
        await userService.GetUsersAsync();

        var window = _host.Services.GetRequiredService<MainWindow>();
        window.Show();
    }
}
