using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation.WPFApp.ViewModels;

public partial class UserAddViewModel(IServiceProvider serviceProvider, IUserService userService) : ObservableObject
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    private readonly IUserService _userService = userService;

    [ObservableProperty]
    private string _title = "NEW USER";

    [ObservableProperty]
    private User _userData = new();

    [RelayCommand]
    private void Save()
    {
        if (UserData is not null)
            _userService.AddUser(UserData);

        var mmv = _serviceProvider.GetRequiredService<MainViewModel>();
        mmv.CurrentViewModel = _serviceProvider.GetRequiredService<UserListViewModel>();
    }

    [RelayCommand]
    private void Cancel()
    {
        var mmv = _serviceProvider.GetRequiredService<MainViewModel>();
        mmv.CurrentViewModel = _serviceProvider.GetRequiredService<UserListViewModel>();
    }
}
