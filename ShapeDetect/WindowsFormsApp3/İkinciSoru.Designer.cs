namespace WindowsFormsApp3
{
    partial class İkinciSoru
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
            this.btrSekilCizme = new System.Windows.Forms.Button();
            this.CmbBoxSekilCizilcek = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btrSekilCizme
            // 
            this.btrSekilCizme.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btrSekilCizme.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btrSekilCizme.Location = new System.Drawing.Point(71, 49);
            this.btrSekilCizme.Name = "btrSekilCizme";
            this.btrSekilCizme.Size = new System.Drawing.Size(212, 50);
            this.btrSekilCizme.TabIndex = 5;
            this.btrSekilCizme.Text = "Şekil Çiz";
            this.btrSekilCizme.UseVisualStyleBackColor = false;
            this.btrSekilCizme.Click += new System.EventHandler(this.btrSekilCizme_Click);
            // 
            // CmbBoxSekilCizilcek
            // 
            this.CmbBoxSekilCizilcek.BackColor = System.Drawing.Color.White;
            this.CmbBoxSekilCizilcek.FormattingEnabled = true;
            this.CmbBoxSekilCizilcek.Items.AddRange(new object[] {
            "Nokta",
            "Dikdörtgen",
            "Çember",
            "Silindir",
            "Küre",
            "Yüzey",
            "Dörtgen",
            "DikdörrtgenPirizma"});
            this.CmbBoxSekilCizilcek.Location = new System.Drawing.Point(44, 22);
            this.CmbBoxSekilCizilcek.Name = "CmbBoxSekilCizilcek";
            this.CmbBoxSekilCizilcek.Size = new System.Drawing.Size(271, 21);
            this.CmbBoxSekilCizilcek.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 113);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 337);
            this.panel2.TabIndex = 6;
            // 
            // İkinciSoru
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btrSekilCizme);
            this.Controls.Add(this.CmbBoxSekilCizilcek);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "İkinciSoru";
            this.Text = "İkinciSoru";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btrSekilCizme;
        private System.Windows.Forms.ComboBox CmbBoxSekilCizilcek;
        private System.Windows.Forms.Panel panel2;
    }
}