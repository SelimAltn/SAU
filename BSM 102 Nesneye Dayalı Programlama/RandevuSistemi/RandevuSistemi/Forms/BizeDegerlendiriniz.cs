using RandevuSistemi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandevuSistemi
{
    public partial class BizeDegerlendiriniz : Form
    {
        public BizeDegerlendiriniz()
        {
            InitializeComponent();
        }

        private void BizeDegerlendiriniz_Load(object sender, EventArgs e)
        {
            // Özel butonların renklerini ayarlar
            btnGonder.BackColor = clsTemaRenki.SecondaryColor;
            btnDuzenle.BackColor = clsTemaRenki.SecondaryColor;
        }
        // 5 yıldız butonuna tıklanma olayı
        private void btnStar5_Click(object sender, EventArgs e)
        {
            // Tüm yıldızları dolu olarak ayarlar ve sonucu gösterir
            btnStar1.Image = Properties.Resources.star__1_1;
            btnStar2.Image = Properties.Resources.star__1_1;
            btnStar3.Image = Properties.Resources.star__1_1;
            btnStar4.Image = Properties.Resources.star__1_1;
            btnStar5.Image = Properties.Resources.star__1_1;
            LBSonuc.Visible = true;
            LBSonuc.Text = "100";
        }

        // 4 yıldız butonuna tıklanma olayı
        private void btnStar4_Click(object sender, EventArgs e)
        {
            // İlk dört yıldızı dolu, son yıldızı boş olarak ayarlar ve sonucu gösterir
            btnStar1.Image = Properties.Resources.star__1_1;
            btnStar2.Image = Properties.Resources.star__1_1;
            btnStar3.Image = Properties.Resources.star__1_1;
            btnStar4.Image = Properties.Resources.star__1_1;
            btnStar5.Image = Properties.Resources.star_2;
            LBSonuc.Visible = true;
            LBSonuc.Text = "80";
        }

        // 3 yıldız butonuna tıklanma olayı
        private void btnStar3_Click(object sender, EventArgs e)
        {
            // İlk üç yıldızı dolu, son iki yıldızı boş olarak ayarlar ve sonucu gösterir
            btnStar1.Image = Properties.Resources.star__1_1;
            btnStar2.Image = Properties.Resources.star__1_1;
            btnStar3.Image = Properties.Resources.star__1_1;
            btnStar4.Image = Properties.Resources.star_2;
            btnStar5.Image = Properties.Resources.star_2;
            LBSonuc.Visible = true;
            LBSonuc.Text = "60";
        }

        // 2 yıldız butonuna tıklanma olayı
        private void btnStar2_Click(object sender, EventArgs e)
        {
            // İlk iki yıldızı dolu, son üç yıldızı boş olarak ayarlar ve sonucu gösterir
            btnStar1.Image = Properties.Resources.star__1_1;
            btnStar2.Image = Properties.Resources.star__1_1;
            btnStar3.Image = Properties.Resources.star_2;
            btnStar4.Image = Properties.Resources.star_2;
            btnStar5.Image = Properties.Resources.star_2;
            LBSonuc.Visible = true;
            LBSonuc.Text = "40";
        }

        // 1 yıldız butonuna tıklanma olayı
        private void btnStar1_Click(object sender, EventArgs e)
        {
            // İlk yıldızı dolu, son dört yıldızı boş olarak ayarlar ve sonucu gösterir
            btnStar1.Image = Properties.Resources.star__1_1;
            btnStar2.Image = Properties.Resources.star_2;
            btnStar3.Image = Properties.Resources.star_2;
            btnStar4.Image = Properties.Resources.star_2;
            btnStar5.Image = Properties.Resources.star_2;
            LBSonuc.Visible = true;
            LBSonuc.Text = "20";
        }

        // Gönder butonuna tıklanma olayı
        private void btnGonder_Click(object sender, EventArgs e)
        {
            // Eğer sonuç geçerli bir puan değilse uyarı gösterir
            if (LBSonuc.Text != "20" && LBSonuc.Text != "40" && LBSonuc.Text != "60" && LBSonuc.Text != "80" && LBSonuc.Text != "100")
            {
                MessageBox.Show("Boş Gonderilmez", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // Gönderme işlemi onayı
                DialogResult cevab = MessageBox.Show("Gondermek Üzerindesiniz", "Dikkat", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (cevab == DialogResult.Yes)
                {
                    // Evet seçildiyse yıldız ve butonları devre dışı bırakır
                    btnStar1.Enabled = false;
                    btnStar2.Enabled = false;
                    btnStar3.Enabled = false;
                    btnStar4.Enabled = false;
                    btnStar5.Enabled = false;
                    btnGonder.Enabled = false;
                }
            }
        }

        // Düzenle butonuna tıklanma olayı
        private void button1_Click(object sender, EventArgs e)
        {
            // Tüm yıldız ve butonları tekrar etkinleştirir
            btnStar1.Enabled = true;
            btnStar2.Enabled = true;
            btnStar3.Enabled = true;
            btnStar4.Enabled = true;
            btnStar5.Enabled = true;
            btnGonder.Enabled = true;
        }
    }
}
