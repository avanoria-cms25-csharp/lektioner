using CommunityToolkit.Mvvm.ComponentModel;

namespace Presentation.WPFApp.ViewModels;

public partial class ListViewModel(IServiceProvider serviceProvider) : ObservableObject
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    
    [ObservableProperty]
    private string _title = "LIST";
}
