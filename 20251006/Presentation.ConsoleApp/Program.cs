using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Presentation.ConsoleApp;

IHost _host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddScoped<IFileRepository, FileRepository>();
                services.AddScoped<IUserService, UserService>();

                services.AddSingleton<MenuDialogs>();
            })
            .Build();

var md = _host.Services.GetRequiredService<MenuDialogs>();
md.Show();