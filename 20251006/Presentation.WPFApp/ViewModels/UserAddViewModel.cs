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

    [ObservableProperty]
    private string _errorMessage = "";

    [RelayCommand]
    private void Save()
    {
        if (UserData is not null)
        {
            var successeded = _userService.AddUser(UserData);
            if (!successeded)
            {
                ErrorMessage = "Unable to save user.";
                return;
            }
        }

        var lvm = _serviceProvider.GetRequiredService<UserListViewModel>();
        lvm.PopulateUserList();

        var mmv = _serviceProvider.GetRequiredService<MainViewModel>();
        mmv.CurrentViewModel = lvm;

    }

    [RelayCommand]
    private void Cancel()
    {
        var lvm = _serviceProvider.GetRequiredService<UserListViewModel>();
        lvm.PopulateUserList();

        var mmv = _serviceProvider.GetRequiredService<MainViewModel>();
        mmv.CurrentViewModel = lvm;
    }
}
