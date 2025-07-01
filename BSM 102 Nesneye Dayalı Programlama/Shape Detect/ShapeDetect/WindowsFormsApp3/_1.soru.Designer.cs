namespace WindowsFormsApp3
{
    partial class BirinciSoru
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
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.CarpısmaDenetimi = new System.Windows.Forms.Button();
            this.lbSecilenBirinciCisim = new System.Windows.Forms.Label();
            this.lbSecilenİkinciCisim = new System.Windows.Forms.Label();
            this.lbBirinciCisimYazdirma = new System.Windows.Forms.Label();
            this.lbİkinciCisimYazdirma = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtBirinciXkordinati = new System.Windows.Forms.TextBox();
            this.lbİkinciDerinlik = new System.Windows.Forms.Label();
            this.lbBirinciDerinlik = new System.Windows.Forms.Label();
            this.txtİkinciDerinlik = new System.Windows.Forms.TextBox();
            this.txtBirinciDerinlik = new System.Windows.Forms.TextBox();
            this.lbİkinciYaricabi = new System.Windows.Forms.Label();
            this.lbBirinciYariCab = new System.Windows.Forms.Label();
            this.txtİkinciYaricabi = new System.Windows.Forms.TextBox();
            this.txtBirinciYariCab = new System.Windows.Forms.TextBox();
            this.lbİkinciYukseklik = new System.Windows.Forms.Label();
            this.lbBirinciYukseklik = new System.Windows.Forms.Label();
            this.txtİkinciYukseklik = new System.Windows.Forms.TextBox();
            this.txtBirinciYukseklik = new System.Windows.Forms.TextBox();
            this.lbİkinciGenislik = new System.Windows.Forms.Label();
            this.lbBirinciGenişlik = new System.Windows.Forms.Label();
            this.lbİkinciZkordinati = new System.Windows.Forms.Label();
            this.lbBirinciZkordinati = new System.Windows.Forms.Label();
            this.lbİkinciYkordinati = new System.Windows.Forms.Label();
            this.lbBirinciYkordinati = new System.Windows.Forms.Label();
            this.lbİkinciXkordinati = new System.Windows.Forms.Label();
            this.lbBirinciXkordinati = new System.Windows.Forms.Label();
            this.txtİkinciGenislik = new System.Windows.Forms.TextBox();
            this.txtBirinciGenişlik = new System.Windows.Forms.TextBox();
            this.txtBirinciZkordinati = new System.Windows.Forms.TextBox();
            this.txtİkinciZkordinati = new System.Windows.Forms.TextBox();
            this.txtİkinciYkordinati = new System.Windows.Forms.TextBox();
            this.txtBirinciYkordinati = new System.Windows.Forms.TextBox();
            this.txtİkinciXkordinati = new System.Windows.Forms.TextBox();
            this.butDegerleriSifirla = new System.Windows.Forms.Button();
            this.lbSonuc = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "a)Nokta-Dörtgen",
            "b)Nokta-Çember",
            "c)Dikdörtgen-Dikdörtgen",
            "d)Dikdörtgen-Çember",
            "e)Çember-Çember",
            "f)Nokta, Küre",
            "g) Nokta, dikdörtgen prizma",
            "h) Nokta, Silindir",
            "i) Silindir, silindir",
            "j) Küre, küre",
            "k) Küre silindir",
            "l) Yüzey, küre",
            "m) Yüzey, dikdörtgenPrizma",
            "n) Yüzey silindir",
            "o) Küre, dikdörtgen",
            "p) Dikdörtgen prizma, dikdörtgen prizma"});
            this.comboBox2.Location = new System.Drawing.Point(559, 3);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(271, 21);
            this.comboBox2.TabIndex = 1;
            this.comboBox2.TabStop = false;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // CarpısmaDenetimi
            // 
            this.CarpısmaDenetimi.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CarpısmaDenetimi.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CarpısmaDenetimi.Location = new System.Drawing.Point(578, 94);
            this.CarpısmaDenetimi.Name = "CarpısmaDenetimi";
            this.CarpısmaDenetimi.Size = new System.Drawing.Size(212, 50);
            this.CarpısmaDenetimi.TabIndex = 2;
            this.CarpısmaDenetimi.Text = "Çarpışma Denetimi ";
            this.CarpısmaDenetimi.UseVisualStyleBackColor = false;
            this.CarpısmaDenetimi.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbSecilenBirinciCisim
            // 
            this.lbSecilenBirinciCisim.AutoSize = true;
            this.lbSecilenBirinciCisim.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbSecilenBirinciCisim.Location = new System.Drawing.Point(516, 239);
            this.lbSecilenBirinciCisim.Name = "lbSecilenBirinciCisim";
            this.lbSecilenBirinciCisim.Size = new System.Drawing.Size(66, 23);
            this.lbSecilenBirinciCisim.TabIndex = 5;
            this.lbSecilenBirinciCisim.Text = "1.Cisim :";
            this.lbSecilenBirinciCisim.Visible = false;
            this.lbSecilenBirinciCisim.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // lbSecilenİkinciCisim
            // 
            this.lbSecilenİkinciCisim.AutoSize = true;
            this.lbSecilenİkinciCisim.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbSecilenİkinciCisim.Location = new System.Drawing.Point(659, 239);
            this.lbSecilenİkinciCisim.Name = "lbSecilenİkinciCisim";
            this.lbSecilenİkinciCisim.Size = new System.Drawing.Size(66, 23);
            this.lbSecilenİkinciCisim.TabIndex = 6;
            this.lbSecilenİkinciCisim.Text = "2.Cisim :";
            this.lbSecilenİkinciCisim.Visible = false;
            // 
            // lbBirinciCisimYazdirma
            // 
            this.lbBirinciCisimYazdirma.AutoSize = true;
            this.lbBirinciCisimYazdirma.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbBirinciCisimYazdirma.Location = new System.Drawing.Point(588, 239);
            this.lbBirinciCisimYazdirma.Name = "lbBirinciCisimYazdirma";
            this.lbBirinciCisimYazdirma.Size = new System.Drawing.Size(0, 23);
            this.lbBirinciCisimYazdirma.TabIndex = 7;
            this.lbBirinciCisimYazdirma.Visible = false;
            // 
            // lbİkinciCisimYazdirma
            // 
            this.lbİkinciCisimYazdirma.AutoSize = true;
            this.lbİkinciCisimYazdirma.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbİkinciCisimYazdirma.Location = new System.Drawing.Point(744, 239);
            this.lbİkinciCisimYazdirma.Name = "lbİkinciCisimYazdirma";
            this.lbİkinciCisimYazdirma.Size = new System.Drawing.Size(0, 23);
            this.lbİkinciCisimYazdirma.TabIndex = 8;
            this.lbİkinciCisimYazdirma.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtBirinciXkordinati);
            this.groupBox1.Controls.Add(this.lbİkinciDerinlik);
            this.groupBox1.Controls.Add(this.lbBirinciDerinlik);
            this.groupBox1.Controls.Add(this.txtİkinciDerinlik);
            this.groupBox1.Controls.Add(this.txtBirinciDerinlik);
            this.groupBox1.Controls.Add(this.lbİkinciYaricabi);
            this.groupBox1.Controls.Add(this.lbBirinciYariCab);
            this.groupBox1.Controls.Add(this.txtİkinciYaricabi);
            this.groupBox1.Controls.Add(this.txtBirinciYariCab);
            this.groupBox1.Controls.Add(this.lbİkinciYukseklik);
            this.groupBox1.Controls.Add(this.lbBirinciYukseklik);
            this.groupBox1.Controls.Add(this.txtİkinciYukseklik);
            this.groupBox1.Controls.Add(this.txtBirinciYukseklik);
            this.groupBox1.Controls.Add(this.lbİkinciGenislik);
            this.groupBox1.Controls.Add(this.lbBirinciGenişlik);
            this.groupBox1.Controls.Add(this.lbİkinciZkordinati);
            this.groupBox1.Controls.Add(this.lbBirinciZkordinati);
            this.groupBox1.Controls.Add(this.lbİkinciYkordinati);
            this.groupBox1.Controls.Add(this.lbBirinciYkordinati);
            this.groupBox1.Controls.Add(this.lbİkinciXkordinati);
            this.groupBox1.Controls.Add(this.lbBirinciXkordinati);
            this.groupBox1.Controls.Add(this.txtİkinciGenislik);
            this.groupBox1.Controls.Add(this.txtBirinciGenişlik);
            this.groupBox1.Controls.Add(this.txtBirinciZkordinati);
            this.groupBox1.Controls.Add(this.txtİkinciZkordinati);
            this.groupBox1.Controls.Add(this.txtİkinciYkordinati);
            this.groupBox1.Controls.Add(this.txtBirinciYkordinati);
            this.groupBox1.Controls.Add(this.txtİkinciXkordinati);
            this.groupBox1.Location = new System.Drawing.Point(503, 265);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(339, 207);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // txtBirinciXkordinati
            // 
            this.txtBirinciXkordinati.Location = new System.Drawing.Point(72, 19);
            this.txtBirinciXkordinati.Name = "txtBirinciXkordinati";
            this.txtBirinciXkordinati.Size = new System.Drawing.Size(75, 20);
            this.txtBirinciXkordinati.TabIndex = 0;
            this.txtBirinciXkordinati.Visible = false;
            // 
            // lbİkinciDerinlik
            // 
            this.lbİkinciDerinlik.AutoSize = true;
            this.lbİkinciDerinlik.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbİkinciDerinlik.Location = new System.Drawing.Point(151, 181);
            this.lbİkinciDerinlik.Name = "lbİkinciDerinlik";
            this.lbİkinciDerinlik.Size = new System.Drawing.Size(67, 23);
            this.lbİkinciDerinlik.TabIndex = 36;
            this.lbİkinciDerinlik.Text = "Derinlik:";
            this.lbİkinciDerinlik.Visible = false;
            // 
            // lbBirinciDerinlik
            // 
            this.lbBirinciDerinlik.AutoSize = true;
            this.lbBirinciDerinlik.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbBirinciDerinlik.Location = new System.Drawing.Point(0, 178);
            this.lbBirinciDerinlik.Name = "lbBirinciDerinlik";
            this.lbBirinciDerinlik.Size = new System.Drawing.Size(67, 23);
            this.lbBirinciDerinlik.TabIndex = 35;
            this.lbBirinciDerinlik.Text = "Derinlik:";
            this.lbBirinciDerinlik.Visible = false;
            // 
            // txtİkinciDerinlik
            // 
            this.txtİkinciDerinlik.Location = new System.Drawing.Point(230, 181);
            this.txtİkinciDerinlik.Name = "txtİkinciDerinlik";
            this.txtİkinciDerinlik.Size = new System.Drawing.Size(75, 20);
            this.txtİkinciDerinlik.TabIndex = 13;
            this.txtİkinciDerinlik.Visible = false;
            // 
            // txtBirinciDerinlik
            // 
            this.txtBirinciDerinlik.Location = new System.Drawing.Point(73, 181);
            this.txtBirinciDerinlik.Name = "txtBirinciDerinlik";
            this.txtBirinciDerinlik.Size = new System.Drawing.Size(75, 20);
            this.txtBirinciDerinlik.TabIndex = 6;
            this.txtBirinciDerinlik.Visible = false;
            this.txtBirinciDerinlik.TextChanged += new System.EventHandler(this.txtBirinciDerinlik_TextChanged);
            // 
            // lbİkinciYaricabi
            // 
            this.lbİkinciYaricabi.AutoSize = true;
            this.lbİkinciYaricabi.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbİkinciYaricabi.Location = new System.Drawing.Point(150, 144);
            this.lbİkinciYaricabi.Name = "lbİkinciYaricabi";
            this.lbİkinciYaricabi.Size = new System.Drawing.Size(72, 23);
            this.lbİkinciYaricabi.TabIndex = 32;
            this.lbİkinciYaricabi.Text = "Yarı Çab:";
            this.lbİkinciYaricabi.Visible = false;
            // 
            // lbBirinciYariCab
            // 
            this.lbBirinciYariCab.AutoSize = true;
            this.lbBirinciYariCab.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbBirinciYariCab.Location = new System.Drawing.Point(-1, 141);
            this.lbBirinciYariCab.Name = "lbBirinciYariCab";
            this.lbBirinciYariCab.Size = new System.Drawing.Size(72, 23);
            this.lbBirinciYariCab.TabIndex = 31;
            this.lbBirinciYariCab.Text = "Yarı Çab:";
            this.lbBirinciYariCab.Visible = false;
            // 
            // txtİkinciYaricabi
            // 
            this.txtİkinciYaricabi.Location = new System.Drawing.Point(229, 144);
            this.txtİkinciYaricabi.Name = "txtİkinciYaricabi";
            this.txtİkinciYaricabi.Size = new System.Drawing.Size(75, 20);
            this.txtİkinciYaricabi.TabIndex = 12;
            this.txtİkinciYaricabi.Visible = false;
            // 
            // txtBirinciYariCab
            // 
            this.txtBirinciYariCab.Location = new System.Drawing.Point(72, 144);
            this.txtBirinciYariCab.Name = "txtBirinciYariCab";
            this.txtBirinciYariCab.Size = new System.Drawing.Size(75, 20);
            this.txtBirinciYariCab.TabIndex = 5;
            this.txtBirinciYariCab.Visible = false;
            // 
            // lbİkinciYukseklik
            // 
            this.lbİkinciYukseklik.AutoSize = true;
            this.lbİkinciYukseklik.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbİkinciYukseklik.Location = new System.Drawing.Point(143, 120);
            this.lbİkinciYukseklik.Name = "lbİkinciYukseklik";
            this.lbİkinciYukseklik.Size = new System.Drawing.Size(80, 23);
            this.lbİkinciYukseklik.TabIndex = 28;
            this.lbİkinciYukseklik.Text = "Yükseklik :";
            this.lbİkinciYukseklik.Visible = false;
            // 
            // lbBirinciYukseklik
            // 
            this.lbBirinciYukseklik.AutoSize = true;
            this.lbBirinciYukseklik.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbBirinciYukseklik.Location = new System.Drawing.Point(-1, 117);
            this.lbBirinciYukseklik.Name = "lbBirinciYukseklik";
            this.lbBirinciYukseklik.Size = new System.Drawing.Size(80, 23);
            this.lbBirinciYukseklik.TabIndex = 27;
            this.lbBirinciYukseklik.Text = "Yükseklik :";
            this.lbBirinciYukseklik.Visible = false;
            // 
            // txtİkinciYukseklik
            // 
            this.txtİkinciYukseklik.Location = new System.Drawing.Point(229, 120);
            this.txtİkinciYukseklik.Name = "txtİkinciYukseklik";
            this.txtİkinciYukseklik.Size = new System.Drawing.Size(75, 20);
            this.txtİkinciYukseklik.TabIndex = 11;
            this.txtİkinciYukseklik.Visible = false;
            // 
            // txtBirinciYukseklik
            // 
            this.txtBirinciYukseklik.Location = new System.Drawing.Point(72, 120);
            this.txtBirinciYukseklik.Name = "txtBirinciYukseklik";
            this.txtBirinciYukseklik.Size = new System.Drawing.Size(75, 20);
            this.txtBirinciYukseklik.TabIndex = 4;
            this.txtBirinciYukseklik.Visible = false;
            // 
            // lbİkinciGenislik
            // 
            this.lbİkinciGenislik.AutoSize = true;
            this.lbİkinciGenislik.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbİkinciGenislik.Location = new System.Drawing.Point(153, 94);
            this.lbİkinciGenislik.Name = "lbİkinciGenislik";
            this.lbİkinciGenislik.Size = new System.Drawing.Size(70, 23);
            this.lbİkinciGenislik.TabIndex = 24;
            this.lbİkinciGenislik.Text = "Genişlik :";
            this.lbİkinciGenislik.Visible = false;
            // 
            // lbBirinciGenişlik
            // 
            this.lbBirinciGenişlik.AutoSize = true;
            this.lbBirinciGenişlik.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbBirinciGenişlik.Location = new System.Drawing.Point(9, 94);
            this.lbBirinciGenişlik.Name = "lbBirinciGenişlik";
            this.lbBirinciGenişlik.Size = new System.Drawing.Size(70, 23);
            this.lbBirinciGenişlik.TabIndex = 23;
            this.lbBirinciGenişlik.Text = "Genişlik :";
            this.lbBirinciGenişlik.Visible = false;
            // 
            // lbİkinciZkordinati
            // 
            this.lbİkinciZkordinati.AutoSize = true;
            this.lbİkinciZkordinati.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbİkinciZkordinati.Location = new System.Drawing.Point(194, 71);
            this.lbİkinciZkordinati.Name = "lbİkinciZkordinati";
            this.lbİkinciZkordinati.Size = new System.Drawing.Size(24, 23);
            this.lbİkinciZkordinati.TabIndex = 22;
            this.lbİkinciZkordinati.Text = "Z:";
            this.lbİkinciZkordinati.Visible = false;
            // 
            // lbBirinciZkordinati
            // 
            this.lbBirinciZkordinati.AutoSize = true;
            this.lbBirinciZkordinati.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbBirinciZkordinati.Location = new System.Drawing.Point(37, 71);
            this.lbBirinciZkordinati.Name = "lbBirinciZkordinati";
            this.lbBirinciZkordinati.Size = new System.Drawing.Size(29, 23);
            this.lbBirinciZkordinati.TabIndex = 21;
            this.lbBirinciZkordinati.Text = "Z :";
            this.lbBirinciZkordinati.Visible = false;
            // 
            // lbİkinciYkordinati
            // 
            this.lbİkinciYkordinati.AutoSize = true;
            this.lbİkinciYkordinati.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbİkinciYkordinati.Location = new System.Drawing.Point(194, 45);
            this.lbİkinciYkordinati.Name = "lbİkinciYkordinati";
            this.lbİkinciYkordinati.Size = new System.Drawing.Size(28, 23);
            this.lbİkinciYkordinati.TabIndex = 20;
            this.lbİkinciYkordinati.Text = "Y :";
            this.lbİkinciYkordinati.Visible = false;
            // 
            // lbBirinciYkordinati
            // 
            this.lbBirinciYkordinati.AutoSize = true;
            this.lbBirinciYkordinati.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbBirinciYkordinati.Location = new System.Drawing.Point(37, 45);
            this.lbBirinciYkordinati.Name = "lbBirinciYkordinati";
            this.lbBirinciYkordinati.Size = new System.Drawing.Size(28, 23);
            this.lbBirinciYkordinati.TabIndex = 19;
            this.lbBirinciYkordinati.Text = "Y :";
            this.lbBirinciYkordinati.Visible = false;
            // 
            // lbİkinciXkordinati
            // 
            this.lbİkinciXkordinati.AutoSize = true;
            this.lbİkinciXkordinati.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbİkinciXkordinati.Location = new System.Drawing.Point(194, 19);
            this.lbİkinciXkordinati.Name = "lbİkinciXkordinati";
            this.lbİkinciXkordinati.Size = new System.Drawing.Size(29, 23);
            this.lbİkinciXkordinati.TabIndex = 18;
            this.lbİkinciXkordinati.Text = "X :";
            this.lbİkinciXkordinati.Visible = false;
            // 
            // lbBirinciXkordinati
            // 
            this.lbBirinciXkordinati.AutoSize = true;
            this.lbBirinciXkordinati.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbBirinciXkordinati.Location = new System.Drawing.Point(37, 19);
            this.lbBirinciXkordinati.Name = "lbBirinciXkordinati";
            this.lbBirinciXkordinati.Size = new System.Drawing.Size(29, 23);
            this.lbBirinciXkordinati.TabIndex = 17;
            this.lbBirinciXkordinati.Text = "X :";
            this.lbBirinciXkordinati.Visible = false;
            // 
            // txtİkinciGenislik
            // 
            this.txtİkinciGenislik.Location = new System.Drawing.Point(229, 97);
            this.txtİkinciGenislik.Name = "txtİkinciGenislik";
            this.txtİkinciGenislik.Size = new System.Drawing.Size(75, 20);
            this.txtİkinciGenislik.TabIndex = 10;
            this.txtİkinciGenislik.Visible = false;
            // 
            // txtBirinciGenişlik
            // 
            this.txtBirinciGenişlik.Location = new System.Drawing.Point(72, 97);
            this.txtBirinciGenişlik.Name = "txtBirinciGenişlik";
            this.txtBirinciGenişlik.Size = new System.Drawing.Size(75, 20);
            this.txtBirinciGenişlik.TabIndex = 3;
            this.txtBirinciGenişlik.Visible = false;
            // 
            // txtBirinciZkordinati
            // 
            this.txtBirinciZkordinati.Location = new System.Drawing.Point(72, 71);
            this.txtBirinciZkordinati.Name = "txtBirinciZkordinati";
            this.txtBirinciZkordinati.Size = new System.Drawing.Size(75, 20);
            this.txtBirinciZkordinati.TabIndex = 2;
            this.txtBirinciZkordinati.Visible = false;
            // 
            // txtİkinciZkordinati
            // 
            this.txtİkinciZkordinati.Location = new System.Drawing.Point(229, 71);
            this.txtİkinciZkordinati.Name = "txtİkinciZkordinati";
            this.txtİkinciZkordinati.Size = new System.Drawing.Size(75, 20);
            this.txtİkinciZkordinati.TabIndex = 9;
            this.txtİkinciZkordinati.Visible = false;
            // 
            // txtİkinciYkordinati
            // 
            this.txtİkinciYkordinati.Location = new System.Drawing.Point(229, 45);
            this.txtİkinciYkordinati.Name = "txtİkinciYkordinati";
            this.txtİkinciYkordinati.Size = new System.Drawing.Size(75, 20);
            this.txtİkinciYkordinati.TabIndex = 8;
            this.txtİkinciYkordinati.Visible = false;
            // 
            // txtBirinciYkordinati
            // 
            this.txtBirinciYkordinati.Location = new System.Drawing.Point(72, 45);
            this.txtBirinciYkordinati.Name = "txtBirinciYkordinati";
            this.txtBirinciYkordinati.Size = new System.Drawing.Size(75, 20);
            this.txtBirinciYkordinati.TabIndex = 1;
            this.txtBirinciYkordinati.Visible = false;
            // 
            // txtİkinciXkordinati
            // 
            this.txtİkinciXkordinati.Location = new System.Drawing.Point(229, 19);
            this.txtİkinciXkordinati.Name = "txtİkinciXkordinati";
            this.txtİkinciXkordinati.Size = new System.Drawing.Size(75, 20);
            this.txtİkinciXkordinati.TabIndex = 7;
            this.txtİkinciXkordinati.Visible = false;
            // 
            // butDegerleriSifirla
            // 
            this.butDegerleriSifirla.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.butDegerleriSifirla.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.butDegerleriSifirla.Location = new System.Drawing.Point(605, 473);
            this.butDegerleriSifirla.Name = "butDegerleriSifirla";
            this.butDegerleriSifirla.Size = new System.Drawing.Size(121, 26);
            this.butDegerleriSifirla.TabIndex = 11;
            this.butDegerleriSifirla.TabStop = false;
            this.butDegerleriSifirla.Text = "Değerleri Sıfırla";
            this.butDegerleriSifirla.UseVisualStyleBackColor = false;
            this.butDegerleriSifirla.Click += new System.EventHandler(this.butDegerleriSifirla_Click);
            // 
            // lbSonuc
            // 
            this.lbSonuc.AutoSize = true;
            this.lbSonuc.Font = new System.Drawing.Font("Segoe Print", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lbSonuc.Location = new System.Drawing.Point(529, 55);
            this.lbSonuc.Name = "lbSonuc";
            this.lbSonuc.Size = new System.Drawing.Size(53, 23);
            this.lbSonuc.TabIndex = 12;
            this.lbSonuc.Text = "Sonuç:";
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(497, 499);
            this.panel2.TabIndex = 13;
            // 
            // BirinciSoru
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 499);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lbSonuc);
            this.Controls.Add(this.butDegerleriSifirla);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lbİkinciCisimYazdirma);
            this.Controls.Add(this.lbBirinciCisimYazdirma);
            this.Controls.Add(this.lbSecilenİkinciCisim);
            this.Controls.Add(this.lbSecilenBirinciCisim);
            this.Controls.Add(this.CarpısmaDenetimi);
            this.Controls.Add(this.comboBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BirinciSoru";
            this.Text = "BirinciSoru";
            this.Load += new System.EventHandler(this.BirinciSoru_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button CarpısmaDenetimi;
        private System.Windows.Forms.Label lbSecilenBirinciCisim;
        private System.Windows.Forms.Label lbSecilenİkinciCisim;
        private System.Windows.Forms.Label lbBirinciCisimYazdirma;
        private System.Windows.Forms.Label lbİkinciCisimYazdirma;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBirinciZkordinati;
        private System.Windows.Forms.TextBox txtİkinciZkordinati;
        private System.Windows.Forms.TextBox txtİkinciYkordinati;
        private System.Windows.Forms.TextBox txtBirinciYkordinati;
        private System.Windows.Forms.TextBox txtİkinciXkordinati;
        private System.Windows.Forms.Label lbİkinciXkordinati;
        private System.Windows.Forms.Label lbBirinciXkordinati;
        private System.Windows.Forms.Label lbBirinciYariCab;
        private System.Windows.Forms.TextBox txtİkinciYaricabi;
        private System.Windows.Forms.TextBox txtBirinciYariCab;
        private System.Windows.Forms.Label lbİkinciYukseklik;
        private System.Windows.Forms.Label lbBirinciYukseklik;
        private System.Windows.Forms.TextBox txtİkinciYukseklik;
        private System.Windows.Forms.TextBox txtBirinciYukseklik;
        private System.Windows.Forms.Label lbİkinciGenislik;
        private System.Windows.Forms.Label lbBirinciGenişlik;
        private System.Windows.Forms.Label lbİkinciZkordinati;
        private System.Windows.Forms.Label lbBirinciZkordinati;
        private System.Windows.Forms.Label lbİkinciYkordinati;
        private System.Windows.Forms.Label lbBirinciYkordinati;
        private System.Windows.Forms.TextBox txtİkinciGenislik;
        private System.Windows.Forms.TextBox txtBirinciGenişlik;
        private System.Windows.Forms.Label lbİkinciYaricabi;
        private System.Windows.Forms.Label lbİkinciDerinlik;
        private System.Windows.Forms.Label lbBirinciDerinlik;
        private System.Windows.Forms.TextBox txtİkinciDerinlik;
        private System.Windows.Forms.TextBox txtBirinciDerinlik;
        private System.Windows.Forms.TextBox txtBirinciXkordinati;
        private System.Windows.Forms.Button butDegerleriSifirla;
        private System.Windows.Forms.Label lbSonuc;
        private System.Windows.Forms.Panel panel2;
    }
}