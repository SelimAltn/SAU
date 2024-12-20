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
            panel1 = new Panel();
            btnGiris = new Button();
            label3 = new Label();
            label2 = new Label();
            txtSifre = new MaskedTextBox();
            txtKullanciAdi = new MaskedTextBox();
            lbBaslik = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnGiris);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtSifre);
            panel1.Controls.Add(txtKullanciAdi);
            panel1.Controls.Add(lbBaslik);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(2144, 1139);
            panel1.TabIndex = 0;
            // 
            // btnGiris
            // 
            btnGiris.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnGiris.ImageAlign = ContentAlignment.MiddleLeft;
            btnGiris.Location = new Point(978, 352);
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
            label3.Location = new Point(694, 389);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(59, 28);
            label3.TabIndex = 4;
            label3.Text = "Şifre";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Palatino Linotype", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label2.Location = new Point(629, 338);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(128, 28);
            label2.TabIndex = 3;
            label2.Text = "Kullancı ID";
            label2.Click += label2_Click;
            // 
            // txtSifre
            // 
            txtSifre.Location = new Point(788, 395);
            txtSifre.Margin = new Padding(4, 3, 4, 3);
            txtSifre.Name = "txtSifre";
            txtSifre.Size = new Size(146, 23);
            txtSifre.TabIndex = 2;
            // 
            // txtKullanciAdi
            // 
            txtKullanciAdi.Location = new Point(788, 339);
            txtKullanciAdi.Margin = new Padding(4, 3, 4, 3);
            txtKullanciAdi.Name = "txtKullanciAdi";
            txtKullanciAdi.Size = new Size(146, 23);
            txtKullanciAdi.TabIndex = 1;
            // 
            // lbBaslik
            // 
            lbBaslik.AutoSize = true;
            lbBaslik.Font = new Font("Palatino Linotype", 18F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lbBaslik.Location = new Point(706, 74);
            lbBaslik.Margin = new Padding(4, 0, 4, 0);
            lbBaslik.Name = "lbBaslik";
            lbBaslik.Size = new Size(298, 32);
            lbBaslik.TabIndex = 0;
            lbBaslik.Text = "Hesap Bilgilerinizi Giriniz";
            lbBaslik.Click += lbBaslik_Click;
            // 
            // KullanciGirişKontrolu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(2144, 1139);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "KullanciGirişKontrolu";
            Text = "HostGirisi";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MaskedTextBox txtSifre;
        private System.Windows.Forms.MaskedTextBox txtKullanciAdi;
        private System.Windows.Forms.Label lbBaslik;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGiris;
    }
}
