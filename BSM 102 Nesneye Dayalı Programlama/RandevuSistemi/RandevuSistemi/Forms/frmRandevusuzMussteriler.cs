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
    public partial class frmRandevusuzMussteriler : Form
    {
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

        public frmRandevusuzMussteriler()
        {
            InitializeComponent();
            random = new Random();
            Color color = SelectThemeColor();
            btnKaydet.BackColor = color;
        }

        private void frmRandevusuzMussteriler_Load(object sender, EventArgs e)
        {

        }
      

        private void frmYeniMusteriEkle_Load(object sender, EventArgs e)
        {

        }

      
       

        private void btnKaydet_Click_1(object sender, EventArgs e)
        {
            if (txtMusteriAdi.Text == "" || txtMusteriSoyAdi.Text == "" || txtMusteriTel.Text == "")
            {
                MessageBox.Show("Lutfen istenen Bilgiler Eksiksiz Bir Şekilde Ekleyiniz", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                clsRandevusuzMusteriManger.Instance.LsrandevusuzMusteriler.Add(new clsRandevusuzMusteri(txtMusteriAdi.Text, txtMusteriSoyAdi.Text, txtMusteriTel.Text));
                MessageBox.Show("kaydetildi");
                txtMusteriAdi.Text = "";
                txtMusteriSoyAdi.Text = "";
                txtMusteriTel.Text = "";
            }
        }
    }
}
