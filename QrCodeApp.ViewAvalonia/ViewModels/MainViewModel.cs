using Avalonia.Media.Imaging;
using ReactiveUI;
using System.Reactive;
using System.Threading.Tasks;
using Avalonia.Platform.Storage;

namespace QrCodeApp.ViewAvalonia.ViewModels;

public abstract class MainViewModel : ViewModelBase
{
    private string? _qrTextBox;

    private Bitmap? _pngQrCode;

    private byte[] _qrByteBackColor = new byte[4] { 255, 255, 255, 255 };
    private byte[] _qrByteColor = new byte[4] { 0,0,0,0 };

    public ReactiveCommand<Unit, Unit>? CreateQrCodeCommand { get; }

    public ReactiveCommand<Unit, Unit> SaveQrCodeCommand { get; }

    public ReactiveCommand<Unit, Unit> LoadQrCodeCommand { get; }

    public Bitmap? PngQrCode
    {
        get => _pngQrCode;
        set => this.RaiseAndSetIfChanged(ref _pngQrCode, value);
    }

    public string? QrTextBox
    {
        get => _qrTextBox;
        set => this.RaiseAndSetIfChanged(ref _qrTextBox, value);
    }

    public byte[] QrByteBackColor { get => _qrByteBackColor; set => this.RaiseAndSetIfChanged(ref _qrByteBackColor, value); }

    public byte[] QrByteColor { get => _qrByteColor; set => this.RaiseAndSetIfChanged(ref _qrByteColor, value); }

    public MainViewModel()
    {
        CreateQrCodeCommand = ReactiveCommand.Create(CreateQrCode);
        SaveQrCodeCommand = ReactiveCommand.CreateFromTask(SaveQrCode);
        LoadQrCodeCommand = ReactiveCommand.CreateFromTask(LoadQrCode);
    }

    public abstract void CreateQrCode();

    public abstract Bitmap ByteToImage(byte[] blob);

    public abstract Task SaveQrCode();

    public abstract Task LoadQrCode();

    public abstract Task<IStorageFile?> DoOpenFilePickerAsync();

    public abstract Task<IStorageFile?> DoSaveFilePickerAsync();
}
