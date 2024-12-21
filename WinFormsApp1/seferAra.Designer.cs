namespace WinFormsApp1
{
    partial class seferAra
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(seferAra));
            panel1 = new Panel();
            label4 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label1 = new Label();
            pictureBox1 = new PictureBox();
            cmbVarisSehirler = new ComboBox();
            cmbKalkisSehirler = new ComboBox();
            btnGiris = new Button();
            label3 = new Label();
            label2 = new Label();
            lbBaslik = new Label();
            groupBox1 = new GroupBox();
            radioButton3 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton1 = new RadioButton();
            dataGridView1 = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(dateTimePicker1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(cmbVarisSehirler);
            panel1.Controls.Add(cmbKalkisSehirler);
            panel1.Controls.Add(btnGiris);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(lbBaslik);
            panel1.Controls.Add(groupBox1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1940, 1100);
            panel1.TabIndex = 0;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label4.Location = new Point(1231, 127);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(141, 28);
            label4.TabIndex = 11;
            label4.Text = "Siyahet Türü";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(960, 129);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 10;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label1.Location = new Point(872, 126);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(79, 28);
            label1.TabIndex = 9;
            label1.Text = "Tarih : ";
            label1.Click += label1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(204, 221, 231);
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(365, 114);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(79, 51);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // cmbVarisSehirler
            // 
            cmbVarisSehirler.FormattingEnabled = true;
            cmbVarisSehirler.Location = new Point(561, 129);
            cmbVarisSehirler.Name = "cmbVarisSehirler";
            cmbVarisSehirler.Size = new Size(195, 23);
            cmbVarisSehirler.TabIndex = 7;
            // 
            // cmbKalkisSehirler
            // 
            cmbKalkisSehirler.FormattingEnabled = true;
            cmbKalkisSehirler.Location = new Point(141, 133);
            cmbKalkisSehirler.Name = "cmbKalkisSehirler";
            cmbKalkisSehirler.Size = new Size(195, 23);
            cmbKalkisSehirler.TabIndex = 6;
            // 
            // btnGiris
            // 
            btnGiris.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnGiris.ImageAlign = ContentAlignment.MiddleLeft;
            btnGiris.Location = new Point(703, 235);
            btnGiris.Margin = new Padding(4, 3, 4, 3);
            btnGiris.Name = "btnGiris";
            btnGiris.Size = new Size(248, 48);
            btnGiris.TabIndex = 5;
            btnGiris.Text = "Uygun Seferleir Ara";
            btnGiris.UseVisualStyleBackColor = true;
            btnGiris.Click += btnGiris_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(456, 126);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(98, 28);
            label3.TabIndex = 4;
            label3.Text = "Nereye : ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(37, 127);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(97, 28);
            label2.TabIndex = 3;
            label2.Text = "Nerden :";
            label2.Click += label2_Click;
            // 
            // lbBaslik
            // 
            lbBaslik.AutoSize = true;
            lbBaslik.Font = new Font("Palatino Linotype", 18F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lbBaslik.Location = new Point(559, 38);
            lbBaslik.Margin = new Padding(4, 0, 4, 0);
            lbBaslik.Name = "lbBaslik";
            lbBaslik.Size = new Size(449, 32);
            lbBaslik.TabIndex = 0;
            lbBaslik.Text = "Aramak istediniz sefer bilgileri gieeriniz";
            // 
            // groupBox1
            // 
            groupBox1.BackColor = Color.FromArgb(204, 221, 231);
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton1);
            groupBox1.Location = new Point(-18, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(2057, 401);
            groupBox1.TabIndex = 13;
            groupBox1.TabStop = false;
            // 
            // radioButton3
            // 
            radioButton3.AutoSize = true;
            radioButton3.Image = (Image)resources.GetObject("radioButton3.Image");
            radioButton3.Location = new Point(1413, 172);
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
            radioButton2.Location = new Point(1412, 131);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(46, 32);
            radioButton2.TabIndex = 5;
            radioButton2.TabStop = true;
            radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            radioButton1.AutoSize = true;
            radioButton1.Image = (Image)resources.GetObject("radioButton1.Image");
            radioButton1.Location = new Point(1412, 91);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(46, 32);
            radioButton1.TabIndex = 4;
            radioButton1.TabStop = true;
            radioButton1.UseVisualStyleBackColor = true;
            radioButton1.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(3, 402);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(715, 698);
            dataGridView1.TabIndex = 14;
            dataGridView1.Visible = false;
            // 
            // seferAra
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1940, 1100);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "seferAra";
            Text = "HostGirisi";
            Load += seferAra_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbBaslik;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGiris;
        private ComboBox cmbKalkisSehirler;
        private ComboBox cmbVarisSehirler;
        private PictureBox pictureBox1;
        private Label label1;
        private DateTimePicker dateTimePicker1;
        private Label label4;
        private GroupBox groupBox1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private RadioButton radioButton1;
        private DataGridView dataGridView1;
    }
}