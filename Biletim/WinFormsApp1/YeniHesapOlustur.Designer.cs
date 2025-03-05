namespace WinFormsApp1
{
    partial class YeniHesapOlustur
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(YeniHesapOlustur));
            panel1 = new Panel();
            txtMusteriSifre = new TextBox();
            label4 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            txtMusteriGmaili = new TextBox();
            label2 = new Label();
            btnKaydet = new Button();
            txtMusteriSoyAdi = new TextBox();
            txtMusteriAdi = new TextBox();
            label1 = new Label();
            lbUzmanAlani1 = new Label();
            lbCalısanAdi1 = new Label();
            pictureBox1 = new PictureBox();
            groupBox1 = new GroupBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(groupBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(2107, 1053);
            panel1.TabIndex = 0;
            // 
            // txtMusteriSifre
            // 
            txtMusteriSifre.Location = new Point(690, 339);
            txtMusteriSifre.Margin = new Padding(4, 3, 4, 3);
            txtMusteriSifre.Name = "txtMusteriSifre";
            txtMusteriSifre.Size = new Size(287, 23);
            txtMusteriSifre.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label4.Location = new Point(552, 339);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(66, 27);
            label4.TabIndex = 104;
            label4.Text = "şifre :";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(690, 287);
            textBox1.Margin = new Padding(4, 3, 4, 3);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(287, 23);
            textBox1.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label3.Location = new Point(552, 283);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(96, 27);
            label3.TabIndex = 102;
            label3.Text = "Telefon :";
            // 
            // txtMusteriGmaili
            // 
            txtMusteriGmaili.Location = new Point(690, 240);
            txtMusteriGmaili.Margin = new Padding(4, 3, 4, 3);
            txtMusteriGmaili.Name = "txtMusteriGmaili";
            txtMusteriGmaili.Size = new Size(287, 23);
            txtMusteriGmaili.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label2.Location = new Point(552, 236);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(88, 27);
            label2.TabIndex = 100;
            label2.Text = "Gmail : ";
            // 
            // btnKaydet
            // 
            btnKaydet.BackColor = SystemColors.ActiveCaption;
            btnKaydet.FlatAppearance.BorderSize = 0;
            btnKaydet.FlatStyle = FlatStyle.Flat;
            btnKaydet.Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            btnKaydet.ForeColor = SystemColors.ControlLightLight;
            btnKaydet.ImageAlign = ContentAlignment.MiddleLeft;
            btnKaydet.Location = new Point(1135, 217);
            btnKaydet.Margin = new Padding(4, 3, 4, 3);
            btnKaydet.Name = "btnKaydet";
            btnKaydet.Size = new Size(196, 60);
            btnKaydet.TabIndex = 6;
            btnKaydet.Text = "   Kaydet";
            btnKaydet.UseVisualStyleBackColor = false;
            btnKaydet.Click += btnKaydet_Click;
            // 
            // txtMusteriSoyAdi
            // 
            txtMusteriSoyAdi.Location = new Point(690, 192);
            txtMusteriSoyAdi.Margin = new Padding(4, 3, 4, 3);
            txtMusteriSoyAdi.Name = "txtMusteriSoyAdi";
            txtMusteriSoyAdi.Size = new Size(287, 23);
            txtMusteriSoyAdi.TabIndex = 2;
            // 
            // txtMusteriAdi
            // 
            txtMusteriAdi.Location = new Point(690, 150);
            txtMusteriAdi.Margin = new Padding(4, 3, 4, 3);
            txtMusteriAdi.Name = "txtMusteriAdi";
            txtMusteriAdi.Size = new Size(287, 23);
            txtMusteriAdi.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Palatino Linotype", 36F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 162);
            label1.Location = new Point(532, 0);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(582, 63);
            label1.TabIndex = 100;
            label1.Text = "Hesap Bilgileriniz Giriniz";
            // 
            // lbUzmanAlani1
            // 
            lbUzmanAlani1.AutoSize = true;
            lbUzmanAlani1.Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lbUzmanAlani1.Location = new Point(552, 188);
            lbUzmanAlani1.Margin = new Padding(4, 0, 4, 0);
            lbUzmanAlani1.Name = "lbUzmanAlani1";
            lbUzmanAlani1.Size = new Size(89, 27);
            lbUzmanAlani1.TabIndex = 91;
            lbUzmanAlani1.Text = "Soyad : ";
            // 
            // lbCalısanAdi1
            // 
            lbCalısanAdi1.AutoSize = true;
            lbCalısanAdi1.Font = new Font("Times New Roman", 18F, FontStyle.Regular, GraphicsUnit.Point, 162);
            lbCalısanAdi1.Location = new Point(552, 146);
            lbCalısanAdi1.Margin = new Padding(4, 0, 4, 0);
            lbCalısanAdi1.Name = "lbCalısanAdi1";
            lbCalısanAdi1.Size = new Size(53, 27);
            lbCalısanAdi1.TabIndex = 88;
            lbCalısanAdi1.Text = "Ad :";
            lbCalısanAdi1.Click += lbCalısanAdi1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(163, 146);
            pictureBox1.Margin = new Padding(4, 3, 4, 3);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(269, 226);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 87;
            pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(204, 221, 231);
            groupBox1.Controls.Add(btnKaydet);
            groupBox1.Controls.Add(label1);
            groupBox1.Controls.Add(txtMusteriSifre);
            groupBox1.Controls.Add(pictureBox1);
            groupBox1.Controls.Add(lbCalısanAdi1);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(lbUzmanAlani1);
            groupBox1.Controls.Add(textBox1);
            groupBox1.Controls.Add(txtMusteriAdi);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtMusteriSoyAdi);
            groupBox1.Controls.Add(txtMusteriGmaili);
            groupBox1.Controls.Add(label2);
            groupBox1.Location = new Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(2069, 447);
            groupBox1.TabIndex = 106;
            groupBox1.TabStop = false;
            // 
            // YeniHesapOlustur
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2107, 1053);
            Controls.Add(panel1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "YeniHesapOlustur";
            Text = "YeniPersonelEkle";
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtMusteriSoyAdi;
        private System.Windows.Forms.TextBox txtMusteriAdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbUzmanAlani1;
        private System.Windows.Forms.Label lbCalısanAdi1;
        private System.Windows.Forms.Button btnKaydet;
        private TextBox txtMusteriGmaili;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
        private PictureBox pictureBox1;
        private TextBox txtMusteriSifre;
        private Label label4;
        private GroupBox groupBox1;
    }
}