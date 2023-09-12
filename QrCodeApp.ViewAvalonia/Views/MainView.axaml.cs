using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media.Imaging;
using Avalonia.Platform.Storage;
using Avalonia.ReactiveUI;
using QrCodeApp.ViewAvalonia.ViewModels;
using ReactiveUI;
using System.IO;
using System.Reactive;
using System.Threading.Tasks;

namespace QrCodeApp.ViewAvalonia.Views;

public partial class MainView : ReactiveUserControl<MainViewModel>
{
    public MainView()
    {
        InitializeComponent();
        this.BindCommand(this.ViewModel, vm => vm.CreateQrCodeCommand, v => v.createQrCode);
        this.BindCommand(this.ViewModel, vm => vm.SaveQrCodeCommand, v => v.saveQrCode);
        this.BindCommand(this.ViewModel, vm => vm.LoadQrCodeCommand, v => v.loadQrCode);
    }
}
