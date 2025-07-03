namespace RandevuSistemi.Forms
{
    partial class frmYeniPersonelEkle
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnKaydet = new System.Windows.Forms.Button();
            this.txtOzGecmis = new System.Windows.Forms.RichTextBox();
            this.lbOzGecmis1 = new System.Windows.Forms.Label();
            this.txtCalisanUzmanAlani = new System.Windows.Forms.TextBox();
            this.txtCalisanAdi = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbUzmanAlani1 = new System.Windows.Forms.Label();
            this.lbCalısanAdi1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnKaydet);
            this.panel1.Controls.Add(this.txtOzGecmis);
            this.panel1.Controls.Add(this.lbOzGecmis1);
            this.panel1.Controls.Add(this.txtCalisanUzmanAlani);
            this.panel1.Controls.Add(this.txtCalisanAdi);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbUzmanAlani1);
            this.panel1.Controls.Add(this.lbCalısanAdi1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1806, 913);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnKaydet
            // 
            this.btnKaydet.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnKaydet.FlatAppearance.BorderSize = 0;
            this.btnKaydet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnKaydet.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnKaydet.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnKaydet.Image = global::RandevuSistemi.Properties.Resources.folder_download;
            this.btnKaydet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnKaydet.Location = new System.Drawing.Point(937, 654);
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(168, 52);
            this.btnKaydet.TabIndex = 99;
            this.btnKaydet.Text = "   Kaydet";
            this.btnKaydet.UseVisualStyleBackColor = false;
            this.btnKaydet.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtOzGecmis
            // 
            this.txtOzGecmis.Location = new System.Drawing.Point(811, 398);
            this.txtOzGecmis.Name = "txtOzGecmis";
            this.txtOzGecmis.Size = new System.Drawing.Size(408, 231);
            this.txtOzGecmis.TabIndex = 98;
            this.txtOzGecmis.Text = "";
            // 
            // lbOzGecmis1
            // 
            this.lbOzGecmis1.AutoSize = true;
            this.lbOzGecmis1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbOzGecmis1.Location = new System.Drawing.Point(676, 398);
            this.lbOzGecmis1.Name = "lbOzGecmis1";
            this.lbOzGecmis1.Size = new System.Drawing.Size(129, 27);
            this.lbOzGecmis1.TabIndex = 12;
            this.lbOzGecmis1.Text = "Öz Geçmiş :";
            // 
            // txtCalisanUzmanAlani
            // 
            this.txtCalisanUzmanAlani.Location = new System.Drawing.Point(814, 360);
            this.txtCalisanUzmanAlani.Name = "txtCalisanUzmanAlani";
            this.txtCalisanUzmanAlani.Size = new System.Drawing.Size(405, 20);
            this.txtCalisanUzmanAlani.TabIndex = 95;
            // 
            // txtCalisanAdi
            // 
            this.txtCalisanAdi.Location = new System.Drawing.Point(814, 323);
            this.txtCalisanAdi.Name = "txtCalisanAdi";
            this.txtCalisanAdi.Size = new System.Drawing.Size(405, 20);
            this.txtCalisanAdi.TabIndex = 94;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Unispace", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(158, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(555, 35);
            this.label1.TabIndex = 93;
            this.label1.Text = "Yeni Çalışan Bilgileri Giriniz";
            // 
            // lbUzmanAlani1
            // 
            this.lbUzmanAlani1.AutoSize = true;
            this.lbUzmanAlani1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbUzmanAlani1.Location = new System.Drawing.Point(645, 355);
            this.lbUzmanAlani1.Name = "lbUzmanAlani1";
            this.lbUzmanAlani1.Size = new System.Drawing.Size(148, 27);
            this.lbUzmanAlani1.TabIndex = 91;
            this.lbUzmanAlani1.Text = "Uzman Alanı :";
            // 
            // lbCalısanAdi1
            // 
            this.lbCalısanAdi1.AutoSize = true;
            this.lbCalısanAdi1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbCalısanAdi1.Location = new System.Drawing.Point(640, 323);
            this.lbCalısanAdi1.Name = "lbCalısanAdi1";
            this.lbCalısanAdi1.Size = new System.Drawing.Size(153, 27);
            this.lbCalısanAdi1.TabIndex = 88;
            this.lbCalısanAdi1.Text = "Çalışanın Adı :";
            // 
            // PictureBox1
            // 
            this.pictureBox1.Image = global::RandevuSistemi.Properties.Resources.user1;
            this.pictureBox1.Location = new System.Drawing.Point(896, 53);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(237, 203);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 87;
            this.pictureBox1.TabStop = false;
            // 
            // YeniPersonelEkle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1806, 913);
            this.Controls.Add(this.panel1);
            this.Name = "YeniPersonelEkle";
            this.Text = "YeniPersonelEkle";
            this.Load += new System.EventHandler(this.YeniPersonelEkle_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtCalisanUzmanAlani;
        private System.Windows.Forms.TextBox txtCalisanAdi;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbUzmanAlani1;
        private System.Windows.Forms.Label lbCalısanAdi1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.RichTextBox txtOzGecmis;
        private System.Windows.Forms.Label lbOzGecmis1;
        private System.Windows.Forms.Button btnKaydet;
    }
}