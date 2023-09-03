namespace QrCodeApp.View
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            panel1 = new Panel();
            groupBox1 = new GroupBox();
            qrCodePictureBox = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            infoLabel = new Label();
            writeTextBox = new TextBox();
            buttonsTableLayoutPanel = new TableLayoutPanel();
            createQrCodeButton = new Button();
            saveQrCodeButton = new Button();
            loadQrCodeButton = new Button();
            ScanQrCodeButton = new Button();
            scanWithCameraButton = new Button();
            panel1.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)qrCodePictureBox).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            buttonsTableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Controls.Add(buttonsTableLayoutPanel);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(2);
            panel1.Name = "panel1";
            panel1.Size = new Size(268, 505);
            panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.Controls.Add(qrCodePictureBox);
            groupBox1.Location = new Point(12, 12);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(244, 250);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "QR code";
            // 
            // qrCodePictureBox
            // 
            qrCodePictureBox.BackgroundImageLayout = ImageLayout.Center;
            qrCodePictureBox.Dock = DockStyle.Fill;
            qrCodePictureBox.Location = new Point(3, 19);
            qrCodePictureBox.Margin = new Padding(6);
            qrCodePictureBox.Name = "qrCodePictureBox";
            qrCodePictureBox.Size = new Size(238, 228);
            qrCodePictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            qrCodePictureBox.TabIndex = 1;
            qrCodePictureBox.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(infoLabel, 0, 0);
            tableLayoutPanel1.Controls.Add(writeTextBox, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new Point(0, 265);
            tableLayoutPanel1.Margin = new Padding(0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(268, 63);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // infoLabel
            // 
            infoLabel.Anchor = AnchorStyles.Bottom;
            infoLabel.AutoSize = true;
            infoLabel.Location = new Point(105, 16);
            infoLabel.Name = "infoLabel";
            infoLabel.Size = new Size(58, 15);
            infoLabel.TabIndex = 0;
            infoLabel.Text = "Write text";
            // 
            // writeTextBox
            // 
            writeTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            writeTextBox.Location = new Point(3, 34);
            writeTextBox.Name = "writeTextBox";
            writeTextBox.Size = new Size(262, 23);
            writeTextBox.TabIndex = 1;
            // 
            // buttonsTableLayoutPanel
            // 
            buttonsTableLayoutPanel.ColumnCount = 1;
            buttonsTableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            buttonsTableLayoutPanel.Controls.Add(createQrCodeButton, 0, 0);
            buttonsTableLayoutPanel.Controls.Add(saveQrCodeButton, 0, 1);
            buttonsTableLayoutPanel.Controls.Add(loadQrCodeButton, 0, 2);
            buttonsTableLayoutPanel.Controls.Add(ScanQrCodeButton, 0, 3);
            buttonsTableLayoutPanel.Controls.Add(scanWithCameraButton, 0, 4);
            buttonsTableLayoutPanel.Dock = DockStyle.Bottom;
            buttonsTableLayoutPanel.Location = new Point(0, 328);
            buttonsTableLayoutPanel.Name = "buttonsTableLayoutPanel";
            buttonsTableLayoutPanel.RowCount = 5;
            buttonsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 19.9999962F));
            buttonsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20.0000019F));
            buttonsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20.0000019F));
            buttonsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20.0000019F));
            buttonsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 20.0000019F));
            buttonsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            buttonsTableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            buttonsTableLayoutPanel.Size = new Size(268, 177);
            buttonsTableLayoutPanel.TabIndex = 0;
            // 
            // createQrCodeButton
            // 
            createQrCodeButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            createQrCodeButton.Location = new Point(3, 3);
            createQrCodeButton.Name = "createQrCodeButton";
            createQrCodeButton.Size = new Size(262, 29);
            createQrCodeButton.TabIndex = 2;
            createQrCodeButton.Text = "Create QR code";
            createQrCodeButton.UseVisualStyleBackColor = true;
            createQrCodeButton.Click += createQrCodeButton_Click;
            // 
            // saveQrCodeButton
            // 
            saveQrCodeButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            saveQrCodeButton.Location = new Point(3, 38);
            saveQrCodeButton.Name = "saveQrCodeButton";
            saveQrCodeButton.Size = new Size(262, 29);
            saveQrCodeButton.TabIndex = 3;
            saveQrCodeButton.Text = "Save QR code";
            saveQrCodeButton.UseVisualStyleBackColor = true;
            saveQrCodeButton.Click += saveQrCodeButton_Click;
            // 
            // loadQrCodeButton
            // 
            loadQrCodeButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            loadQrCodeButton.Location = new Point(3, 73);
            loadQrCodeButton.Name = "loadQrCodeButton";
            loadQrCodeButton.Size = new Size(262, 29);
            loadQrCodeButton.TabIndex = 4;
            loadQrCodeButton.Text = "Load QR code";
            loadQrCodeButton.UseVisualStyleBackColor = true;
            loadQrCodeButton.Click += loadQrCodeButton_Click;
            // 
            // ScanQrCodeButton
            // 
            ScanQrCodeButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ScanQrCodeButton.Location = new Point(3, 108);
            ScanQrCodeButton.Name = "ScanQrCodeButton";
            ScanQrCodeButton.Size = new Size(262, 29);
            ScanQrCodeButton.TabIndex = 5;
            ScanQrCodeButton.Text = "Scan QR code";
            ScanQrCodeButton.UseVisualStyleBackColor = true;
            ScanQrCodeButton.Click += ScanQrCodeButton_Click;
            // 
            // scanWithCameraButton
            // 
            scanWithCameraButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            scanWithCameraButton.Enabled = false;
            scanWithCameraButton.Location = new Point(3, 143);
            scanWithCameraButton.Name = "scanWithCameraButton";
            scanWithCameraButton.Size = new Size(262, 31);
            scanWithCameraButton.TabIndex = 6;
            scanWithCameraButton.Text = "Not available";
            scanWithCameraButton.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(268, 505);
            Controls.Add(panel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(284, 544);
            MinimumSize = new Size(284, 544);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QrCodeApp";
            panel1.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)qrCodePictureBox).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            buttonsTableLayoutPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox qrCodePictureBox;
        private TableLayoutPanel buttonsTableLayoutPanel;
        private Button createQrCodeButton;
        private Button saveQrCodeButton;
        private Button loadQrCodeButton;
        private Button ScanQrCodeButton;
        private Button scanWithCameraButton;
        private TableLayoutPanel tableLayoutPanel1;
        private Label infoLabel;
        private TextBox writeTextBox;
        private GroupBox groupBox1;
    }
}