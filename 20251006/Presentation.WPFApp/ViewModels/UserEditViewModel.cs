using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation.WPFApp.ViewModels;

public partial class UserEditViewModel(IServiceProvider serviceProvider, IUserService userService) : ObservableObject
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    private readonly IUserService _userService = userService;

    [ObservableProperty]
    private string _title = "EDIT USER";

    [ObservableProperty]
    private User? _user;

    [ObservableProperty]
    private string _errorMessage = "";

    public void SetUser(User user)
    {
        User = new User
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email
        };
    }

    [RelayCommand]
    private void Save()
    {
        if (User is not null)
        {
            var successeded = _userService.UpdateUser(User);
            if (!successeded)
            {
                ErrorMessage = "Unable to update user.";
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