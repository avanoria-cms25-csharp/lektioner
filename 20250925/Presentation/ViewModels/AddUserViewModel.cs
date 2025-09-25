using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation.ViewModels;

public partial class AddUserViewModel(IServiceProvider serviceProvider) : ObservableObject
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    
    [ObservableProperty]
    private User _userForm = new();

    [RelayCommand]
    public async Task Save()
    {
        var userService = _serviceProvider.GetRequiredService<IUserService>();
        await userService.SaveUserAsync(UserForm);

        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ListUserViewModel>();
    }

    [RelayCommand]
    public void Cancel()
    {
        var userService = _serviceProvider.GetRequiredService<IUserService>();
        userService.Cancel();

        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ListUserViewModel>();
    }
}
