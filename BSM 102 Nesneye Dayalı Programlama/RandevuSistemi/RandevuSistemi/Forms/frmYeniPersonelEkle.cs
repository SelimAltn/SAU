using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace RandevuSistemi.Forms
{

    public partial class frmYeniPersonelEkle : Form
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
        public frmYeniPersonelEkle()
        {
            InitializeComponent();
            random = new Random();
            Color color = SelectThemeColor();
            btnKaydet.BackColor = color;

        }

        private void YeniPersonelEkle_Load(object sender, EventArgs e)
        {
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtCalisanAdi.Text==""||txtCalisanUzmanAlani.Text==""||txtOzGecmis.Text=="") 
            {
                MessageBox.Show("Lutfen istenen Bilgiler Eksiksiz Bir Şekilde Ekleyiniz","Dikkat",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                clsPersonelManager.Instance.LsCalisanlar.Add(new clsCalisanlar(txtCalisanAdi.Text, txtCalisanUzmanAlani.Text, txtOzGecmis.Text, true, true, true, true));
                MessageBox.Show("kaydetildi");
                txtCalisanAdi.Text = "";
                txtCalisanUzmanAlani.Text = "";
                txtOzGecmis.Text = "";
            }
        }
 
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
