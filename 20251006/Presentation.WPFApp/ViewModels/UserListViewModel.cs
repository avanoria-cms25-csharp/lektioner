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

    [RelayCommand]
    private void GoToUserAddView()
    {
        var mmv = _serviceProvider.GetRequiredService<MainViewModel>();
        mmv.CurrentViewModel = _serviceProvider.GetRequiredService<UserAddViewModel>();
    }


    public void PopulateUserList()
    {
        var currentUsers = _userService.GetUsers();
        Users = new ObservableCollection<User>(currentUsers);
    }
}
