using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Infrastructure.Models;
using Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace Presentation.WPFApp.ViewModels;

public partial class UserListViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IUserService _userService;

    public UserListViewModel(IServiceProvider serviceProvider, IUserService userService)
    {
        _serviceProvider = serviceProvider;
        _userService = userService;

        PopulateUserList();
    }

    [ObservableProperty]
    private string _title = "USER LIST";

    [ObservableProperty]
    private ObservableCollection<User> _users = [];

    public void PopulateUserList()
    {
        var currentUsers = _userService.GetUsers();
        Users = new ObservableCollection<User>(currentUsers);
    }


    [RelayCommand]
    private void GoToUserAddView()
    {
        var mmv = _serviceProvider.GetRequiredService<MainViewModel>();
        mmv.CurrentViewModel = _serviceProvider.GetRequiredService<UserAddViewModel>();
    }

    [RelayCommand]
    private void Edit(User user)
    {
        var evm = _serviceProvider.GetRequiredService<UserEditViewModel>();
        evm.SetUser(user);

        var mmv = _serviceProvider.GetRequiredService<MainViewModel>();
        mmv.CurrentViewModel = _serviceProvider.GetRequiredService<UserEditViewModel>();
    }

    [RelayCommand]
    private void Delete(int userId)
    {
        _userService.DeleteUserById(userId);
        PopulateUserList() ;
    }

    



}
