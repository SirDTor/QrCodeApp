using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using QRCoder;
using ReactiveUI;
using System.Reactive;
using System.Collections;
using System.IO;
using Avalonia;
using Avalonia.Platform;
using ImageExample.Helpers;
using System;
using static System.Net.Mime.MediaTypeNames;
using System.Reactive.Linq;
using System.Threading.Tasks;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Platform.Storage;

namespace QrCodeApp.ViewAvalonia.ViewModels;

public class MainViewModel : ViewModelBase
{
    private string? _qrTextBox;

    private Bitmap? _pngQrCode;

    public Interaction<Bitmap?, Unit?> SaveQrCodeInteraction { get; set; }

    public ReactiveCommand<Unit, Unit>? CreateQrCodeCommand { get; }

    public ReactiveCommand<Unit, Unit> SaveQrCodeCommand { get; }

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

    public MainViewModel()
    {
        CreateQrCodeCommand = ReactiveCommand.Create(CreateQrCode);
        SaveQrCodeInteraction = new Interaction<Bitmap?, Unit?>();
        SaveQrCodeCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            await SaveQrCode();
        });
    }

    public void CreateQrCode()
    {
        if (QrTextBox != null)
        {
            QRCodeGenerator qrGenerator = new();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(QrTextBox, QRCodeGenerator.ECCLevel.M);

            PngByteQRCode qrCodePng = new(qrCodeData);
            byte[] qrCodeImagePng = qrCodePng.GetGraphic(20, new byte[] { 0, 0, 0 }, new byte[] { 255, 255, 255 });
            PngQrCode = ByteToImage(qrCodeImagePng);
        }
    }

    public static Bitmap ByteToImage(byte[] blob)
    {
        using (MemoryStream mStream = new())
        {
            mStream.Write(blob, 0, blob.Length);
            mStream.Seek(0, SeekOrigin.Begin);

            Bitmap bm = new Bitmap(mStream);
            return bm;
        }
    }

    public async Task SaveQrCode()
    {
        if (PngQrCode == null) return;
        var file = await DoSaveFilePickerAsync();
        if (file is null) return;
        PngQrCode?.Save(file.Path.AbsolutePath);
    }

    private async Task<IStorageFile?> DoOpenFilePickerAsync()
    {
        // For learning purposes, we opted to directly get the reference
        // for StorageProvider APIs here inside the ViewModel. 

        // For your real-world apps, you should follow the MVVM principles
        // by making service classes and locating them with DI/IoC.

        // See IoCFileOps project for an example of how to accomplish this.
        if (Avalonia.Application.Current?.ApplicationLifetime is not IClassicDesktopStyleApplicationLifetime desktop ||
            desktop.MainWindow?.StorageProvider is not { } provider)
            throw new NullReferenceException("Missing StorageProvider instance.");

        var files = await provider.OpenFilePickerAsync(new FilePickerOpenOptions()
        {
            Title = "Open Text File",
            AllowMultiple = false
        });

        return files?.Count >= 1 ? files[0] : null;
    }

    private async Task<IStorageFile?> DoSaveFilePickerAsync()
    {
        // For learning purposes, we opted to directly get the reference
        // for StorageProvider APIs here inside the ViewModel. 

        // For your real-world apps, you should follow the MVVM principles
        // by making service classes and locating them with DI/IoC.

        // See DepInject project for a sample of how to accomplish this.
        if (Avalonia.Application.Current?.ApplicationLifetime is not IClassicDesktopStyleApplicationLifetime desktop ||
            desktop.MainWindow?.StorageProvider is not { } provider)
            throw new NullReferenceException("Missing StorageProvider instance.");

        return await provider.SaveFilePickerAsync(new FilePickerSaveOptions()
        {
            Title = "QR code",
            DefaultExtension = "png"
        });
    }
}
