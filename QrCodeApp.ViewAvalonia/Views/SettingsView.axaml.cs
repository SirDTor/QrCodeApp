using Avalonia.Controls;
using Avalonia.ReactiveUI;
using QrCodeApp.ViewAvalonia.ViewModels;

namespace QrCodeApp.ViewAvalonia.Views
{
    public partial class SettingsView : ReactiveWindow<SettingsViewModel>
    {
        public SettingsView()
        {
            InitializeComponent();
        }
    }
}
