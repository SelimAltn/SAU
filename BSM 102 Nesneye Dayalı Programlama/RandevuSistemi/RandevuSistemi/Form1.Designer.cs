namespace RandevuSistemi
{
    partial class Form1
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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnKapat = new System.Windows.Forms.Button();
            this.btnKozmatikUrunler = new System.Windows.Forms.Button();
            this.btnHostGirisi = new System.Windows.Forms.Button();
            this.btnDegerlendir = new System.Windows.Forms.Button();
            this.btnHakkimizda = new System.Windows.Forms.Button();
            this.btnMemnuniyet = new System.Windows.Forms.Button();
            this.btnCalisanlarimiz = new System.Windows.Forms.Button();
            this.btnHizmetlerimiz = new System.Windows.Forms.Button();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.LBBulunduSayfaAdi = new System.Windows.Forms.Label();
            this.panelUst = new System.Windows.Forms.Panel();
            this.btnBackSatisİcin = new System.Windows.Forms.Button();
            this.btrSakla = new System.Windows.Forms.Button();
            this.btnBackhizmet = new System.Windows.Forms.Button();
            this.btnGenisle = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.panelFormlar = new System.Windows.Forms.Panel();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.panelUst.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelMenu.Controls.Add(this.btnKapat);
            this.panelMenu.Controls.Add(this.btnKozmatikUrunler);
            this.panelMenu.Controls.Add(this.btnHostGirisi);
            this.panelMenu.Controls.Add(this.btnDegerlendir);
            this.panelMenu.Controls.Add(this.btnHakkimizda);
            this.panelMenu.Controls.Add(this.btnMemnuniyet);
            this.panelMenu.Controls.Add(this.btnCalisanlarimiz);
            this.panelMenu.Controls.Add(this.btnHizmetlerimiz);
            this.panelMenu.Controls.Add(this.panelLogo);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(200, 805);
            this.panelMenu.TabIndex = 0;
            // 
            // btnKapat
            // 
            this.btnKapat.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKapat.FlatAppearance.BorderSize = 0;
            this.btnKapat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKapat.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnKapat.Image = global::RandevuSistemi.Properties.Resources.power_off;
            this.btnKapat.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKapat.Location = new System.Drawing.Point(0, 469);
            this.btnKapat.Name = "btnKapat";
            this.btnKapat.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnKapat.Size = new System.Drawing.Size(200, 61);
            this.btnKapat.TabIndex = 12;
            this.btnKapat.Text = "Kapat";
            this.btnKapat.UseVisualStyleBackColor = true;
            this.btnKapat.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // btnKozmatikUrunler
            // 
            this.btnKozmatikUrunler.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnKozmatikUrunler.FlatAppearance.BorderSize = 0;
            this.btnKozmatikUrunler.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKozmatikUrunler.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnKozmatikUrunler.Image = global::RandevuSistemi.Properties.Resources.makeup_brush;
            this.btnKozmatikUrunler.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKozmatikUrunler.Location = new System.Drawing.Point(0, 408);
            this.btnKozmatikUrunler.Name = "btnKozmatikUrunler";
            this.btnKozmatikUrunler.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnKozmatikUrunler.Size = new System.Drawing.Size(200, 61);
            this.btnKozmatikUrunler.TabIndex = 11;
            this.btnKozmatikUrunler.Text = "   Kozmatik Urunler";
            this.btnKozmatikUrunler.UseVisualStyleBackColor = true;
            this.btnKozmatikUrunler.Click += new System.EventHandler(this.btnKozmatikUrunler_Click);
            // 
            // btnHostGirisi
            // 
            this.btnHostGirisi.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHostGirisi.FlatAppearance.BorderSize = 0;
            this.btnHostGirisi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHostGirisi.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnHostGirisi.Image = global::RandevuSistemi.Properties.Resources.program_host;
            this.btnHostGirisi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHostGirisi.Location = new System.Drawing.Point(0, 347);
            this.btnHostGirisi.Name = "btnHostGirisi";
            this.btnHostGirisi.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnHostGirisi.Size = new System.Drawing.Size(200, 61);
            this.btnHostGirisi.TabIndex = 9;
            this.btnHostGirisi.Text = "Host Girişi";
            this.btnHostGirisi.UseVisualStyleBackColor = true;
            this.btnHostGirisi.Click += new System.EventHandler(this.btnHostGirisi_Click_1);
            // 
            // btnDegerlendir
            // 
            this.btnDegerlendir.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDegerlendir.FlatAppearance.BorderSize = 0;
            this.btnDegerlendir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDegerlendir.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnDegerlendir.Image = global::RandevuSistemi.Properties.Resources.satisfaction__1_;
            this.btnDegerlendir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDegerlendir.Location = new System.Drawing.Point(0, 286);
            this.btnDegerlendir.Name = "btnDegerlendir";
            this.btnDegerlendir.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnDegerlendir.Size = new System.Drawing.Size(200, 61);
            this.btnDegerlendir.TabIndex = 6;
            this.btnDegerlendir.Text = "   Bize Değerlendiriniz";
            this.btnDegerlendir.UseVisualStyleBackColor = true;
            this.btnDegerlendir.Click += new System.EventHandler(this.btnDegerlendir_Click);
            // 
            // btnHakkimizda
            // 
            this.btnHakkimizda.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHakkimizda.FlatAppearance.BorderSize = 0;
            this.btnHakkimizda.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHakkimizda.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnHakkimizda.Image = global::RandevuSistemi.Properties.Resources.information;
            this.btnHakkimizda.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHakkimizda.Location = new System.Drawing.Point(0, 225);
            this.btnHakkimizda.Name = "btnHakkimizda";
            this.btnHakkimizda.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnHakkimizda.Size = new System.Drawing.Size(200, 61);
            this.btnHakkimizda.TabIndex = 5;
            this.btnHakkimizda.Text = "Hakkamzda";
            this.btnHakkimizda.UseVisualStyleBackColor = true;
            this.btnHakkimizda.Click += new System.EventHandler(this.btnHakkimizda_Click);
            // 
            // btnMemnuniyet
            // 
            this.btnMemnuniyet.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMemnuniyet.FlatAppearance.BorderSize = 0;
            this.btnMemnuniyet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMemnuniyet.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnMemnuniyet.Image = global::RandevuSistemi.Properties.Resources.customer_review;
            this.btnMemnuniyet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMemnuniyet.Location = new System.Drawing.Point(0, 164);
            this.btnMemnuniyet.Name = "btnMemnuniyet";
            this.btnMemnuniyet.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnMemnuniyet.Size = new System.Drawing.Size(200, 61);
            this.btnMemnuniyet.TabIndex = 4;
            this.btnMemnuniyet.Text = "    Memnuniyet Mesajları";
            this.btnMemnuniyet.UseVisualStyleBackColor = true;
            this.btnMemnuniyet.Click += new System.EventHandler(this.btnMemnuniyet_Click);
            // 
            // btnCalisanlarimiz
            // 
            this.btnCalisanlarimiz.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCalisanlarimiz.FlatAppearance.BorderSize = 0;
            this.btnCalisanlarimiz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalisanlarimiz.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCalisanlarimiz.Image = global::RandevuSistemi.Properties.Resources.team;
            this.btnCalisanlarimiz.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCalisanlarimiz.Location = new System.Drawing.Point(0, 103);
            this.btnCalisanlarimiz.Name = "btnCalisanlarimiz";
            this.btnCalisanlarimiz.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnCalisanlarimiz.Size = new System.Drawing.Size(200, 61);
            this.btnCalisanlarimiz.TabIndex = 2;
            this.btnCalisanlarimiz.Text = "Çalışanlarımız";
            this.btnCalisanlarimiz.UseVisualStyleBackColor = true;
            this.btnCalisanlarimiz.Click += new System.EventHandler(this.btnCalisanlarimiz_Click);
            // 
            // btnHizmetlerimiz
            // 
            this.btnHizmetlerimiz.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHizmetlerimiz.FlatAppearance.BorderSize = 0;
            this.btnHizmetlerimiz.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHizmetlerimiz.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnHizmetlerimiz.Image = global::RandevuSistemi.Properties.Resources.forehead;
            this.btnHizmetlerimiz.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHizmetlerimiz.Location = new System.Drawing.Point(0, 42);
            this.btnHizmetlerimiz.Name = "btnHizmetlerimiz";
            this.btnHizmetlerimiz.Padding = new System.Windows.Forms.Padding(12, 0, 0, 0);
            this.btnHizmetlerimiz.Size = new System.Drawing.Size(200, 61);
            this.btnHizmetlerimiz.TabIndex = 1;
            this.btnHizmetlerimiz.Text = "Hizmetlerimiz";
            this.btnHizmetlerimiz.UseVisualStyleBackColor = true;
            this.btnHizmetlerimiz.Click += new System.EventHandler(this.btnHizmetlerimiz_Click);
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelLogo.Controls.Add(this.LBBulunduSayfaAdi);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(200, 42);
            this.panelLogo.TabIndex = 1;
            // 
            // LBBulunduSayfaAdi
            // 
            this.LBBulunduSayfaAdi.AutoSize = true;
            this.LBBulunduSayfaAdi.Font = new System.Drawing.Font("Sakkal Majalla", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LBBulunduSayfaAdi.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.LBBulunduSayfaAdi.Location = new System.Drawing.Point(4, 4);
            this.LBBulunduSayfaAdi.Name = "LBBulunduSayfaAdi";
            this.LBBulunduSayfaAdi.Size = new System.Drawing.Size(68, 35);
            this.LBBulunduSayfaAdi.TabIndex = 2;
            this.LBBulunduSayfaAdi.Text = "Home";
            // 
            // panelUst
            // 
            this.panelUst.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panelUst.Controls.Add(this.btnBackSatisİcin);
            this.panelUst.Controls.Add(this.btrSakla);
            this.panelUst.Controls.Add(this.btnBackhizmet);
            this.panelUst.Controls.Add(this.btnGenisle);
            this.panelUst.Controls.Add(this.btnClose);
            this.panelUst.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUst.Location = new System.Drawing.Point(200, 0);
            this.panelUst.Name = "panelUst";
            this.panelUst.Size = new System.Drawing.Size(1623, 42);
            this.panelUst.TabIndex = 1;
            this.panelUst.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelUst_MouseDown);
            // 
            // btnBackSatisİcin
            // 
            this.btnBackSatisİcin.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBackSatisİcin.FlatAppearance.BorderSize = 0;
            this.btnBackSatisİcin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackSatisİcin.Image = global::RandevuSistemi.Properties.Resources.left;
            this.btnBackSatisİcin.Location = new System.Drawing.Point(74, 0);
            this.btnBackSatisİcin.Name = "btnBackSatisİcin";
            this.btnBackSatisİcin.Size = new System.Drawing.Size(74, 42);
            this.btnBackSatisİcin.TabIndex = 1;
            this.btnBackSatisİcin.UseVisualStyleBackColor = true;
            this.btnBackSatisİcin.Visible = false;
            this.btnBackSatisİcin.Click += new System.EventHandler(this.btnBackSatisİcin_Click);
            // 
            // btrSakla
            // 
            this.btrSakla.Dock = System.Windows.Forms.DockStyle.Right;
            this.btrSakla.FlatAppearance.BorderSize = 0;
            this.btrSakla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btrSakla.Image = global::RandevuSistemi.Properties.Resources.minus;
            this.btrSakla.Location = new System.Drawing.Point(1515, 0);
            this.btrSakla.Name = "btrSakla";
            this.btrSakla.Size = new System.Drawing.Size(36, 42);
            this.btrSakla.TabIndex = 0;
            this.btrSakla.UseVisualStyleBackColor = true;
            this.btrSakla.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBackhizmet
            // 
            this.btnBackhizmet.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBackhizmet.FlatAppearance.BorderSize = 0;
            this.btnBackhizmet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackhizmet.Image = global::RandevuSistemi.Properties.Resources.left;
            this.btnBackhizmet.Location = new System.Drawing.Point(0, 0);
            this.btnBackhizmet.Name = "btnBackhizmet";
            this.btnBackhizmet.Size = new System.Drawing.Size(74, 42);
            this.btnBackhizmet.TabIndex = 0;
            this.btnBackhizmet.UseVisualStyleBackColor = true;
            this.btnBackhizmet.Visible = false;
            this.btnBackhizmet.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnGenisle
            // 
            this.btnGenisle.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnGenisle.FlatAppearance.BorderSize = 0;
            this.btnGenisle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenisle.Image = global::RandevuSistemi.Properties.Resources.layers;
            this.btnGenisle.Location = new System.Drawing.Point(1551, 0);
            this.btnGenisle.Name = "btnGenisle";
            this.btnGenisle.Size = new System.Drawing.Size(36, 42);
            this.btnGenisle.TabIndex = 1;
            this.btnGenisle.UseVisualStyleBackColor = true;
            this.btnGenisle.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnClose.FlatAppearance.BorderSize = 0;
            this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClose.Image = global::RandevuSistemi.Properties.Resources.___Kopya;
            this.btnClose.Location = new System.Drawing.Point(1587, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(36, 42);
            this.btnClose.TabIndex = 2;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.button3_Click);
            // 
            // panelFormlar
            // 
            this.panelFormlar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelFormlar.Location = new System.Drawing.Point(200, 42);
            this.panelFormlar.Name = "panelFormlar";
            this.panelFormlar.Size = new System.Drawing.Size(1623, 763);
            this.panelFormlar.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1823, 805);
            this.Controls.Add(this.panelFormlar);
            this.Controls.Add(this.panelUst);
            this.Controls.Add(this.panelMenu);
            this.Name = "Form1";
            this.Text = "Kuaför Randevu Sistemi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.panelUst.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button btnHizmetlerimiz;
        private System.Windows.Forms.Button btnCalisanlarimiz;
        private System.Windows.Forms.Button btnMemnuniyet;
        private System.Windows.Forms.Button btnHakkimizda;
        private System.Windows.Forms.Button btnDegerlendir;
        private System.Windows.Forms.Panel panelUst;
        private System.Windows.Forms.Label LBBulunduSayfaAdi;
        private System.Windows.Forms.Panel panelFormlar;
        private System.Windows.Forms.Button btnBackhizmet;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btrSakla;
        private System.Windows.Forms.Button btnGenisle;
        private System.Windows.Forms.Button btnHostGirisi;
        private System.Windows.Forms.Button btnKozmatikUrunler;
        private System.Windows.Forms.Button btnKapat;
        private System.Windows.Forms.Button btnBackSatisİcin;
    }
}

