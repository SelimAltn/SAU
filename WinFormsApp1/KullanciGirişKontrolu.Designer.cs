namespace WinFormsApp1
{
    partial class KullanciGirişKontrolu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KullanciGirişKontrolu));
            groupBox1 = new GroupBox();
            btnGiris = new Button();
            lbBaslik = new Label();
            label3 = new Label();
            txtKullanciAdi = new MaskedTextBox();
            label2 = new Label();
            txtSifre = new MaskedTextBox();
            panelMenu = new Panel();
            btnSeferAra = new Button();
            LBBulunduSayfaAdi = new Label();
            btnSeferlerimGoruntule = new Button();
            panelLogo = new Panel();
            lbKullanciAdi = new Label();
            btnBiletAl = new Button();
            btnSeferinizDegerlendiriniz = new Button();
            btnBiletiptalet = new Button();
            btnBiletDegistir = new Button();
            panelUst = new Panel();
            btnBackSatisİcin = new Button();
            btnBackhizmet = new Button();
            panel1 = new Panel();
            groupBox3 = new GroupBox();
            button4 = new Button();
            richTextBox1 = new RichTextBox();
            label10 = new Label();
            groupBox2 = new GroupBox();
            btnBilet_degistir = new Button();
            btnBiletİptali = new Button();
            txtUygunSeferId = new TextBox();
            button3 = new Button();
            button2 = new Button();
            label8 = new Label();
            gboxSefer = new GroupBox();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            label4 = new Label();
            radioButton1 = new RadioButton();
            dateTimePicker1 = new DateTimePicker();
            button1 = new Button();
            label1 = new Label();
            label5 = new Label();
            pictureBox1 = new PictureBox();
            label6 = new Label();
            cmbVarisSehirler = new ComboBox();
            label7 = new Label();
            cmbKalkisSehirler = new ComboBox();
            dataGridView1 = new DataGridView();
            groupBox1.SuspendLayout();
            panelMenu.SuspendLayout();
            panelLogo.SuspendLayout();
            panelUst.SuspendLayout();
            panel1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            gboxSefer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(204, 221, 231);
            groupBox1.Controls.Add(btnGiris);
            groupBox1.Controls.Add(lbBaslik);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(txtKullanciAdi);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(txtSifre);
            groupBox1.Location = new Point(0, 48);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(875, 386);
            groupBox1.TabIndex = 14;
            groupBox1.TabStop = false;
            // 
            // btnGiris
            // 
            btnGiris.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnGiris.ImageAlign = ContentAlignment.MiddleLeft;
            btnGiris.Location = new Point(477, 199);
            btnGiris.Margin = new Padding(4, 3, 4, 3);
            btnGiris.Name = "btnGiris";
            btnGiris.Size = new Size(248, 48);
            btnGiris.TabIndex = 5;
            btnGiris.Text = "Giriş";
            btnGiris.UseVisualStyleBackColor = true;
            btnGiris.Click += btnGiris_Click;
            // 
            // lbBaslik
            // 
            lbBaslik.AutoSize = true;
            lbBaslik.Font = new Font("Palatino Linotype", 18F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lbBaslik.Location = new Point(268, 33);
            lbBaslik.Margin = new Padding(4, 0, 4, 0);
            lbBaslik.Name = "lbBaslik";
            lbBaslik.Size = new Size(298, 32);
            lbBaslik.TabIndex = 0;
            lbBaslik.Text = "Hesap Bilgilerinizi Giriniz";
            lbBaslik.Click += lbBaslik_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(193, 236);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(59, 28);
            label3.TabIndex = 4;
            label3.Text = "Şifre";
            // 
            // txtKullanciAdi
            // 
            txtKullanciAdi.Location = new Point(287, 186);
            txtKullanciAdi.Margin = new Padding(4, 3, 4, 3);
            txtKullanciAdi.Name = "txtKullanciAdi";
            txtKullanciAdi.Size = new Size(146, 23);
            txtKullanciAdi.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(128, 185);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(138, 28);
            label2.TabIndex = 3;
            label2.Text = "Kullancı Adı";
            label2.Click += label2_Click;
            // 
            // txtSifre
            // 
            txtSifre.Location = new Point(287, 242);
            txtSifre.Margin = new Padding(4, 3, 4, 3);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(146, 23);
            txtSifre.TabIndex = 2;
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(39, 49, 65);
            panelMenu.Controls.Add(btnSeferAra);
            panelMenu.Controls.Add(LBBulunduSayfaAdi);
            panelMenu.Controls.Add(btnSeferlerimGoruntule);
            panelMenu.Controls.Add(panelLogo);
            panelMenu.Controls.Add(btnBiletAl);
            panelMenu.Controls.Add(btnSeferinizDegerlendiriniz);
            panelMenu.Controls.Add(btnBiletiptalet);
            panelMenu.Controls.Add(btnBiletDegistir);
            panelMenu.Dock = DockStyle.Right;
            panelMenu.Location = new Point(1684, 48);
            panelMenu.Margin = new Padding(4, 3, 4, 3);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(256, 1052);
            panelMenu.TabIndex = 15;
            panelMenu.Visible = false;
            // 
            // btnSeferAra
            // 
            btnSeferAra.FlatAppearance.BorderSize = 0;
            btnSeferAra.FlatStyle = FlatStyle.Flat;
            btnSeferAra.Font = new Font("Book Antiqua", 15.75F);
            btnSeferAra.ForeColor = SystemColors.ButtonFace;
            btnSeferAra.ImageAlign = ContentAlignment.MiddleLeft;
            btnSeferAra.Location = new Point(0, 48);
            btnSeferAra.Margin = new Padding(4, 3, 4, 3);
            btnSeferAra.Name = "btnSeferAra";
            btnSeferAra.Padding = new Padding(14, 0, 0, 0);
            btnSeferAra.Size = new Size(233, 70);
            btnSeferAra.TabIndex = 7;
            btnSeferAra.Text = "Sefer Ara";
            btnSeferAra.UseVisualStyleBackColor = true;
            btnSeferAra.Click += btnSeferAra_Click;
            // 
            // LBBulunduSayfaAdi
            // 
            LBBulunduSayfaAdi.AutoSize = true;
            LBBulunduSayfaAdi.Font = new Font("Segoe Print", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            LBBulunduSayfaAdi.ForeColor = SystemColors.ButtonFace;
            LBBulunduSayfaAdi.Location = new Point(70, 576);
            LBBulunduSayfaAdi.Margin = new Padding(4, 0, 4, 0);
            LBBulunduSayfaAdi.Name = "LBBulunduSayfaAdi";
            LBBulunduSayfaAdi.Size = new Size(0, 37);
            LBBulunduSayfaAdi.TabIndex = 2;
            // 
            // btnSeferlerimGoruntule
            // 
            btnSeferlerimGoruntule.FlatAppearance.BorderSize = 0;
            btnSeferlerimGoruntule.FlatStyle = FlatStyle.Flat;
            btnSeferlerimGoruntule.Font = new Font("Book Antiqua", 15.75F);
            btnSeferlerimGoruntule.ForeColor = SystemColors.ButtonFace;
            btnSeferlerimGoruntule.ImageAlign = ContentAlignment.MiddleLeft;
            btnSeferlerimGoruntule.Location = new Point(0, 328);
            btnSeferlerimGoruntule.Margin = new Padding(4, 3, 4, 3);
            btnSeferlerimGoruntule.Name = "btnSeferlerimGoruntule";
            btnSeferlerimGoruntule.Padding = new Padding(14, 0, 0, 0);
            btnSeferlerimGoruntule.Size = new Size(233, 70);
            btnSeferlerimGoruntule.TabIndex = 6;
            btnSeferlerimGoruntule.Text = "Seferlerim";
            btnSeferlerimGoruntule.UseVisualStyleBackColor = true;
            btnSeferlerimGoruntule.Click += btnSeferlerimGoruntule_Click;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = Color.FromArgb(39, 49, 65);
            panelLogo.Controls.Add(lbKullanciAdi);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Font = new Font("Viner Hand ITC", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            panelLogo.Location = new Point(0, 0);
            panelLogo.Margin = new Padding(4, 3, 4, 3);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(256, 48);
            panelLogo.TabIndex = 1;
            // 
            // lbKullanciAdi
            // 
            lbKullanciAdi.AutoSize = true;
            lbKullanciAdi.Font = new Font("Segoe Print", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lbKullanciAdi.ForeColor = SystemColors.ButtonFace;
            lbKullanciAdi.Location = new Point(-5, -5);
            lbKullanciAdi.Margin = new Padding(4, 0, 4, 0);
            lbKullanciAdi.Name = "lbKullanciAdi";
            lbKullanciAdi.Size = new Size(126, 37);
            lbKullanciAdi.TabIndex = 3;
            lbKullanciAdi.Text = "Hoş geldin";
            // 
            // btnBiletAl
            // 
            btnBiletAl.FlatAppearance.BorderSize = 0;
            btnBiletAl.FlatStyle = FlatStyle.Flat;
            btnBiletAl.Font = new Font("Book Antiqua", 15.75F);
            btnBiletAl.ForeColor = SystemColors.ButtonFace;
            btnBiletAl.ImageAlign = ContentAlignment.MiddleLeft;
            btnBiletAl.Location = new Point(3, 118);
            btnBiletAl.Margin = new Padding(4, 3, 4, 3);
            btnBiletAl.Name = "btnBiletAl";
            btnBiletAl.Padding = new Padding(14, 0, 0, 0);
            btnBiletAl.Size = new Size(233, 70);
            btnBiletAl.TabIndex = 1;
            btnBiletAl.Text = "Bilet Al";
            btnBiletAl.UseVisualStyleBackColor = true;
            btnBiletAl.Click += btnBiletAl_Click;
            // 
            // btnSeferinizDegerlendiriniz
            // 
            btnSeferinizDegerlendiriniz.FlatAppearance.BorderSize = 0;
            btnSeferinizDegerlendiriniz.FlatStyle = FlatStyle.Flat;
            btnSeferinizDegerlendiriniz.Font = new Font("Book Antiqua", 15.75F);
            btnSeferinizDegerlendiriniz.ForeColor = SystemColors.ButtonFace;
            btnSeferinizDegerlendiriniz.ImageAlign = ContentAlignment.MiddleLeft;
            btnSeferinizDegerlendiriniz.Location = new Point(0, 398);
            btnSeferinizDegerlendiriniz.Margin = new Padding(4, 3, 4, 3);
            btnSeferinizDegerlendiriniz.Name = "btnSeferinizDegerlendiriniz";
            btnSeferinizDegerlendiriniz.Padding = new Padding(14, 0, 0, 0);
            btnSeferinizDegerlendiriniz.Size = new Size(233, 70);
            btnSeferinizDegerlendiriniz.TabIndex = 5;
            btnSeferinizDegerlendiriniz.Text = "Seferiniz Değerlendiriniz";
            btnSeferinizDegerlendiriniz.UseVisualStyleBackColor = true;
            btnSeferinizDegerlendiriniz.Click += btnSeferinizDegerlendiriniz_Click;
            // 
            // btnBiletiptalet
            // 
            btnBiletiptalet.FlatAppearance.BorderSize = 0;
            btnBiletiptalet.FlatStyle = FlatStyle.Flat;
            btnBiletiptalet.Font = new Font("Book Antiqua", 15.75F);
            btnBiletiptalet.ForeColor = SystemColors.ButtonFace;
            btnBiletiptalet.ImageAlign = ContentAlignment.MiddleLeft;
            btnBiletiptalet.Location = new Point(0, 188);
            btnBiletiptalet.Margin = new Padding(4, 3, 4, 3);
            btnBiletiptalet.Name = "btnBiletiptalet";
            btnBiletiptalet.Padding = new Padding(14, 0, 0, 0);
            btnBiletiptalet.Size = new Size(233, 70);
            btnBiletiptalet.TabIndex = 2;
            btnBiletiptalet.Text = "Bilet iptal et";
            btnBiletiptalet.UseVisualStyleBackColor = true;
            btnBiletiptalet.Click += btnBiletiptalet_Click;
            // 
            // btnBiletDegistir
            // 
            btnBiletDegistir.FlatAppearance.BorderSize = 0;
            btnBiletDegistir.FlatStyle = FlatStyle.Flat;
            btnBiletDegistir.Font = new Font("Book Antiqua", 15.75F);
            btnBiletDegistir.ForeColor = SystemColors.ButtonFace;
            btnBiletDegistir.ImageAlign = ContentAlignment.MiddleLeft;
            btnBiletDegistir.Location = new Point(0, 258);
            btnBiletDegistir.Margin = new Padding(4, 3, 4, 3);
            btnBiletDegistir.Name = "btnBiletDegistir";
            btnBiletDegistir.Padding = new Padding(14, 0, 0, 0);
            btnBiletDegistir.Size = new Size(233, 70);
            btnBiletDegistir.TabIndex = 4;
            btnBiletDegistir.Text = "Bilet Değiştir";
            btnBiletDegistir.UseVisualStyleBackColor = true;
            btnBiletDegistir.Click += btnBiletDegistir_Click;
            // 
            // panelUst
            // 
            panelUst.BackColor = Color.FromArgb(39, 49, 65);
            panelUst.Controls.Add(btnBackSatisİcin);
            panelUst.Controls.Add(btnBackhizmet);
            panelUst.Dock = DockStyle.Top;
            panelUst.Location = new Point(0, 0);
            panelUst.Margin = new Padding(4, 3, 4, 3);
            panelUst.Name = "panelUst";
            panelUst.Size = new Size(1940, 48);
            panelUst.TabIndex = 16;
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
            // panel1
            // 
            panel1.Controls.Add(groupBox3);
            panel1.Controls.Add(groupBox2);
            panel1.Controls.Add(panelMenu);
            panel1.Controls.Add(gboxSefer);
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(groupBox1);
            panel1.Controls.Add(panelUst);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1940, 1100);
            panel1.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(button4);
            groupBox3.Controls.Add(richTextBox1);
            groupBox3.Controls.Add(label10);
            groupBox3.Location = new Point(813, 772);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(543, 276);
            groupBox3.TabIndex = 23;
            groupBox3.TabStop = false;
            groupBox3.Visible = false;
            // 
            // button4
            // 
            button4.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button4.ImageAlign = ContentAlignment.MiddleLeft;
            button4.Location = new Point(9, 87);
            button4.Margin = new Padding(4, 3, 4, 3);
            button4.Name = "button4";
            button4.Size = new Size(248, 48);
            button4.TabIndex = 22;
            button4.Text = "Gönder";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(264, 19);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(206, 125);
            richTextBox1.TabIndex = 23;
            richTextBox1.Text = "";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label10.Location = new Point(7, 19);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(234, 28);
            label10.TabIndex = 22;
            label10.Text = "Şikayetinizi ekleyeniz";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(btnBilet_degistir);
            groupBox2.Controls.Add(btnBiletİptali);
            groupBox2.Controls.Add(txtUygunSeferId);
            groupBox2.Controls.Add(button3);
            groupBox2.Controls.Add(button2);
            groupBox2.Controls.Add(label8);
            groupBox2.Location = new Point(724, 458);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(691, 131);
            groupBox2.TabIndex = 22;
            groupBox2.TabStop = false;
            groupBox2.Visible = false;
            // 
            // btnBilet_degistir
            // 
            btnBilet_degistir.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnBilet_degistir.ImageAlign = ContentAlignment.MiddleLeft;
            btnBilet_degistir.Location = new Point(341, 39);
            btnBilet_degistir.Margin = new Padding(4, 3, 4, 3);
            btnBilet_degistir.Name = "btnBilet_degistir";
            btnBilet_degistir.Size = new Size(248, 48);
            btnBilet_degistir.TabIndex = 21;
            btnBilet_degistir.Text = "Bilet değiştir";
            btnBilet_degistir.UseVisualStyleBackColor = true;
            btnBilet_degistir.Visible = false;
            btnBilet_degistir.Click += btnBilet_degistir_Click;
            // 
            // btnBiletİptali
            // 
            btnBiletİptali.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnBiletİptali.ImageAlign = ContentAlignment.MiddleLeft;
            btnBiletİptali.Location = new Point(341, 40);
            btnBiletİptali.Margin = new Padding(4, 3, 4, 3);
            btnBiletİptali.Name = "btnBiletİptali";
            btnBiletİptali.Size = new Size(248, 48);
            btnBiletİptali.TabIndex = 20;
            btnBiletİptali.Text = "Bilet iptalet";
            btnBiletİptali.UseVisualStyleBackColor = true;
            btnBiletİptali.Visible = false;
            btnBiletİptali.Click += btnBiletİptali_Click;
            // 
            // txtUygunSeferId
            // 
            txtUygunSeferId.Location = new Point(189, 50);
            txtUygunSeferId.Name = "txtUygunSeferId";
            txtUygunSeferId.Size = new Size(100, 23);
            txtUygunSeferId.TabIndex = 19;
            txtUygunSeferId.KeyPress += txtUygunSeferId_KeyPress_1;
            // 
            // button3
            // 
            button3.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button3.ImageAlign = ContentAlignment.MiddleLeft;
            button3.Location = new Point(341, 36);
            button3.Margin = new Padding(4, 3, 4, 3);
            button3.Name = "button3";
            button3.Size = new Size(248, 48);
            button3.TabIndex = 18;
            button3.Text = "Ödeme yap";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(339, 40);
            button2.Margin = new Padding(4, 3, 4, 3);
            button2.Name = "button2";
            button2.Size = new Size(248, 48);
            button2.TabIndex = 17;
            button2.Text = "Revasyon yap";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label8.Location = new Point(28, 49);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(110, 28);
            label8.TabIndex = 15;
            label8.Text = "seferin ID";
            // 
            // gboxSefer
            // 
            gboxSefer.BackColor = Color.FromArgb(204, 221, 231);
            gboxSefer.Controls.Add(radioButton3);
            gboxSefer.Controls.Add(radioButton2);
            gboxSefer.Controls.Add(label4);
            gboxSefer.Controls.Add(radioButton1);
            gboxSefer.Controls.Add(dateTimePicker1);
            gboxSefer.Controls.Add(button1);
            gboxSefer.Controls.Add(label1);
            gboxSefer.Controls.Add(label5);
            gboxSefer.Controls.Add(pictureBox1);
            gboxSefer.Controls.Add(label6);
            gboxSefer.Controls.Add(cmbVarisSehirler);
            gboxSefer.Controls.Add(label7);
            gboxSefer.Controls.Add(cmbKalkisSehirler);
            gboxSefer.Location = new Point(0, 48);
            gboxSefer.Name = "gboxSefer";
            gboxSefer.Size = new Size(1888, 404);
            gboxSefer.TabIndex = 17;
            gboxSefer.TabStop = false;
            gboxSefer.Visible = false;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Image = (Image)resources.GetObject("radioButton3.Image");
            radioButton3.Location = new Point(1385, 140);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(46, 32);
            radioButton3.TabIndex = 6;
            radioButton3.TabStop = true;
            radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            radioButton2.AutoSize = true;
            radioButton2.Image = (Image)resources.GetObject("radioButton2.Image");
            radioButton2.Location = new Point(1384, 99);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(46, 32);
            radioButton2.TabIndex = 5;
            radioButton2.TabStop = true;
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label4.Location = new Point(1228, 99);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(141, 28);
            label4.TabIndex = 11;
            label4.Text = "Siyahet Türü";
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Image = (Image)resources.GetObject("radioButton1.Image");
            radioButton1.Location = new Point(1384, 59);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(46, 32);
            radioButton1.TabIndex = 4;
            radioButton1.TabStop = true;
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(977, 102);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 10;
            // 
            // button1
            // 
            button1.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(698, 199);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(248, 48);
            button1.TabIndex = 5;
            button1.Text = "Uygun Seferleir Ara";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(889, 99);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(79, 28);
            label1.TabIndex = 9;
            label1.Text = "Tarih : ";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Palatino Linotype", 18F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label5.Location = new Point(596, 9);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(449, 32);
            label5.TabIndex = 0;
            label5.Text = "Aramak istediniz sefer bilgileri gieeriniz";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(204, 221, 231);
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(371, 84);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(79, 51);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label6.Location = new Point(43, 100);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(97, 28);
            label6.TabIndex = 3;
            label6.Text = "Nerden :";
            // 
            // cmbVarisSehirler
            // 
            cmbVarisSehirler.FormattingEnabled = true;
            cmbVarisSehirler.Location = new Point(567, 102);
            cmbVarisSehirler.Name = "cmbVarisSehirler";
            cmbVarisSehirler.Size = new Size(195, 23);
            cmbVarisSehirler.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label7.Location = new Point(462, 99);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(98, 28);
            label7.TabIndex = 4;
            label7.Text = "Nereye : ";
            // 
            // cmbKalkisSehirler
            // 
            cmbKalkisSehirler.FormattingEnabled = true;
            cmbKalkisSehirler.Location = new Point(147, 106);
            cmbKalkisSehirler.Name = "cmbKalkisSehirler";
            cmbKalkisSehirler.Size = new Size(195, 23);
            cmbKalkisSehirler.TabIndex = 6;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(3, 446);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(715, 698);
            dataGridView1.TabIndex = 21;
            dataGridView1.Visible = false;
            // 
            // KullanciGirişKontrolu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1940, 1100);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "KullanciGirişKontrolu";
            Text = "HostGirisi";
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panelMenu.ResumeLayout(false);
            panelMenu.PerformLayout();
            panelLogo.ResumeLayout(false);
            panelLogo.PerformLayout();
            panelUst.ResumeLayout(false);
            panel1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            gboxSefer.ResumeLayout(false);
            gboxSefer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox groupBox1;
        private Button btnGiris;
        private Label lbBaslik;
        private Label label3;
        private MaskedTextBox txtKullanciAdi;
        private Label label2;
        private MaskedTextBox txtSifre;
        private Panel panelMenu;
        private Button btnSeferAra;
        private Label LBBulunduSayfaAdi;
        private Button btnSeferlerimGoruntule;
        private Panel panelLogo;
        private Label lbKullanciAdi;
        private Button btnBiletAl;
        private Button btnSeferinizDegerlendiriniz;
        private Button btnBiletiptalet;
        private Button btnBiletDegistir;
        private Panel panelUst;
        private Button btnBackSatisİcin;
        private Button btnBackhizmet;
        private Panel panel1;
        private GroupBox gboxSefer;
        private RadioButton radioButton3;
        private RadioButton radioButton2;
        private Label label4;
        private RadioButton radioButton1;
        private DateTimePicker dateTimePicker1;
        private Button button1;
        private Label label1;
        private Label label5;
        private PictureBox pictureBox1;
        private Label label6;
        private ComboBox cmbVarisSehirler;
        private Label label7;
        private ComboBox cmbKalkisSehirler;
        private GroupBox groupBox2;
        private Button button2;
        private Label label8;
        private DataGridView dataGridView1;
        private Button button3;
        private TextBox txtUygunSeferId;
        private Button btnBiletİptali;
        private Button btnBilet_degistir;
        private GroupBox groupBox3;
        private RichTextBox richTextBox1;
        private Label label10;
        private Button button4;
    }
}
