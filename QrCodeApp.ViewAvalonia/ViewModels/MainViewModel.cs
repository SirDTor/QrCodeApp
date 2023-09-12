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
    private string? _qrCodeText;

    private Bitmap? _pngQrCode;

    public Bitmap? PngQrCode 
    { 
        get=> _pngQrCode; 
        set=> this.RaiseAndSetIfChanged(ref _pngQrCode, value); 
    }

    private string _image;

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
    public string Image 
    { 
        get => _image; 
        set => this.RaiseAndSetIfChanged(ref _image, value); 
    }

    public void CreateQrCode()
    {
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeData qrCodeData = qrGenerator.CreateQrCode("The text which should be encoded.", QRCodeGenerator.ECCLevel.Q);

        PngByteQRCode qrCodePng = new PngByteQRCode(qrCodeData);
        byte[] qrCodeImagePng = qrCodePng.GetGraphic(20, new byte[] { 144, 201, 111 }, new byte[] { 118, 126, 152 });
        PngQrCode = ByteToImage(qrCodeImagePng);
    }

    public static Bitmap ByteToImage(byte[] blob)
    {
        using (MemoryStream mStream = new MemoryStream())
        {
            mStream.Write(blob, 0, blob.Length);
            mStream.Seek(0, SeekOrigin.Begin);

            Bitmap bm = new Bitmap(mStream);
            return bm;
        }
    }

}
