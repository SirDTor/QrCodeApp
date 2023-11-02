using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.ReactiveUI;
using QrCodeApp.ViewAvalonia.ViewModels;

namespace QrCodeApp.ViewAvalonia.Views
{
    public partial class SettingsView : ReactiveWindow<SettingsViewModel>
    {
        private MainWindowViewModel _mainViewModel;
        public SettingsView(MainWindowViewModel settingsViewModel)
        {
            InitializeComponent();
            _mainViewModel = settingsViewModel;
        }

        private void OkButton_Clicked(object sender, RoutedEventArgs e)
        {
            if (_mainViewModel != null) 
            {
                _mainViewModel.QrByteBackColor = this.ViewModel.QrByteBackColor;
                _mainViewModel.QrByteColor = this.ViewModel.QrByteColor;
            }
            this.Close();
        }
        private void CancelButton_Clicked(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
