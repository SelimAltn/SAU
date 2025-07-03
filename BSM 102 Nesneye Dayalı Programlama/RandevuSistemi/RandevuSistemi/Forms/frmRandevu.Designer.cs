namespace RandevuSistemi.Forms
{
    partial class frmRandevu
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.txtAd = new System.Windows.Forms.TextBox();
            this.txtSoyAd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxPersonelSecme = new System.Windows.Forms.ComboBox();
            this.lbKampanya = new System.Windows.Forms.Label();
            this.cbxkampanyalar = new System.Windows.Forms.ComboBox();
            this.cbxHizmetler = new System.Windows.Forms.ComboBox();
            this.lbHizmet = new System.Windows.Forms.Label();
            this.rbKampanya = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.labelfiyatadi = new System.Windows.Forms.Label();
            this.lbFiyat = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbxRandevuSaati = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbHizmetinAdi = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btnRandevuEkle = new System.Windows.Forms.Button();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.cbxMusteriler = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.rbtnEski = new System.Windows.Forms.RadioButton();
            this.rbtnYeni = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.menuPanel.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 447);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1806, 466);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(5, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ad";
            // 
            // txtAd
            // 
            this.txtAd.Location = new System.Drawing.Point(119, 55);
            this.txtAd.Name = "txtAd";
            this.txtAd.Size = new System.Drawing.Size(139, 20);
            this.txtAd.TabIndex = 2;
            // 
            // txtSoyAd
            // 
            this.txtSoyAd.Location = new System.Drawing.Point(119, 104);
            this.txtSoyAd.Name = "txtSoyAd";
            this.txtSoyAd.Size = new System.Drawing.Size(139, 20);
            this.txtSoyAd.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(5, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "SoyAd";
            // 
            // txtTel
            // 
            this.txtTel.Location = new System.Drawing.Point(119, 156);
            this.txtTel.Name = "txtTel";
            this.txtTel.Size = new System.Drawing.Size(139, 20);
            this.txtTel.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(3, 150);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 28);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tel Numara";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label4.Location = new System.Drawing.Point(3, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 28);
            this.label4.TabIndex = 9;
            this.label4.Text = "Personel Seçiniz";
            // 
            // cbxPersonelSecme
            // 
            this.cbxPersonelSecme.FormattingEnabled = true;
            this.cbxPersonelSecme.Location = new System.Drawing.Point(151, 55);
            this.cbxPersonelSecme.Name = "cbxPersonelSecme";
            this.cbxPersonelSecme.Size = new System.Drawing.Size(139, 21);
            this.cbxPersonelSecme.TabIndex = 10;
            this.cbxPersonelSecme.SelectedIndexChanged += new System.EventHandler(this.cbxPersonelSecme_SelectedIndexChanged);
            // 
            // lbKampanya
            // 
            this.lbKampanya.AutoSize = true;
            this.lbKampanya.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbKampanya.Location = new System.Drawing.Point(3, 49);
            this.lbKampanya.Name = "lbKampanya";
            this.lbKampanya.Size = new System.Drawing.Size(164, 28);
            this.lbKampanya.TabIndex = 11;
            this.lbKampanya.Text = "Kampanyalarımız :";
            this.lbKampanya.Visible = false;
            // 
            // cbxkampanyalar
            // 
            this.cbxkampanyalar.FormattingEnabled = true;
            this.cbxkampanyalar.Items.AddRange(new object[] {
            "Paket 1: Cilt Bakımı(tüm hizmetleri) +\\n Gündelik Makyaj + Tırnak Bakımı",
            "Paket 2: Masaj Terapisi + Kaş Şekillendirme + Güneşlenme ve Bronzlaşma",
            "Paket 3: Epilasyon ve Ağda + Saç Bakımı + Özel Etkinlikler İçin Makyaj",
            "Paket 4: Kaş ve Kirpik Bakımı + Manikür ve Pedikür + Doğal bronzlaşma maskeleri",
            "Paket 5: Vücut Masajı + Masaj ve Maske Uygulaması + Gelin Makyajı",
            "Paket 6: Sırt Masajı + Renklendirme + Topuk Bakımı",
            "Paket 7: Yüz Temizleme + Aromaterapi Masajı + Solaryum",
            "Paket 8: Kirpik Kıvırma Ve Uzatma + Tırnak Bakımı + Güzellik Bakımı Konsültasyonu" +
                "",
            "Paket 9: Epilasyon + Bronzlaşma + Özel Masaj ve Maske Uygulaması",
            "Paket 10: Kaş Boyama + Perma + Gündelik Makyaj",
            "Paket 11: Saç Bakımı + Yüz Temizleme + Ağda",
            "Paket 12: Masaj Terapisi + Gündelik Makyaj + Topuk Bakımı",
            "Paket 13: Epilasyon ve Ağda + Sırt Masajı + Kaş ve Kirpik Bakımı",
            "Paket 14: Güneşlenme ve Bronzlaşma + Manikür ve Pedikür + Vücut Peelingi",
            "Paket 15: Masaj Terapisi + Gelin Makyajı + Doğal Bronzlaşma Maskeleri"});
            this.cbxkampanyalar.Location = new System.Drawing.Point(170, 52);
            this.cbxkampanyalar.Name = "cbxkampanyalar";
            this.cbxkampanyalar.Size = new System.Drawing.Size(445, 21);
            this.cbxkampanyalar.TabIndex = 12;
            this.cbxkampanyalar.Visible = false;
            this.cbxkampanyalar.SelectedIndexChanged += new System.EventHandler(this.cbxkampanyalar_SelectedIndexChanged);
            // 
            // cbxHizmetler
            // 
            this.cbxHizmetler.FormattingEnabled = true;
            this.cbxHizmetler.Items.AddRange(new object[] {
            "Yüz Temizleme",
            "Buhar",
            "Masaj",
            "Gündelik Makyaj",
            "Özel Etkinlikler",
            "Gelin Makyajı",
            "Kesim",
            "Renklendirme",
            "Perma",
            "Tırnak Bakımı",
            "Cila Uygulamaları",
            "Topuk Bakımı",
            "Epilasyon",
            "Ağda",
            "Vücut Peelingi",
            "Vücut Masajı",
            "Sırt Masajı",
            "Aromaterapi Masajı",
            "Kaş Şekillendirme",
            "Kaş Boyama",
            "Kirpik Kıvırma Ve Uzatma",
            "Solaryum",
            "Bronzlaşma",
            "Doğal bronzlaşma maskeleri",
            "danisma"});
            this.cbxHizmetler.Location = new System.Drawing.Point(169, 52);
            this.cbxHizmetler.Name = "cbxHizmetler";
            this.cbxHizmetler.Size = new System.Drawing.Size(445, 21);
            this.cbxHizmetler.TabIndex = 14;
            this.cbxHizmetler.Visible = false;
            this.cbxHizmetler.SelectedIndexChanged += new System.EventHandler(this.cbxHizmetler_SelectedIndexChanged);
            // 
            // lbHizmet
            // 
            this.lbHizmet.AutoSize = true;
            this.lbHizmet.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbHizmet.Location = new System.Drawing.Point(3, 49);
            this.lbHizmet.Name = "lbHizmet";
            this.lbHizmet.Size = new System.Drawing.Size(135, 28);
            this.lbHizmet.TabIndex = 13;
            this.lbHizmet.Text = "Hizmetlerimiz :";
            this.lbHizmet.Visible = false;
            // 
            // rbKampanya
            // 
            this.rbKampanya.AutoSize = true;
            this.rbKampanya.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbKampanya.Location = new System.Drawing.Point(495, 3);
            this.rbKampanya.Name = "rbKampanya";
            this.rbKampanya.Size = new System.Drawing.Size(172, 32);
            this.rbKampanya.TabIndex = 15;
            this.rbKampanya.Tag = "70";
            this.rbKampanya.Text = "Kampanyalar için";
            this.rbKampanya.UseVisualStyleBackColor = true;
            this.rbKampanya.CheckedChanged += new System.EventHandler(this.rbKampanya_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.radioButton1.Location = new System.Drawing.Point(247, 3);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(177, 32);
            this.radioButton1.TabIndex = 16;
            this.radioButton1.Tag = "70";
            this.radioButton1.Text = "Hizmetlerimiz için";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // labelfiyatadi
            // 
            this.labelfiyatadi.AutoSize = true;
            this.labelfiyatadi.BackColor = System.Drawing.Color.SeaGreen;
            this.labelfiyatadi.Font = new System.Drawing.Font("Segoe Print", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labelfiyatadi.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelfiyatadi.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.labelfiyatadi.Location = new System.Drawing.Point(4, 226);
            this.labelfiyatadi.Name = "labelfiyatadi";
            this.labelfiyatadi.Size = new System.Drawing.Size(117, 62);
            this.labelfiyatadi.TabIndex = 19;
            this.labelfiyatadi.Text = "fiyat:";
            this.labelfiyatadi.Visible = false;
            // 
            // lbFiyat
            // 
            this.lbFiyat.AutoSize = true;
            this.lbFiyat.BackColor = System.Drawing.Color.SeaGreen;
            this.lbFiyat.Font = new System.Drawing.Font("Segoe Print", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbFiyat.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lbFiyat.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbFiyat.Location = new System.Drawing.Point(145, 226);
            this.lbFiyat.Name = "lbFiyat";
            this.lbFiyat.Size = new System.Drawing.Size(107, 62);
            this.lbFiyat.TabIndex = 20;
            this.lbFiyat.Text = "fiyat";
            this.lbFiyat.Visible = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Enabled = false;
            this.dateTimePicker1.Location = new System.Drawing.Point(151, 103);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(136, 20);
            this.dateTimePicker1.TabIndex = 21;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged_1);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Info;
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txtAd);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtSoyAd);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtTel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Location = new System.Drawing.Point(12, 131);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(293, 205);
            this.panel1.TabIndex = 22;
            this.panel1.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label6.Location = new System.Drawing.Point(17, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(218, 26);
            this.label6.TabIndex = 24;
            this.label6.Text = "Muşterinin Bilgileri";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Info;
            this.panel2.Controls.Add(this.cbxRandevuSaati);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.dateTimePicker1);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.cbxPersonelSecme);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(311, 131);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(293, 205);
            this.panel2.TabIndex = 23;
            // 
            // cbxRandevuSaati
            // 
            this.cbxRandevuSaati.Enabled = false;
            this.cbxRandevuSaati.FormattingEnabled = true;
            this.cbxRandevuSaati.Location = new System.Drawing.Point(151, 164);
            this.cbxRandevuSaati.Name = "cbxRandevuSaati";
            this.cbxRandevuSaati.Size = new System.Drawing.Size(139, 21);
            this.cbxRandevuSaati.TabIndex = 20;
            this.cbxRandevuSaati.SelectedIndexChanged += new System.EventHandler(this.cbxRandevuSaati_SelectedIndexChanged_2);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label7.Location = new System.Drawing.Point(3, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 28);
            this.label7.TabIndex = 26;
            this.label7.Text = "Randevu Tarihi";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label9.Location = new System.Drawing.Point(3, 161);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 28);
            this.label9.TabIndex = 19;
            this.label9.Text = "Randevu Saat";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label5.Location = new System.Drawing.Point(17, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(193, 26);
            this.label5.TabIndex = 25;
            this.label5.Text = "Randevu Bilgileri";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel3.Controls.Add(this.lbHizmetinAdi);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.lbHizmet);
            this.panel3.Controls.Add(this.lbKampanya);
            this.panel3.Controls.Add(this.cbxkampanyalar);
            this.panel3.Controls.Add(this.cbxHizmetler);
            this.panel3.Controls.Add(this.btnRandevuEkle);
            this.panel3.Controls.Add(this.lbFiyat);
            this.panel3.Controls.Add(this.rbKampanya);
            this.panel3.Controls.Add(this.labelfiyatadi);
            this.panel3.Controls.Add(this.radioButton1);
            this.panel3.Location = new System.Drawing.Point(628, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(943, 438);
            this.panel3.TabIndex = 24;
            // 
            // lbHizmetinAdi
            // 
            this.lbHizmetinAdi.AutoSize = true;
            this.lbHizmetinAdi.BackColor = System.Drawing.Color.YellowGreen;
            this.lbHizmetinAdi.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbHizmetinAdi.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbHizmetinAdi.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.lbHizmetinAdi.Location = new System.Drawing.Point(7, 142);
            this.lbHizmetinAdi.Name = "lbHizmetinAdi";
            this.lbHizmetinAdi.Size = new System.Drawing.Size(139, 27);
            this.lbHizmetinAdi.TabIndex = 27;
            this.lbHizmetinAdi.Text = "Hizmetin Adi";
            this.lbHizmetinAdi.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label8.Location = new System.Drawing.Point(3, 2);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(159, 26);
            this.label8.TabIndex = 26;
            this.label8.Text = "Hizmet Seçimi";
            // 
            // btnRandevuEkle
            // 
            this.btnRandevuEkle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRandevuEkle.FlatAppearance.BorderSize = 0;
            this.btnRandevuEkle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRandevuEkle.Font = new System.Drawing.Font("Palatino Linotype", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRandevuEkle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRandevuEkle.Image = global::RandevuSistemi.Properties.Resources.square_plus;
            this.btnRandevuEkle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRandevuEkle.Location = new System.Drawing.Point(606, 367);
            this.btnRandevuEkle.Name = "btnRandevuEkle";
            this.btnRandevuEkle.Size = new System.Drawing.Size(177, 68);
            this.btnRandevuEkle.TabIndex = 18;
            this.btnRandevuEkle.Text = "      Ekle";
            this.btnRandevuEkle.UseVisualStyleBackColor = false;
            this.btnRandevuEkle.Click += new System.EventHandler(this.btnRandevuEkle_Click_1);
            // 
            // menuPanel
            // 
            this.menuPanel.Controls.Add(this.panel4);
            this.menuPanel.Controls.Add(this.panel2);
            this.menuPanel.Controls.Add(this.panel3);
            this.menuPanel.Controls.Add(this.panel1);
            this.menuPanel.Controls.Add(this.rbtnEski);
            this.menuPanel.Controls.Add(this.rbtnYeni);
            this.menuPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuPanel.Location = new System.Drawing.Point(0, 0);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(1806, 913);
            this.menuPanel.TabIndex = 27;
            this.menuPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.menuPanel_Paint);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Info;
            this.panel4.Controls.Add(this.cbxMusteriler);
            this.panel4.Controls.Add(this.label10);
            this.panel4.Controls.Add(this.label11);
            this.panel4.Location = new System.Drawing.Point(9, 134);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(293, 205);
            this.panel4.TabIndex = 25;
            this.panel4.Visible = false;
            // 
            // cbxMusteriler
            // 
            this.cbxMusteriler.FormattingEnabled = true;
            this.cbxMusteriler.Location = new System.Drawing.Point(122, 55);
            this.cbxMusteriler.Name = "cbxMusteriler";
            this.cbxMusteriler.Size = new System.Drawing.Size(139, 21);
            this.cbxMusteriler.TabIndex = 25;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label10.Location = new System.Drawing.Point(16, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(262, 24);
            this.label10.TabIndex = 24;
            this.label10.Text = "Önceden Eklenen Musteriler";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label11.Location = new System.Drawing.Point(5, 55);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 28);
            this.label11.TabIndex = 1;
            this.label11.Text = "Ad";
            // 
            // rbtnEski
            // 
            this.rbtnEski.AutoSize = true;
            this.rbtnEski.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbtnEski.Location = new System.Drawing.Point(300, 24);
            this.rbtnEski.Name = "rbtnEski";
            this.rbtnEski.Size = new System.Drawing.Size(236, 32);
            this.rbtnEski.TabIndex = 19;
            this.rbtnEski.Tag = "70";
            this.rbtnEski.Text = "Önceki Müşterilerden için";
            this.rbtnEski.UseVisualStyleBackColor = true;
            this.rbtnEski.CheckedChanged += new System.EventHandler(this.rbtnEski_CheckedChanged);
            // 
            // rbtnYeni
            // 
            this.rbtnYeni.AutoSize = true;
            this.rbtnYeni.Font = new System.Drawing.Font("Segoe Print", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.rbtnYeni.Location = new System.Drawing.Point(22, 24);
            this.rbtnYeni.Name = "rbtnYeni";
            this.rbtnYeni.Size = new System.Drawing.Size(238, 32);
            this.rbtnYeni.TabIndex = 20;
            this.rbtnYeni.Tag = "70";
            this.rbtnYeni.Text = "Yeni Müşteri Eklemek için";
            this.rbtnYeni.UseVisualStyleBackColor = true;
            this.rbtnYeni.CheckedChanged += new System.EventHandler(this.rbtnYeni_CheckedChanged);
            // 
            // frmRandevu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1806, 913);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuPanel);
            this.Name = "frmRandevu";
            this.Text = "frmRandevu";
            this.Load += new System.EventHandler(this.frmRandevu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.menuPanel.ResumeLayout(false);
            this.menuPanel.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAd;
        private System.Windows.Forms.TextBox txtSoyAd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxPersonelSecme;
        private System.Windows.Forms.Label lbKampanya;
        private System.Windows.Forms.ComboBox cbxkampanyalar;
        private System.Windows.Forms.ComboBox cbxHizmetler;
        private System.Windows.Forms.Label lbHizmet;
        private System.Windows.Forms.RadioButton rbKampanya;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button btnRandevuEkle;
        private System.Windows.Forms.Label labelfiyatadi;
        private System.Windows.Forms.Label lbFiyat;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lbHizmetinAdi;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbxRandevuSaati;
        private System.Windows.Forms.RadioButton rbtnEski;
        private System.Windows.Forms.RadioButton rbtnYeni;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cbxMusteriler;
    }
}