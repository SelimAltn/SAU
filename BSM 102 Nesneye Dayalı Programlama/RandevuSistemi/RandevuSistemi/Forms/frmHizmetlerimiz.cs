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
    public partial class frmHizmetlerimiz : Form
    {
        public frmHizmetlerimiz()
        {
            InitializeComponent();
        }
        private Random random;
        private int tempIndex;
        public Color SelectThemeColor()
        {

            int index = random.Next(clsTemaRenki.RenkListesi.Count);
            while (tempIndex == index)
            {
                index = random.Next(clsTemaRenki.RenkListesi.Count);
            }
            tempIndex = index;
            string colorHex = clsTemaRenki.RenkListesi[index];
            return ColorTranslator.FromHtml(colorHex);
        }
     

        private void Hizmetlerimiz_Load(object sender, EventArgs e)
        {
            LoadTheme();
            random = new Random();
            Color color = SelectThemeColor();
            Button[] buttons = { button1, button2, button3, button4, button5,
                         button6, button7, button8, button9, button10 };
            foreach (Button btn in buttons)
            {
                btn.BackColor = color;
            }

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

       
        

        private void button1_Click_1(object sender, EventArgs e)
        {
            HizmetFormu hizmet = new HizmetFormu();
            hizmet.CilitBakimi();
            AltFormAcPanelİcinde(hizmet);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            HizmetFormu hizmet = new HizmetFormu();
            hizmet.Makyaj();
            AltFormAcPanelİcinde(hizmet);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            HizmetFormu hizmet = new HizmetFormu();
            hizmet.SacBakimi();
            AltFormAcPanelİcinde(hizmet);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            HizmetFormu hizmet = new HizmetFormu();
            hizmet.Manikur();
            AltFormAcPanelİcinde(hizmet);
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            HizmetFormu hizmet = new HizmetFormu();
            hizmet.Epilisyon();
            AltFormAcPanelİcinde(hizmet);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            HizmetFormu hizmet = new HizmetFormu();
            hizmet.Mesaj();
            AltFormAcPanelİcinde(hizmet);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            HizmetFormu hizmet = new HizmetFormu();
            hizmet.Kirpik();
            AltFormAcPanelİcinde(hizmet);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            HizmetFormu hizmet = new HizmetFormu();
            hizmet.Bronz();
            AltFormAcPanelİcinde(hizmet);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            HizmetFormu hizmet = new HizmetFormu();
            hizmet.Danisma();
            AltFormAcPanelİcinde(hizmet);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmKozmatikUrunlerKategori urun =new frmKozmatikUrunlerKategori();
            AltFormAcPanelİcinde(urun);
        }

   
       
    }
}
