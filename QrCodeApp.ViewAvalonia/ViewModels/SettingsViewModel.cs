using Avalonia.Media;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QrCodeApp.ViewAvalonia.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        private Color _qrColor;
        private Color _qrBackColor;
        private string _qrChangeColorText = "Qr background color";
        private byte[] _qrByteColor = new byte[4];

        public Color QrColor { get => _qrColor; set => this.RaiseAndSetIfChanged(ref _qrColor, value); }
        public Color QrBackColor { get => _qrBackColor; set => this.RaiseAndSetIfChanged(ref _qrBackColor, value); }
        public string QrChangeColorText { get => _qrChangeColorText; set => this.RaiseAndSetIfChanged(ref _qrChangeColorText, value); }
        public byte[] QrByteColor { get => _qrByteColor; set => this.RaiseAndSetIfChanged(ref _qrByteColor, value); }

        public Color ChangeQrColor()
        {
            QrByteColor[0] = QrColor.R;
            QrByteColor[1] = QrColor.G;
            QrByteColor[2] = QrColor.B;
            QrByteColor[3] = QrColor.A;
            return QrColor;
        }
    }
}
