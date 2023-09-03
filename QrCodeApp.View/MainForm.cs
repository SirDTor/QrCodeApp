using MessagingToolkit.QRCode.Codec;
using MessagingToolkit.QRCode.Codec.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace QrCodeApp.View
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void infoLabel_Click(object sender, EventArgs e)
        {
        }

        private void createQrCodeButton_Click(object sender, EventArgs e)
        {
            string qrtext = writeTextBox.Text; //считываем текст из TextBox'a
            QRCodeEncoder encoder = new QRCodeEncoder(); //создаем объект класса QRCodeEncoder
            Bitmap qrcode = encoder.Encode(qrtext); // кодируем слово, полученное из TextBox'a (qrtext) в переменную qrcode. класса Bitmap(класс, который используется для работы с изображениями)
            qrCodePictureBox.Image = qrcode as Image; // pictureBox выводит qrcode как изображение.
        }

        private void saveQrCodeButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog(); // save будет запрашивать у пользователя, место, в которое он захочет сохранить файл. 
            save.Filter = "PNG|*.png|JPEG|*.jpg|GIF|*.gif|BMP|*.bmp|ico|*.ico"; //создаём фильтр, который определяет, в каких форматах мы сможем сохранить нашу информацию. В данном случае выбираем форматы изображений. Записывается так: "название_формата_в обозревателе|*.расширение_формата")
            if (save.ShowDialog() == System.Windows.Forms.DialogResult.OK) //если пользователь нажимает в обозревателе кнопку "Сохранить".
            {
                qrCodePictureBox.Image.Save(save.FileName); //изображение из pictureBox'a сохр
            }
        }

        private void loadQrCodeButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog load = new OpenFileDialog(); //  load будет запрашивать у пользователя место, из которого он хочет загрузить файл.
            if (load.ShowDialog() == System.Windows.Forms.DialogResult.OK) // //если пользователь нажимает в обозревателе кнопку "Открыть".
            {
                qrCodePictureBox.ImageLocation = load.FileName; // в pictureBox'e открывается файл, который был по пути, запрошенном пользователем.
            }
        }

        private void ScanQrCodeButton_Click(object sender, EventArgs e)
        {
            QRCodeDecoder decoder = new QRCodeDecoder(); // создаём "раскодирование изображения"
            MessageBox.Show(decoder.Decode(new QRCodeBitmapImage(qrCodePictureBox.Image as Bitmap))); //в MessageBox'e программа запишет раскодированное сообщение с изображения, которое предоврительно будет переведено из pictureBox'a в класс Bitmap, чтобы мы смогли с этим изображением работать. 
        }
    }
}
