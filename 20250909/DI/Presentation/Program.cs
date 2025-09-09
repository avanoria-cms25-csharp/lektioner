using Infrastructure.Managers;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder();

builder.Services.AddTransient<JsonFileService>(_ => new JsonFileService(@"c:\data\users.json"));
builder.Services.AddTransient<UserManager>();
builder.Services.AddTransient<MenuService>();

using var app = builder.Build();

var menuService = app.Services.GetRequiredService<MenuService>();
menuService.Start();
