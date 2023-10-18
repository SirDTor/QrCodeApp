using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QrCodeApp.ViewAvalonia.ViewModels
{
    public class MainWindowViewModel: ViewModelBase
    {
        public ReactiveCommand<Unit, Unit> OpenSettingsButton { get; }

        public Interaction<SettingsViewModel, MainViewModel?> OpenSettingsInteraction { get; }

        public MainWindowViewModel() 
        {
            OpenSettingsInteraction = new Interaction<SettingsViewModel, MainViewModel?>();
            OpenSettingsButton = ReactiveCommand.CreateFromTask(async () =>
            {
                var settingsViewModel = new SettingsViewModel();
                var resultOpenSettings = await OpenSettingsInteraction.Handle(settingsViewModel);
            });
        }
    }
}
