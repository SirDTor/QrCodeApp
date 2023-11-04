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
        DataContext = new MainWindowViewModel();
        InitializeComponent();
        this.BindCommand(this.ViewModel, vm => vm.OpenSettingsButton, v => v.SettingsButton);
        this.BindCommand(this.ViewModel, vm => vm.OpenAboutWindowButton, v => v.AboutButton);
        this.WhenActivated(action =>
             action(ViewModel!.OpenSettingsInteraction.RegisterHandler(DoShowSettingsAsync)));
        this.WhenActivated(action =>
             action(ViewModel!.OpenAboutWindowInteraction.RegisterHandler(DoShowAboutWindowAsync)));
    }

    private async Task DoShowSettingsAsync(InteractionContext<SettingsViewModel, MainViewModel?> interaction)
    {
        var data = this.DataContext as MainWindowViewModel;
        var dialog = new SettingsView(data)
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<MainViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task DoShowAboutWindowAsync(InteractionContext<AboutWindowViewModel, MainViewModel> interaction)
    {
        var data = this.DataContext as MainWindowViewModel;
        var dialog = new AboutWindow()
        {
            DataContext = interaction.Input
        };
        var result = await dialog.ShowDialog<MainViewModel?>(this);
        interaction.SetOutput(result);
    }
}
