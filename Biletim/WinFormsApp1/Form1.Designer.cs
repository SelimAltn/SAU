using System.Windows.Forms;

namespace WinFormsApp1
{
    partial class Biletim
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Biletim));
            panelMenu = new Panel();
            pictureBox1 = new PictureBox();
            btnKapat = new Button();
            btnKampanyalar = new Button();
            btnKullanciGirisi = new Button();
            btnYeniKullanci = new Button();
            panelLogo = new Panel();
            LBBulunduSayfaAdi = new Label();
            panelUst = new Panel();
            btnBackSatisİcin = new Button();
            btnBackhizmet = new Button();
            panelFormlar = new Panel();
            panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panelLogo.SuspendLayout();
            panelUst.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(39, 49, 65);
            panelMenu.Controls.Add(pictureBox1);
            panelMenu.Controls.Add(btnKapat);
            panelMenu.Controls.Add(btnKampanyalar);
            panelMenu.Controls.Add(btnKullanciGirisi);
            panelMenu.Controls.Add(btnYeniKullanci);
            panelMenu.Controls.Add(panelLogo);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Margin = new Padding(4, 3, 4, 3);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(233, 929);
            panelMenu.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Top;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 48);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(233, 223);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 13;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // btnKapat
            // 
            btnKapat.FlatAppearance.BorderSize = 0;
            btnKapat.FlatStyle = FlatStyle.Flat;
            btnKapat.Font = new Font("Book Antiqua", 15.75F);
            btnKapat.ForeColor = SystemColors.ButtonFace;
            btnKapat.ImageAlign = ContentAlignment.MiddleLeft;
            btnKapat.Location = new Point(0, 471);
            btnKapat.Margin = new Padding(4, 3, 4, 3);
            btnKapat.Name = "btnKapat";
            btnKapat.Padding = new Padding(14, 0, 0, 0);
            btnKapat.Size = new Size(233, 70);
            btnKapat.TabIndex = 12;
            btnKapat.Text = "Kapat";
            btnKapat.UseVisualStyleBackColor = true;
            btnKapat.Click += btnKapat_Click;
            // 
            // btnKampanyalar
            // 
            btnKampanyalar.FlatAppearance.BorderSize = 0;
            btnKampanyalar.FlatStyle = FlatStyle.Flat;
            btnKampanyalar.Font = new Font("Book Antiqua", 15.75F);
            btnKampanyalar.ForeColor = SystemColors.ButtonFace;
            btnKampanyalar.ImageAlign = ContentAlignment.MiddleLeft;
            btnKampanyalar.Location = new Point(0, 404);
            btnKampanyalar.Margin = new Padding(4, 3, 4, 3);
            btnKampanyalar.Name = "btnKampanyalar";
            btnKampanyalar.Padding = new Padding(14, 0, 0, 0);
            btnKampanyalar.Size = new Size(233, 70);
            btnKampanyalar.TabIndex = 5;
            btnKampanyalar.Text = "Kampanyalar";
            btnKampanyalar.UseVisualStyleBackColor = true;
            btnKampanyalar.Click += btnKampanyalar_Click;
            // 
            // btnKullanciGirisi
            // 
            btnKullanciGirisi.FlatAppearance.BorderSize = 0;
            btnKullanciGirisi.FlatStyle = FlatStyle.Flat;
            btnKullanciGirisi.Font = new Font("Book Antiqua", 15.75F);
            btnKullanciGirisi.ForeColor = SystemColors.ButtonFace;
            btnKullanciGirisi.ImageAlign = ContentAlignment.MiddleLeft;
            btnKullanciGirisi.Location = new Point(0, 340);
            btnKullanciGirisi.Margin = new Padding(4, 3, 4, 3);
            btnKullanciGirisi.Name = "btnKullanciGirisi";
            btnKullanciGirisi.Padding = new Padding(14, 0, 0, 0);
            btnKullanciGirisi.Size = new Size(233, 70);
            btnKullanciGirisi.TabIndex = 2;
            btnKullanciGirisi.Text = "Kullancı Girişi";
            btnKullanciGirisi.UseVisualStyleBackColor = true;
            btnKullanciGirisi.Click += btnKullanciGirisi_Click;
            // 
            // btnYeniKullanci
            // 
            btnYeniKullanci.FlatAppearance.BorderSize = 0;
            btnYeniKullanci.FlatStyle = FlatStyle.Flat;
            btnYeniKullanci.Font = new Font("Book Antiqua", 15.75F);
            btnYeniKullanci.ForeColor = SystemColors.ButtonFace;
            btnYeniKullanci.ImageAlign = ContentAlignment.MiddleLeft;
            btnYeniKullanci.Location = new Point(4, 277);
            btnYeniKullanci.Margin = new Padding(4, 3, 4, 3);
            btnYeniKullanci.Name = "btnYeniKullanci";
            btnYeniKullanci.Padding = new Padding(14, 0, 0, 0);
            btnYeniKullanci.Size = new Size(233, 70);
            btnYeniKullanci.TabIndex = 1;
            btnYeniKullanci.Text = "Yeni  Hesap ";
            btnYeniKullanci.UseVisualStyleBackColor = true;
            btnYeniKullanci.Click += btnYeniKullanci_Click;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.FromArgb(39, 49, 65);
            panelLogo.Controls.Add(LBBulunduSayfaAdi);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Margin = new Padding(4, 3, 4, 3);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(233, 48);
            panelLogo.TabIndex = 1;
            // 
            // LBBulunduSayfaAdi
            // 
            LBBulunduSayfaAdi.AutoSize = true;
            LBBulunduSayfaAdi.Font = new Font("Sakkal Majalla", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LBBulunduSayfaAdi.ForeColor = SystemColors.ButtonFace;
            LBBulunduSayfaAdi.Location = new Point(5, 5);
            LBBulunduSayfaAdi.Margin = new Padding(4, 0, 4, 0);
            LBBulunduSayfaAdi.Name = "LBBulunduSayfaAdi";
            LBBulunduSayfaAdi.Size = new Size(68, 35);
            LBBulunduSayfaAdi.TabIndex = 2;
            LBBulunduSayfaAdi.Text = "Home";
            // 
            // panelUst
            // 
            panelUst.BackColor = Color.FromArgb(39, 49, 65);
            panelUst.Controls.Add(btnBackSatisİcin);
            panelUst.Controls.Add(btnBackhizmet);
            panelUst.Dock = DockStyle.Top;
            panelUst.Location = new Point(233, 0);
            panelUst.Margin = new Padding(4, 3, 4, 3);
            panelUst.Name = "panelUst";
            panelUst.Size = new Size(1691, 48);
            panelUst.TabIndex = 1;
            panelUst.Paint += panelUst_Paint;
            // 
            // btnBackSatisİcin
            // 
            btnBackSatisİcin.Dock = DockStyle.Left;
            btnBackSatisİcin.FlatAppearance.BorderSize = 0;
            btnBackSatisİcin.FlatStyle = FlatStyle.Flat;
            btnBackSatisİcin.Location = new Point(86, 0);
            btnBackSatisİcin.Margin = new Padding(4, 3, 4, 3);
            btnBackSatisİcin.Name = "btnBackSatisİcin";
            btnBackSatisİcin.Size = new Size(86, 48);
            btnBackSatisİcin.TabIndex = 1;
            btnBackSatisİcin.UseVisualStyleBackColor = true;
            btnBackSatisİcin.Visible = false;
            // 
            // btnBackhizmet
            // 
            btnBackhizmet.Dock = DockStyle.Left;
            btnBackhizmet.FlatAppearance.BorderSize = 0;
            btnBackhizmet.FlatStyle = FlatStyle.Flat;
            btnBackhizmet.Location = new Point(0, 0);
            btnBackhizmet.Margin = new Padding(4, 3, 4, 3);
            btnBackhizmet.Name = "btnBackhizmet";
            btnBackhizmet.Size = new Size(86, 48);
            btnBackhizmet.TabIndex = 0;
            btnBackhizmet.UseVisualStyleBackColor = true;
            btnBackhizmet.Visible = false;
            // 
            // panelFormlar
            // 
            panelFormlar.Dock = DockStyle.Fill;
            panelFormlar.Location = new Point(233, 48);
            panelFormlar.Margin = new Padding(4, 3, 4, 3);
            panelFormlar.Name = "panelFormlar";
            panelFormlar.Size = new Size(1691, 881);
            panelFormlar.TabIndex = 2;
            // 
            // Biletim
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(1924, 929);
            Controls.Add(panelFormlar);
            Controls.Add(panelUst);
            Controls.Add(panelMenu);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "Biletim";
            Text = "Biletim";
            WindowState = FormWindowState.Maximized;
            Load += Form1_Load;
            panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panelLogo.ResumeLayout(false);
            panelLogo.PerformLayout();
            panelUst.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button btnYeniKullanci;
        private System.Windows.Forms.Button btnKullanciGirisi;
        private System.Windows.Forms.Button btnKampanyalar;
        private System.Windows.Forms.Panel panelUst;
        private System.Windows.Forms.Label LBBulunduSayfaAdi;
        private System.Windows.Forms.Panel panelFormlar;
        private System.Windows.Forms.Button btnBackhizmet;
        private System.Windows.Forms.Button btnKapat;
        private System.Windows.Forms.Button btnBackSatisİcin;
        private PictureBox pictureBox1;
    }
}
