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
    public partial class frmCalisanlar2 : Form
    {

        public frmCalisanlar2()
        {
            InitializeComponent();   
   

        }




        bool kontroledici =false;
        private void Calısanlar2_Load(object sender, EventArgs e)
        {
            if (!kontroledici) 
            {
                clsPersonelManager.Instance.LsCalisanlar.Add(melis);
                clsPersonelManager.Instance.LsCalisanlar.Add(Zeynep);
                kontroledici = true;

            }
           
            YedinciCalisanBilgileri();
            SekizinciCalisanBilgileri();



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
            //1. duğmeyi basarsa calısanlar1 formuna yonlendiricek 
            frmCalisanlar1 form = new frmCalisanlar1();
            AltFormAcPanelİcinde(form);
        }
        clsCalisanlar melis = new clsCalisanlar();
        clsCalisanlar Zeynep = new clsCalisanlar();

        private void YedinciCalisanBilgileri()
        {
            melis.Adi = "Melis Yılmaz";
            melis.UzmanAlani = "Cilt Analizi ve Kozmetik Ürünler Uzmanı";
            melis.OzGecmis = "Melis Yılmaz\r, Cilt analizi ve kozmetik ürünler\n konularında uzmanlaşmış bir güzellik uzmanıdır.\n Müşterilerinin cilt tipine uygun ürünler ve tedaviler\n önererek en iyi sonuçları elde etmelerine yardımcı olmaktadır.\n";
            lbOzGecmis1.Text = melis.OzGecmis;
            melis.likeSayisi = 1267;
            lbCalısanAdi1.Text = melis.Adi;
            lbUzmanAlani1.Text = melis.UzmanAlani;
            lbLikeSayisi1.Text = melis.likeSayisi.ToString();
            pictureBox1.Image = Properties.Resources.Firefly_Güzellik_Merkezinde_3d_çalışan_60783;
            melis.BirinciRandevu = true;
            melis.İkiinciRandevu = true;
            melis.UcuncuRandevu = true;
            melis.DorduncuRandevu = true;
        }
        private void SekizinciCalisanBilgileri()
        {
            Zeynep.Adi = "Zeynep Yıldırım";
            Zeynep.uzmanAlani = "Saç Bakımı ve Stilistlik";
            Zeynep.OzGecmis = " Zeynep Yıldırım,\r saç bakımı ve stilistlik konularında\n uzmanlaşmış deneyimli bir güzellik uzmanıdır.\n " +
                "Saç modelleri ve trendleri konusunda geniş bir bilgiye sahiptir.\nGüler yüzlü ve samimi kişiliği ile müşterileri\n tarafından sevilen bir çalışandır. ";
            Zeynep.likeSayisi = 4654;
            lbOzGecmis2.Text = Zeynep.OzGecmis;
            lbCalısanAdi2.Text = Zeynep.Adi;
            lbUzmanAlani2.Text = Zeynep.UzmanAlani;
            lbLikeSayisi2.Text = Zeynep.likeSayisi.ToString();
            pictureBox2.Image = Properties.Resources.Firefly_Güzellik_Merkezinde_3d_çalışan_51676;
            Zeynep.BirinciRandevu = true;
            Zeynep.İkiinciRandevu = true;
            Zeynep.UcuncuRandevu = true;
            Zeynep.DorduncuRandevu = true;
        }
        ///------------------------------------------------------------
        /// Like Duğme İşlevi : 
        ///------------------------------------------------------------

        void LikeDugmesi(clsCalisanlar personel, Button btnLike, Label lbLikeSayisi)
        {
            // Like sayısını artırır veya azaltır ve butonun görselini değiştirir
            if (personel.likeSayisi % 2 == 0)
            {
                personel.likeSayisi++;
                btnLike.Image = Properties.Resources.heart__2_1;


            }
            else
            {

                personel.likeSayisi--;
                btnLike.Image = Properties.Resources.heart1;

            }
            lbLikeSayisi.Text = personel.likeSayisi.ToString(); // Like sayısını günceller
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnLike1_Click(object sender, EventArgs e)
        {
            LikeDugmesi(melis, btnLike1, lbLikeSayisi1);
        }

        private void btnLike2_Click(object sender, EventArgs e)
        {
            LikeDugmesi(Zeynep, btnLike2, lbLikeSayisi2);

        }
    }
}
