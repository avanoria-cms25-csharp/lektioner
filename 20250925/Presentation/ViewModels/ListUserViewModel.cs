using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace Presentation.ViewModels;

public partial class ListUserViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;

    [ObservableProperty]
    private ObservableCollection<User> _userList = [];

    public ListUserViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;

        Task.Run(PopulateUserListAsync);

    }

    private async Task PopulateUserListAsync()
    {
        var userService = _serviceProvider.GetRequiredService<IUserService>();
        var users = await userService.GetUsersAsync();
        UserList = new ObservableCollection<User>(users);
    }



    [RelayCommand]
    public void NavigateToAddUser()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<AddUserViewModel>();
    }
}