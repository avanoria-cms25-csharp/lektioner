using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation.WPFApp.ViewModels;

public partial class UserAddViewModel(IServiceProvider serviceProvider) : ObservableObject
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    
    [ObservableProperty]
    private string _title = "NEW USER";

    [RelayCommand]
    private void Save()
    {
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
