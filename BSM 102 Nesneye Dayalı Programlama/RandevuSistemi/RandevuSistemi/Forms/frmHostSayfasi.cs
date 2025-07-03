using RandevuSistemi.Resources;
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
    public partial class frmHostSayfasi : Form
    {
       
        

       
        public frmHostSayfasi()
        {
            InitializeComponent();
            lbHostAdi.Text = "SELİM ALTIN";
            lbHostİd.Text = "g231210558";
           
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void HostSayfasi_Load(object sender, EventArgs e)
        {
           
            
        }

        private void button6_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            clsCalisanlar YeniCalısan = new clsCalisanlar();
            frmYeniPersonelEkle form = new frmYeniPersonelEkle();
            AltFormAcPanelİcinde(form);
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            frmRandevu form = new frmRandevu();
            AltFormAcPanelİcinde(form);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmRandevuİptal form = new frmRandevuİptal();
            AltFormAcPanelİcinde(form);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmRandevuDuzenle form = new frmRandevuDuzenle();
            AltFormAcPanelİcinde(form);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmOnayBeklenenPersoneller form = new frmOnayBeklenenPersoneller();
            AltFormAcPanelİcinde(form);
        }
        private void button8_Click(object sender, EventArgs e)
        {
            frmRandevusuzMussteriler form = new frmRandevusuzMussteriler();
            AltFormAcPanelİcinde(form);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmKayitliMusterilerimiz form = new frmKayitliMusterilerimiz();
            AltFormAcPanelİcinde(form);
        }


        /// --------------------------------------------------
        /// Günlük maliyetleri alır ve bir mesaj kutusunda gösterir. 
        ///----------------------------------------------------------
        private void button6_Click_2(object sender, EventArgs e)
        {
            var gunlukMaliyetler = clsMusteriManager.Instance.GetGunlukMaliyetler();

            // Günlük maliyetleri göstermek için StringBuilder kullan
            StringBuilder bolder = new StringBuilder();
            //Her bir gün ve o günün toplam maliyetini StringBuilder objesine ekler.
            foreach (var maliyet in gunlukMaliyetler)
            {
                // Her bir gün için maliyeti metne ekle
                bolder.AppendLine($"{maliyet.Key.ToShortDateString()}: {maliyet.Value} TL");
            }

            MessageBox.Show(bolder.ToString(), "Günlük Maliyetler", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
