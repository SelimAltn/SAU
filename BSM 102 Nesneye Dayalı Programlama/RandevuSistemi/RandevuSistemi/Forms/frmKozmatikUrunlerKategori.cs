using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandevuSistemi.Forms
{
    public partial class frmKozmatikUrunlerKategori : Form
    {
        public frmKozmatikUrunlerKategori()
        {
            InitializeComponent();
        }
        private Form activeForm;
        private void AltFormAcPanelİcinde(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close(); // Mevcut formu kapat
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelMain.Controls.Add(childForm);
            this.panelMain.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmUrunler frmUrunler = new frmUrunler();
            AltFormAcPanelİcinde(frmUrunler);
            frmUrunler.ciltBakimi();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmUrunler frmUrunler = new frmUrunler();
            AltFormAcPanelİcinde(frmUrunler);
            frmUrunler.Makyaj();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmUrunler frmUrunler = new frmUrunler();
            AltFormAcPanelİcinde(frmUrunler);
            frmUrunler.SacBakim();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            frmUrunler frmUrunler = new frmUrunler();
            AltFormAcPanelİcinde(frmUrunler);
            frmUrunler.Agiz();
        }
    }
}
