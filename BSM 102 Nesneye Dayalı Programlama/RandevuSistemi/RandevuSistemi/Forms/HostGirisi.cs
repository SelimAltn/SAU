using RandevuSistemi.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandevuSistemi
{
    public partial class HostGirisi : Form
    {
        public HostGirisi()
        {
            InitializeComponent();

        }

        private void HostGirisi_Load(object sender, EventArgs e)
        {
            LoadTheme();
        }
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = clsTemaRenki.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = clsTemaRenki.SecondaryColor;
                }
            }
            btnGiris.ForeColor = clsTemaRenki.SecondaryColor;

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            

        }
        private Form activeForm;
        private void AltFormAcPanelİcinde(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(childForm);
            this.panel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }
        private byte sayac = 1;
        
        private void btnGiris_Click(object sender, EventArgs e)
        {
            frmHostSayfasi host = new frmHostSayfasi();
            if(txtKullanciAdi.Text=="1"&&txtSifre.Text=="2")
            {
                txtKullanciAdi.Text = "";
                txtSifre.Text = "";
                lbBaslik.Text = "HoşGeldiniz";
                AltFormAcPanelİcinde(host);
            }
            else if (sayac<3)
            {
                sayac += 1;
                MessageBox.Show("Kullancı Adı Yada Şifreniz Yalnış \nLütfen Tekrar Deneyeniz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if(sayac==3)
            {
                MessageBox.Show("3 defa Hata Girdiniz için Uygulama Kapatılcak", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
