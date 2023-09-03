using ReactiveUI;
using System.Reactive;

namespace QrCodeApp.ViewAvalonia.ViewModels;

public class MainViewModel : ViewModelBase
{
    private string? _qrCodeText;

    public ReactiveCommand<Unit, Unit> CreateQrCodeCommand { get; }

    public MainViewModel()
    {
        CreateQrCodeCommand = ReactiveCommand.Create(CreateQrCode);
    }

    public string? QrCodeText
    { 
        get => _qrCodeText; 
        set => _qrCodeText = this.RaiseAndSetIfChanged(ref _qrCodeText, value); 
    }

    public void CreateQrCode()
    {

    }
}
