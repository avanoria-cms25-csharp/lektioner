using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Presentation.WpfApp.ViewModels;

public partial class HomeViewModel : ObservableObject
{
    [ObservableProperty]
    private bool _isFanOn;

    [ObservableProperty]
    private string _buttonText = "Turn On";

    [ObservableProperty]
    private double _speedRatio = 1.0;

    [RelayCommand]
    private void ToggleFanState()
    {
        IsFanOn = !IsFanOn;
        ButtonText = IsFanOn ? "Turn Off" : "Turn On";
    }
}
