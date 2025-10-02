using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation.WpfApp.ViewModels;
using Presentation.WpfApp.Views;
using System.Configuration;
using System.Data;
using System.Windows;

namespace Presentation.WpfApp;


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

                services.AddSingleton<HomeViewModel>();
                services.AddSingleton<HomeView>();
            
            })
            .Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        if (_host != null)
        {
            var viewModel = _host.Services.GetRequiredService<MainViewModel>();
            viewModel.CurrentViewModel = _host.Services.GetRequiredService<HomeViewModel>();

            var window = _host.Services.GetRequiredService<MainWindow>();
            window.DataContext = viewModel;
            window.Show();
        }
    }

}
