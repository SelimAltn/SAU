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
            panel1 = new Panel();
            cmbKalkisSehirler = new ComboBox();
            btnGiris = new Button();
            label3 = new Label();
            label2 = new Label();
            lbBaslik = new Label();
            cmbVarisSehirler = new ComboBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(cmbVarisSehirler);
            panel1.Controls.Add(cmbKalkisSehirler);
            panel1.Controls.Add(btnGiris);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(lbBaslik);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1940, 1100);
            panel1.TabIndex = 0;
            // 
            // cmbKalkisSehirler
            // 
            cmbKalkisSehirler.FormattingEnabled = true;
            cmbKalkisSehirler.Location = new Point(571, 115);
            cmbKalkisSehirler.Name = "cmbKalkisSehirler";
            cmbKalkisSehirler.Size = new Size(269, 23);
            cmbKalkisSehirler.TabIndex = 6;
            // 
            // btnGiris
            // 
            btnGiris.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnGiris.ImageAlign = ContentAlignment.MiddleLeft;
            btnGiris.Location = new Point(592, 323);
            btnGiris.Margin = new Padding(4, 3, 4, 3);
            btnGiris.Name = "btnGiris";
            btnGiris.Size = new Size(248, 48);
            btnGiris.TabIndex = 5;
            btnGiris.Text = "Giriş";
            btnGiris.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label3.Location = new Point(905, 104);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(83, 28);
            label3.TabIndex = 4;
            label3.Text = "Nereye";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(467, 110);
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
            // cmbVarisSehirler
            // 
            cmbVarisSehirler.FormattingEnabled = true;
            cmbVarisSehirler.Location = new Point(1019, 109);
            cmbVarisSehirler.Name = "cmbVarisSehirler";
            cmbVarisSehirler.Size = new Size(269, 23);
            cmbVarisSehirler.TabIndex = 7;
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
    }
}