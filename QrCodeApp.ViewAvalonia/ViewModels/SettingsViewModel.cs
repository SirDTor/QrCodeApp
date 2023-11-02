using Avalonia.Media;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QrCodeApp.ViewAvalonia.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        private Color _qrColor = Colors.White;
        private Color _qrBackColor = Colors.Black;
        private string _qrChangeBackColorText = "Qr background color";
        private string _qrChangeColorText = "Qr color";
        private string _inQrImage = "Image in QR code";
        private byte[] _qrByteBackColor = new byte[4];
        private byte[] _qrByteColor = new byte[4];

        public Color QrColor { get => _qrColor; set => this.RaiseAndSetIfChanged(ref _qrColor, value); }
        public Color QrBackColor { get => _qrBackColor; set => this.RaiseAndSetIfChanged(ref _qrBackColor, value); }
        public string QrChangeBackColorText { get => _qrChangeBackColorText; set => this.RaiseAndSetIfChanged(ref _qrChangeBackColorText, value); }
        public string QrChangeColorText { get => _qrChangeColorText; set => this.RaiseAndSetIfChanged(ref _qrChangeColorText, value); }
        public string InQrImage { get => _inQrImage; set => this.RaiseAndSetIfChanged(ref _inQrImage, value); }
        public byte[] QrByteBackColor { get => _qrByteBackColor; set => this.RaiseAndSetIfChanged(ref _qrByteBackColor, value); }
        public byte[] QrByteColor { get => _qrByteColor; set => this.RaiseAndSetIfChanged(ref _qrByteColor, value); }


        public SettingsViewModel()
        {
            this.WhenAnyValue(x => x.QrColor)
                .Where(x => !x.Equals(null))
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(ChangeQrColor!);
            this.WhenAnyValue(x => x.QrBackColor)
                .Where(x => !x.Equals(null))
                .ObserveOn(RxApp.MainThreadScheduler)
                .Subscribe(ChangeQrBackColor!);
        }

        public async void ChangeQrColor(Color QrColor)
        {
            QrByteBackColor[0] = QrColor.R;
            QrByteBackColor[1] = QrColor.G;
            QrByteBackColor[2] = QrColor.B;
            QrByteBackColor[3] = QrColor.A;
        }

        public async void ChangeQrBackColor(Color QrBackColor)
        {
            QrByteColor[0] = QrBackColor.R;
            QrByteColor[1] = QrBackColor.G;
            QrByteColor[2] = QrBackColor.B;
            QrByteColor[3] = QrBackColor.A;
        }
    }
}
