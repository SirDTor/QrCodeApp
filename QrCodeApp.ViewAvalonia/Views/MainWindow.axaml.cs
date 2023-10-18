using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform.Storage;
using Avalonia.ReactiveUI;
using QrCodeApp.ViewAvalonia.ViewModels;
using ReactiveUI;
using System.Reactive;
using System.Threading.Tasks;

namespace QrCodeApp.ViewAvalonia.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
        this.BindCommand(this.ViewModel, vm => vm.OpenSettingsButton, v => v.SettingsButton);
        this.WhenActivated(action =>
             action(ViewModel!.OpenSettingsInteraction.RegisterHandler(DoShowDialogAsync)));
    }
    private async Task DoShowDialogAsync(InteractionContext<SettingsViewModel, MainViewModel?> interaction)
    {
        var dialog = new SettingsView
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<MainViewModel?>(this);
        interaction.SetOutput(result);
    }
}
