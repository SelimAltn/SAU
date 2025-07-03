namespace RandevuSistemi.Resources
{
    partial class frmRandevuİptal
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
            this.btnRandevuDüzenle = new System.Windows.Forms.Button();
            this.lb = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridView1.Location = new System.Drawing.Point(0, 248);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1790, 626);
            this.dataGridView1.TabIndex = 1;
            // 
            // btnRandevuDüzenle
            // 
            this.btnRandevuDüzenle.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnRandevuDüzenle.FlatAppearance.BorderSize = 0;
            this.btnRandevuDüzenle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRandevuDüzenle.Font = new System.Drawing.Font("Palatino Linotype", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnRandevuDüzenle.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnRandevuDüzenle.Image = global::RandevuSistemi.Properties.Resources.file_edit;
            this.btnRandevuDüzenle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRandevuDüzenle.Location = new System.Drawing.Point(640, 141);
            this.btnRandevuDüzenle.Name = "btnRandevuDüzenle";
            this.btnRandevuDüzenle.Size = new System.Drawing.Size(314, 68);
            this.btnRandevuDüzenle.TabIndex = 27;
            this.btnRandevuDüzenle.Text = "     Randevu İptal Et";
            this.btnRandevuDüzenle.UseVisualStyleBackColor = false;
            this.btnRandevuDüzenle.Click += new System.EventHandler(this.btnRandevuDüzenle_Click);
            // 
            // lb
            // 
            this.lb.AutoSize = true;
            this.lb.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lb.Font = new System.Drawing.Font("MV Boli", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.lb.Location = new System.Drawing.Point(512, 56);
            this.lb.Name = "lb";
            this.lb.Size = new System.Drawing.Size(569, 39);
            this.lb.TabIndex = 28;
            this.lb.Text = "İptal etmek istediniz Randevu seçiniz ";
            // 
            // frmRandevuİptal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1790, 874);
            this.Controls.Add(this.lb);
            this.Controls.Add(this.btnRandevuDüzenle);
            this.Controls.Add(this.dataGridView1);
            this.Name = "frmRandevuİptal";
            this.Text = "frmRandevuİptal";
            this.Load += new System.EventHandler(this.frmRandevuİptal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnRandevuDüzenle;
        private System.Windows.Forms.Label lb;
    }
}