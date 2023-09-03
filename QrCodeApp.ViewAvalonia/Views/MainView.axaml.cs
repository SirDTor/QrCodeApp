using Avalonia.Controls;
using Avalonia.ReactiveUI;
using QrCodeApp.ViewAvalonia.ViewModels;
using ReactiveUI;

namespace QrCodeApp.ViewAvalonia.Views;

public partial class MainView : ReactiveUserControl<MainViewModel>
{
    public MainView()
    {
        InitializeComponent();
        this.BindCommand(this.ViewModel, vm => vm.CreateQrCodeCommand, v => v.createQrCode);
    }
}
