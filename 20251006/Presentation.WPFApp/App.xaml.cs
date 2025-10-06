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

                services.AddTransient<ListViewModel>();
                services.AddTransient<AddViewModel>();
                services.AddTransient<EditViewModel>();
            })
            .Build();
    }


    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        var mainViewModel = _host!.Services.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _host!.Services.GetRequiredService<ListViewModel>();

        var window = _host!.Services.GetRequiredService<MainWindow>();
        window.DataContext = mainViewModel;

        window.Show();
    }
}
