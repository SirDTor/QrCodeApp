using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Controls;
using Avalonia.Media.Imaging;
using Avalonia.Platform.Storage;
using QRCoder;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QrCodeApp.ViewAvalonia.ViewModels
{
    public class MainWindowViewModel: MainViewModel
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

        public override void CreateQrCode()
        {
            if (QrTextBox != null)
            {
                QRCodeGenerator qrGenerator = new();
                QRCodeData qrCodeData = qrGenerator.CreateQrCode(QrTextBox, QRCodeGenerator.ECCLevel.M);

                PngByteQRCode qrCodePng = new(qrCodeData);
                byte[] qrCodeImagePng = qrCodePng.GetGraphic(20, QrByteColor, QrByteBackColor);
                PngQrCode = ByteToImage(qrCodeImagePng);
            }
        }

        public override Bitmap ByteToImage(byte[] blob)
        {
            using (MemoryStream memoryStream = new())
            {
                memoryStream.Write(blob, 0, blob.Length);
                memoryStream.Seek(0, SeekOrigin.Begin);

                Bitmap bitmap = new Bitmap(memoryStream);
                return bitmap;
            }
        }

        public override async Task SaveQrCode()
        {
            if (PngQrCode == null) return;
            var file = await DoSaveFilePickerAsync();
            if (file is null) return;
            PngQrCode?.Save(file.Path.AbsolutePath);
        }

        public override async Task LoadQrCode()
        {
            var file = await DoOpenFilePickerAsync();
            if (file is null) return;
            var bitmap = new Bitmap(file.Path.AbsolutePath);
            PngQrCode = bitmap;
        }

        public override async Task<IStorageFile?> DoOpenFilePickerAsync()
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
                Title = "Open QR Code",
                AllowMultiple = false,
                FileTypeFilter = new FilePickerFileType[]
                {
                new("Image")
            {
                Patterns = new[] { "*.png", "*.jpg", "*.jpeg", "*.gif", "*.bmp" },
                AppleUniformTypeIdentifiers = new[] { "public.image" } ,
                MimeTypes = new[] { "image/*" }
            }
                }
            });

            return files?.Count >= 1 ? files[0] : null;
        }

        public override async Task<IStorageFile?> DoSaveFilePickerAsync()
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
                Title = "Save QR code",
                DefaultExtension = "png"
            });
        }
    }
}
