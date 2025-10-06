using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation.WPFApp.ViewModels;
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
                services.AddSingleton<MainViewModel>();
                services.AddSingleton<MainWindow>();
            })
            .Build();
    }


    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var window = _host!.Services.GetRequiredService<MainWindow>();
        window.Show();
    }
}
