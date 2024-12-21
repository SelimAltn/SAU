namespace WinFormsApp1
{
    partial class KullanciGiris
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
            panelMenu = new Panel();
            LBBulunduSayfaAdi = new Label();
            btnSeferlerimGoruntule = new Button();
            btnSeferinizDegerlendiriniz = new Button();
            btnBiletDegistir = new Button();
            btnBiletiptalet = new Button();
            btnBiletAl = new Button();
            panelLogo = new Panel();
            panelUst = new Panel();
            btnBackSatisİcin = new Button();
            btrSakla = new Button();
            btnBackhizmet = new Button();
            btnGenisle = new Button();
            btnClose = new Button();
            panelFormlar = new Panel();
            panelMenu.SuspendLayout();
            panelUst.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(39, 49, 65);
            panelMenu.Controls.Add(LBBulunduSayfaAdi);
            panelMenu.Controls.Add(btnSeferlerimGoruntule);
            panelMenu.Controls.Add(btnSeferinizDegerlendiriniz);
            panelMenu.Controls.Add(btnBiletDegistir);
            panelMenu.Controls.Add(btnBiletiptalet);
            panelMenu.Controls.Add(btnBiletAl);
            panelMenu.Controls.Add(panelLogo);
            panelMenu.Dock = DockStyle.Right;
            panelMenu.Location = new Point(1902, 0);
            panelMenu.Margin = new Padding(4, 3, 4, 3);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(225, 929);
            panelMenu.TabIndex = 0;
            // 
            // LBBulunduSayfaAdi
            // 
            LBBulunduSayfaAdi.AutoSize = true;
            LBBulunduSayfaAdi.Font = new Font("Sakkal Majalla", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LBBulunduSayfaAdi.ForeColor = SystemColors.ButtonFace;
            LBBulunduSayfaAdi.Location = new Point(23, 8);
            LBBulunduSayfaAdi.Margin = new Padding(4, 0, 4, 0);
            LBBulunduSayfaAdi.Name = "LBBulunduSayfaAdi";
            LBBulunduSayfaAdi.Size = new Size(170, 35);
            LBBulunduSayfaAdi.TabIndex = 2;
            LBBulunduSayfaAdi.Text = "       Kullancı Girişi";
            // 
            // btnSeferlerimGoruntule
            // 
            btnSeferlerimGoruntule.FlatAppearance.BorderSize = 0;
            btnSeferlerimGoruntule.FlatStyle = FlatStyle.Flat;
            btnSeferlerimGoruntule.ForeColor = SystemColors.ButtonFace;
            btnSeferlerimGoruntule.ImageAlign = ContentAlignment.MiddleLeft;
            btnSeferlerimGoruntule.Location = new Point(-4, 290);
            btnSeferlerimGoruntule.Margin = new Padding(4, 3, 4, 3);
            btnSeferlerimGoruntule.Name = "btnSeferlerimGoruntule";
            btnSeferlerimGoruntule.Padding = new Padding(14, 0, 0, 0);
            btnSeferlerimGoruntule.Size = new Size(233, 70);
            btnSeferlerimGoruntule.TabIndex = 6;
            btnSeferlerimGoruntule.Text = "Seferlerim";
            btnSeferlerimGoruntule.UseVisualStyleBackColor = true;
            // 
            // btnSeferinizDegerlendiriniz
            // 
            btnSeferinizDegerlendiriniz.FlatAppearance.BorderSize = 0;
            btnSeferinizDegerlendiriniz.FlatStyle = FlatStyle.Flat;
            btnSeferinizDegerlendiriniz.ForeColor = SystemColors.ButtonFace;
            btnSeferinizDegerlendiriniz.ImageAlign = ContentAlignment.MiddleLeft;
            btnSeferinizDegerlendiriniz.Location = new Point(-4, 357);
            btnSeferinizDegerlendiriniz.Margin = new Padding(4, 3, 4, 3);
            btnSeferinizDegerlendiriniz.Name = "btnSeferinizDegerlendiriniz";
            btnSeferinizDegerlendiriniz.Padding = new Padding(14, 0, 0, 0);
            btnSeferinizDegerlendiriniz.Size = new Size(233, 70);
            btnSeferinizDegerlendiriniz.TabIndex = 5;
            btnSeferinizDegerlendiriniz.Text = "Seferiniz Değerlendiriniz";
            btnSeferinizDegerlendiriniz.UseVisualStyleBackColor = true;
            // 
            // btnBiletDegistir
            // 
            btnBiletDegistir.FlatAppearance.BorderSize = 0;
            btnBiletDegistir.FlatStyle = FlatStyle.Flat;
            btnBiletDegistir.ForeColor = SystemColors.ButtonFace;
            btnBiletDegistir.ImageAlign = ContentAlignment.MiddleLeft;
            btnBiletDegistir.Location = new Point(-4, 222);
            btnBiletDegistir.Margin = new Padding(4, 3, 4, 3);
            btnBiletDegistir.Name = "btnBiletDegistir";
            btnBiletDegistir.Padding = new Padding(14, 0, 0, 0);
            btnBiletDegistir.Size = new Size(233, 70);
            btnBiletDegistir.TabIndex = 4;
            btnBiletDegistir.Text = "Bilet Değiştir";
            btnBiletDegistir.UseVisualStyleBackColor = true;
            // 
            // btnBiletiptalet
            // 
            btnBiletiptalet.FlatAppearance.BorderSize = 0;
            btnBiletiptalet.FlatStyle = FlatStyle.Flat;
            btnBiletiptalet.ForeColor = SystemColors.ButtonFace;
            btnBiletiptalet.ImageAlign = ContentAlignment.MiddleLeft;
            btnBiletiptalet.Location = new Point(-4, 152);
            btnBiletiptalet.Margin = new Padding(4, 3, 4, 3);
            btnBiletiptalet.Name = "btnBiletiptalet";
            btnBiletiptalet.Padding = new Padding(14, 0, 0, 0);
            btnBiletiptalet.Size = new Size(233, 70);
            btnBiletiptalet.TabIndex = 2;
            btnBiletiptalet.Text = "Bilet iptal et";
            btnBiletiptalet.UseVisualStyleBackColor = true;
            // 
            // btnBiletAl
            // 
            btnBiletAl.FlatAppearance.BorderSize = 0;
            btnBiletAl.FlatStyle = FlatStyle.Flat;
            btnBiletAl.ForeColor = SystemColors.ButtonFace;
            btnBiletAl.ImageAlign = ContentAlignment.MiddleLeft;
            btnBiletAl.Location = new Point(0, 86);
            btnBiletAl.Margin = new Padding(4, 3, 4, 3);
            btnBiletAl.Name = "btnBiletAl";
            btnBiletAl.Padding = new Padding(14, 0, 0, 0);
            btnBiletAl.Size = new Size(233, 70);
            btnBiletAl.TabIndex = 1;
            btnBiletAl.Text = "Bilet Al";
            btnBiletAl.UseVisualStyleBackColor = true;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.FromArgb(39, 49, 65);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Margin = new Padding(4, 3, 4, 3);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(225, 48);
            panelLogo.TabIndex = 1;
            // 
            // panelUst
            // 
            panelUst.BackColor = Color.FromArgb(39, 49, 65);
            panelUst.Controls.Add(btnBackSatisİcin);
            panelUst.Controls.Add(btrSakla);
            panelUst.Controls.Add(btnBackhizmet);
            panelUst.Controls.Add(btnGenisle);
            panelUst.Controls.Add(btnClose);
            panelUst.Dock = DockStyle.Top;
            panelUst.Location = new Point(0, 0);
            panelUst.Margin = new Padding(4, 3, 4, 3);
            panelUst.Name = "panelUst";
            panelUst.Size = new Size(1902, 48);
            panelUst.TabIndex = 1;
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
            // btrSakla
            // 
            btrSakla.Dock = DockStyle.Right;
            btrSakla.FlatAppearance.BorderSize = 0;
            btrSakla.FlatStyle = FlatStyle.Flat;
            btrSakla.Location = new Point(1776, 0);
            btrSakla.Margin = new Padding(4, 3, 4, 3);
            btrSakla.Name = "btrSakla";
            btrSakla.Size = new Size(42, 48);
            btrSakla.TabIndex = 0;
            btrSakla.UseVisualStyleBackColor = true;
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
            // btnGenisle
            // 
            btnGenisle.Dock = DockStyle.Right;
            btnGenisle.FlatAppearance.BorderSize = 0;
            btnGenisle.FlatStyle = FlatStyle.Flat;
            btnGenisle.Location = new Point(1818, 0);
            btnGenisle.Margin = new Padding(4, 3, 4, 3);
            btnGenisle.Name = "btnGenisle";
            btnGenisle.Size = new Size(42, 48);
            btnGenisle.TabIndex = 1;
            btnGenisle.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            btnClose.Dock = DockStyle.Right;
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Location = new Point(1860, 0);
            btnClose.Margin = new Padding(4, 3, 4, 3);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(42, 48);
            btnClose.TabIndex = 2;
            btnClose.UseVisualStyleBackColor = true;
            // 
            // panelFormlar
            // 
            panelFormlar.Dock = DockStyle.Fill;
            panelFormlar.Location = new Point(0, 48);
            panelFormlar.Margin = new Padding(4, 3, 4, 3);
            panelFormlar.Name = "panelFormlar";
            panelFormlar.Size = new Size(1902, 881);
            panelFormlar.TabIndex = 2;
            // 
            // KullanciGiris
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            ClientSize = new Size(2127, 929);
            Controls.Add(panelFormlar);
            Controls.Add(panelUst);
            Controls.Add(panelMenu);
            Margin = new Padding(4, 3, 4, 3);
            Name = "KullanciGiris";
            Text = "Kullancı Girişi";
            WindowState = FormWindowState.Maximized;
            Load += KullanciGiris_Load;
            panelMenu.ResumeLayout(false);
            panelMenu.PerformLayout();
            panelUst.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button btnBiletAl;
        private System.Windows.Forms.Button btnBiletiptalet;
        private System.Windows.Forms.Button btnBiletDegistir;
        private System.Windows.Forms.Button btnSeferinizDegerlendiriniz;
        private System.Windows.Forms.Button btnSeferlerimGoruntule;
        private System.Windows.Forms.Panel panelUst;
        private System.Windows.Forms.Label LBBulunduSayfaAdi;
        private System.Windows.Forms.Panel panelFormlar;
        private System.Windows.Forms.Button btnBackhizmet;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btrSakla;
        private System.Windows.Forms.Button btnGenisle;
        private System.Windows.Forms.Button btnBiletDurumu;
        private System.Windows.Forms.Button btnBackSatisİcin;
    }
}