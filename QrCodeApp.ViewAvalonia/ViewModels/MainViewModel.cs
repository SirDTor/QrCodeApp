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

namespace QrCodeApp.ViewAvalonia.ViewModels;

public class MainViewModel : ViewModelBase
{
    private string? _qrTextBox;

    private Bitmap? _pngQrCode;

    public Interaction<Bitmap,Unit?> SaveQrCodeInteraction { get; set; }

    public ReactiveCommand<Unit, Unit>? CreateQrCodeCommand { get; }

    public ReactiveCommand<Unit,Unit> SaveQrCodeCommand { get; }

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
        SaveQrCodeInteraction = new Interaction<Bitmap, Unit?>();

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

}
