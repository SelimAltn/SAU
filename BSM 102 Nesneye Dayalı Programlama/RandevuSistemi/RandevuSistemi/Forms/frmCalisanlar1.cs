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
    public partial class frmCalisanlar1 : Form
    {

          ///------------------------------------------------------------
         ///  Çalışan nesneleri tanımlanması:
        ///-------------------------------------------------------------
        clsCalisanlar birinci  = new clsCalisanlar();
        clsCalisanlar ikinci   = new clsCalisanlar();
        clsCalisanlar ucuncu   = new clsCalisanlar();
        clsCalisanlar dorduncu = new clsCalisanlar();
        clsCalisanlar besinci  = new clsCalisanlar();
        clsCalisanlar altinci  = new clsCalisanlar();

        public frmCalisanlar1()
        {
            InitializeComponent();
        }

        private void Calisanlarimiz_Load(object sender, EventArgs e)
        {
             ///------------------------------------------------------------
            ///  Çalışanlar clsPersonelManger class aracıyla Listeye Ekleme:
           ///-------------------------------------------------------------

            if (clsPersonelManager.Instance.LsCalisanlar.Count == 0)  // Eğer çalışanlar listesi boşsa, çalışanları ekler
            {
                clsPersonelManager.Instance.LsCalisanlar.Add(birinci);
                clsPersonelManager.Instance.LsCalisanlar.Add(ikinci);
                clsPersonelManager.Instance.LsCalisanlar.Add(ucuncu);
                clsPersonelManager.Instance.LsCalisanlar.Add(dorduncu);
                clsPersonelManager.Instance.LsCalisanlar.Add(besinci);
                clsPersonelManager.Instance.LsCalisanlar.Add(altinci);
             //   clsPersonelManager.Instance.CalisanlarEklendi = true; // Çalışanlar eklendikten sonra bayrağı true yap
            }
            // Her çalışanın bilgilerini yükler
            birinciCalisanBilgileri();
            İkinciCalisanBilgileri();
            UcuncuCalisanBilgileri();
            DurduncuCalisanBilgileri();
            BesinciCalisanBilgileri();
            AlltinciCalisanBilgileri();
        }

          ///------------------------------------------------------------
         ///  Panel içerisinde bir alt form açma
        ///------------------------------------------------------------

        private Form AktifForm;
        private void AltFormAcPanelİcinde(Form childForm)
        {
            if (AktifForm != null)
                AktifForm.Close(); // Önceki aktif formu kapatır
            AktifForm = childForm;
            childForm.TopLevel = false; // Alt form ana formun alt formu olarak ayarlanır
            childForm.FormBorderStyle = FormBorderStyle.None; // Alt formun kenarlığı kaldırılır
            childForm.Dock = DockStyle.Fill; // Alt form paneli dolduracak şekilde yerleştirilir
            this.panel1.Controls.Add(childForm);
            this.panel1.Tag = childForm;
            childForm.BringToFront(); // Alt formu öne getirir
            childForm.Show(); // Alt formu gösterir
        }




          ///------------------------------------------------------------
         /// Çalışanlar Ekleme : 
        ///------------------------------------------------------------


        
        private void birinciCalisanBilgileri ()
        {
           
            birinci.Adi = "Aylin Demir";
            birinci.uzmanAlani = "Cilt bakımı uzmanı";
            birinci.OzGecmis = "Aylin Demir,\rGüzellik merkezlerinde uzun yıllardır çalışan deneyimli bir güzellik uzmanıdır.\n" +
                "Kozmetik ve güzellik alanında eğitim aldıktan sonra \nkariyerine başlayan Aylin, birçok farklı güzellik salonunda\n çalışmış ve geniş bir müşteri kitlesi kazanmıştır.\n" +
                "Profesyonel hizmet anlayışı ve müşteri memnuniyetine verdiği \nönem ile tanınan Aylin, " +
                "güzellik merkezindeki işinde her zaman en\n iyi sonuçları elde etmek için çaba göstermektedir. ";
            birinci.likeSayisi = 5968;
            lbOzGecmis1.Text = birinci.OzGecmis;
            lbCalısanAdi1.Text = birinci.Adi;
            lbUzmanAlani1.Text = birinci.UzmanAlani;
            lbLikeSayisi1.Text = birinci.likeSayisi.ToString();
            pictureBox1.Image = Properties.Resources.Firefly_Güzellik_Merkezi_3d_çalışan_Örtülü_kadın_82700;






        }
        
        private void İkinciCalisanBilgileri()
        {
            
            
            
            ikinci.Adi = "Ceren Aktaş";
            ikinci.UzmanAlani = "Güzellik Bakımı ve Cilt Terapisi";
            ikinci.OzGecmis = "Ceren Aktaş,\r güzellik bakımı ve cilt terapisi \nkonularında uzmanlaşmış bir güzellik uzmanıdır.\n Cilt sağlığına önem veren ve müşterilerinin\n cilt problemlerini çözmeye yardımcı olan bir profesyoneldir.\n";
            lbOzGecmis2.Text = ikinci.OzGecmis;
            ikinci.likeSayisi = 3684;

            lbCalısanAdi2.Text = ikinci.Adi;
            lbUzmanAlani2.Text = ikinci.UzmanAlani;
            lbLikeSayisi2.Text = ikinci.likeSayisi.ToString();
            pictureBox2.Image = Properties.Resources.Firefly_Kuaför_3d_çalışan_kapalı_kadın_13759;

        }
        
        private void UcuncuCalisanBilgileri()
        {
           ucuncu.Adi = "Büşra Kaya";
           ucuncu.uzmanAlani = "Manikür ve Pedikür";
           ucuncu.OzGecmis = "  Büşra Kaya,\r manikür ve pedikür konularında uzmanlaşmış bir güzellik uzmanıdır.\n Eller ve ayaklar için bakım ve estetik hizmetleri konusunda deneyimlidir. ";
            lbOzGecmis3.Text = ucuncu.OzGecmis;
            ucuncu.likeSayisi = 2906;
            lbCalısanAdi3.Text = ucuncu.Adi;
            lbUzmanAlani3.Text = ucuncu.UzmanAlani;
            lbLikeSayisi3.Text = ucuncu.likeSayisi.ToString();


            pictureBox3.Image = Properties.Resources.Firefly_Güzellik_Merkezinde_3d_çalışan_83758;

        }
        
        private void DurduncuCalisanBilgileri()
        {
            
            dorduncu.Adi = "Aslıhan Koç";
            dorduncu.uzmanAlani = "Kaş Tasarımı ve Kalıcı Makyaj";
            dorduncu.OzGecmis = "  Aslıhan Koç\r, kaş tasarımı ve kalıcı makyaj konularında \nuzmanlaşmış bir güzellik uzmanıdır.\n Yüz hatlarına uygun kaş tasarımları \nve kalıcı makyaj uygulamaları konusunda deneyimlidir.";
            dorduncu.likeSayisi = 1962;
            lbOzGecmis4.Text = dorduncu.OzGecmis;
            lbCalısanAdi4.Text = dorduncu.Adi;
            lbUzmanAlani4.Text = dorduncu.UzmanAlani;
            lbLikeSayisi4.Text = dorduncu.likeSayisi.ToString();


            pictureBox4.Image = Properties.Resources.Firefly_Güzellik_Merkezi_3D_Örtülü_kadın_çalışan_89141;
        }
       
        private void BesinciCalisanBilgileri()
        {
           
            besinci.Adi = "Elif Turan";
            besinci.UzmanAlani = "Epilasyon ve Cilt Bakımı Uzmanı";
            besinci.OzGecmis = "Elif Turan,\r epilasyon ve cilt bakımı \nkonularında uzmanlaşmış bir güzellik uzmanıdır.\n Cilt sağlığı ve güzelliği konularında müşterilerine\n en iyi hizmeti sunmak için çalışmaktadır.\n";
            besinci.likeSayisi = 2936;
            lbOzGecmis5.Text = besinci.OzGecmis;
            lbCalısanAdi5.Text = besinci.Adi;
            lbUzmanAlani5.Text = besinci.UzmanAlani;
            lbLikeSayisi5.Text = besinci.likeSayisi.ToString();


            pictureBox5.Image = Properties.Resources.Firefly_Güzellik_Merkezinde_3d_çalışan_53318;
        }
       
        private void AlltinciCalisanBilgileri()
        {
            
            altinci.Adi = "Esra Demir";
            altinci.UzmanAlani = "Güzellik Uygulamaları ve Masaj Terapisi Uzmanı";
            altinci.OzGecmis = "Esra Demir,\r güzellik uygulamaları ve masaj terapisi konularında\n uzmanlaşmış bir güzellik uzmanıdır.\n Müşterilerinin rahatlaması ve yenilenmesi için\n en iyi masaj ve güzellik hizmetlerini sunmaktadır.\n";
            lbOzGecmis6.Text = altinci.OzGecmis;
            altinci.likeSayisi = 3604;
            lbCalısanAdi6.Text = altinci.Adi;
            lbUzmanAlani6.Text = altinci.UzmanAlani;
            lbLikeSayisi6.Text = altinci.likeSayisi.ToString();


            pictureBox6.Image = Properties.Resources.Firefly_Güzellik_Merkezi_3d_çalışan_Örtülü_kadın_13759;
        }


          ///------------------------------------------------------------
         /// Kalan Çalışanlar İçin Başka Formu Açma : 
        ///------------------------------------------------------------
        private void btnaİkinciFormuAc_Click(object sender, EventArgs e)
        {
            //2. duğmeyi basarsa calısanlar2 formuna yonlendiricek 
            frmCalisanlar2 calisanlar2 = new frmCalisanlar2();
            AltFormAcPanelİcinde(calisanlar2);
        }



          ///------------------------------------------------------------
         /// Çalışanlar İçin Like Atma : 
        ///------------------------------------------------------------



        private void btnLike1_Click(object sender, EventArgs e)
        {
            LikeDugmesi(birinci, btnLike1, lbLikeSayisi1);
           
        }
        private void btnLike2_Click_1(object sender, EventArgs e)
        {
            LikeDugmesi(ikinci, btnLike2, lbLikeSayisi2);
        }

        private void btnLike3_Click_1(object sender, EventArgs e)
        {
            LikeDugmesi(ucuncu, btnLike3, lbLikeSayisi3);
        }

        private void btnLike6_Click_1(object sender, EventArgs e)
        {
            LikeDugmesi(altinci, btnLike6, lbLikeSayisi6);
        }

        private void btnLike5_Click_1(object sender, EventArgs e)
        {
            LikeDugmesi(besinci, btnLike5, lbLikeSayisi5);
        }

        private void btnLike4_Click_1(object sender, EventArgs e)
        {
            LikeDugmesi(dorduncu, btnLike4, lbLikeSayisi4);

        }



          ///------------------------------------------------------------
         /// Like Duğme İşlevi : 
        ///------------------------------------------------------------

        void LikeDugmesi(clsCalisanlar personel,Button btnLike,Label lbLikeSayisi)
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
    }
   
}
