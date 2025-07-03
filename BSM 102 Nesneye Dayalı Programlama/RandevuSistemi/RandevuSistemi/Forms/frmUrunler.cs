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
    public partial class frmUrunler : Form
    {
        public frmUrunler()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        void degerAtma(clsUrun bir, clsUrun iki, clsUrun uc, clsUrun dort, clsUrun bes, clsUrun alti,clsUrun yedi, clsUrun sikiz)
        {
            lb1UrunAdi.Text = bir.Adi;
            lb1UrunAciklamasi.Text = bir.Aciklama;
            lb1urunFiyati.Text = bir.Fiyat.ToString();

            lb2UrunAdi.Text = iki.Adi;
            lb2UrunAciklamasi.Text = iki.Aciklama;
            lb2urunFiyati.Text = iki.Fiyat.ToString();

            lb3UrunAdi.Text = uc.Adi;
            lb3UrunAciklamasi.Text = uc.Aciklama;
            lb3urunFiyati.Text = uc.Fiyat.ToString();

            lb4UrunAdi.Text = dort.Adi;
            lb4UrunAciklamasi.Text = dort.Aciklama;
            lb4urunFiyati.Text = dort.Fiyat.ToString();

            lb5UrunAdi.Text = bes.Adi;
            lb5UrunAciklamasi.Text = bes.Aciklama;
            lb5urunFiyati.Text = bes.Fiyat.ToString();

            lb6UrunAdi.Text = alti.Adi;
            lb6UrunAciklamasi.Text = alti.Aciklama;
            lb6urunFiyati.Text = alti.Fiyat.ToString();

            lb7UrunAdi.Text = yedi.Adi;
            lb7UrunAciklamasi.Text = yedi.Aciklama;
            lb7urunFiyati.Text = yedi.Fiyat.ToString();

            lb8UrunAdi.Text = sikiz.Adi;
            lb8UrunAciklamasi.Text = sikiz.Aciklama;
            lb8urunFiyati.Text = sikiz.Fiyat.ToString();

        }
        public void ciltBakimi()
        {
            clsUrun birinci = new clsUrun();
            birinci.Adi = "Renergie Cilt Bakım Seti";
            birinci.Aciklama = " Yeni Rénergie Krem 15 ML\n Rénergie Multi-Lift Ultra Göz Kremi 3 ML\n Génifique Serum 7 ML Boy:15 ml Bundle Adeti:3\n ";
            birinci.Fiyat = 699;
            pictureBox1.Image = Properties.Resources._1_org_zoom;
            
            


            clsUrun ikinci = new clsUrun();
            ikinci.Adi = " Yüksek Koruma\n Güneş Kremi";
            ikinci.Aciklama = " Güneş kremleri, cildi güneşin zararlı\n UV (ultraviyole) ışınlarından korumak\n amacıyla kullanılan kozmetik ürünlerdir. ";
            ikinci.Fiyat = 199;
            pictureBox2.Image = Properties.Resources._1_org_zoom__3_;
            
            clsUrun ucuncu = new clsUrun();
            ucuncu.Adi = "Cilt Beyazlatıcı ";
            ucuncu.Aciklama = " Cilt Beyazlatıcı Leke Kremi 50ml. ";
            ucuncu.Fiyat =259;
            pictureBox3.Image = Properties.Resources._1_org_zoom__1_;


            clsUrun dorduncu = new clsUrun();
            dorduncu.Adi = " Kırışıklık Giderici Botox ";
            dorduncu.Aciklama = " Gözenek Sıkılaştırıcı - Karamürver Ekstralı Peeling\n Etkilii Kolajen Serum 50mll. ";
            dorduncu.Fiyat = 239;
            pictureBox4.Image = Properties.Resources._1_org_zoom__2_;

            clsUrun besinci = new clsUrun();
            besinci.Adi = " Advanced Genifique";
            besinci.Aciklama = " Advanced Genifique Milyonlarca Probiyotik\n Türevi Içeren Onarıcı Serum 20 ml. ";
            besinci.Fiyat = 1200;
            pictureBox5.Image = Properties.Resources._8747;

            clsUrun altinci = new clsUrun();
            altinci.Adi = " Yaşlanma Karşıtı Ve\n Kırışıklık\n Giderici Krem ";
            altinci.Aciklama = " Yaşlanma Karşıtı Ve Kırışıklık Giderici Krem 50 Ml. ";
            altinci.Fiyat = 249;
            pictureBox6.Image = Properties.Resources.yaşlanma_;

            clsUrun yedinci = new clsUrun();
            yedinci.Adi = " Cilt Beyazlatıcı ";
            yedinci.Aciklama = "Cilt Beyazlatıcı Aydınlatıcı Glutatyonlu\n Leke Karşıtı Krem Kolajen,\n Niacinamide & Kojik Asitli 50 ml ";
            yedinci.Fiyat = 339;
            pictureBox7.Image = Properties.Resources._515;

            clsUrun sekizinci = new clsUrun();
            sekizinci.Adi = " Gül Suyu  ";
            sekizinci.Aciklama = "% 100 Yağlı Gül Suyu Doğal\n Katkısız Aydınlatıcı Ve Gözenek Sıkılaştırıcı 200 ml ";
            sekizinci.Fiyat = 360;
            pictureBox8.Image = Properties.Resources._585;

            degerAtma(besinci,ikinci,ucuncu,dorduncu,besinci,altinci,yedinci,sekizinci);



        }
        public void Makyaj()
        {
            clsUrun birinci = new clsUrun();
            birinci.Adi = "Maskara 10 Ml";
            birinci.Aciklama = " Unlimited Kirpiklere Kalkık Görünüm \nVeren Maskara 10 Ml. Blackest Black ";
            birinci.Fiyat = 299;
            pictureBox1.Image = Properties.Resources._74;



            clsUrun ikinci = new clsUrun();
            ikinci.Adi = " Fırça Seti";
            ikinci.Aciklama = "AKS KOZMETİK 54'LÜ FAR + 10'LU FIRÇA SETİ\r\n54'LÜ FAR Mat ve sedefli far paleti ayrıcalığını yaşayabilirsiniz.\r\nister tek tek kullanım sağlayın,ister karıştırarak uygulama yapabilirsiniz. ";
            ikinci.Fiyat = 199;
            pictureBox2.Image = Properties.Resources._61;

            clsUrun ucuncu = new clsUrun();
            ucuncu.Adi = " Mat Ruj 12 Lippy ";
            ucuncu.Aciklama = "The Lip Gloss Super Stay Uzun Süre Kalıcı Likit Mat Ruj 12 Lippy\r\n ";
            ucuncu.Fiyat = 299;
            pictureBox3.Image = Properties.Resources._9898;


            clsUrun dorduncu = new clsUrun();
            dorduncu.Adi = "İKONİK GÖZ SETİ ";
            dorduncu.Aciklama = " Sınırlı sayıdaki İkonik Göz Setini, M·A·Cstack Maskara, Brushstroke Eyeliner ve çok özel makyaj çantası ile keşfet!. ";
            dorduncu.Fiyat = 1599;
            pictureBox4.Image = Properties.Resources._5;

            clsUrun besinci = new clsUrun();
            besinci.Adi = " Makyaj Paketi";
            besinci.Aciklama = " Unlimited Maskara, Marvellous Mocha Ruj, Blossom Dudak Yağı ve Göz Kalemi Makyaj Paketi. ";
            besinci.Fiyat = 375;
            pictureBox5.Image = Properties.Resources._476;

            clsUrun altinci = new clsUrun();
            altinci.Adi = " Kalıcı Oje Kedi Gözü ";
            altinci.Aciklama = "Renk 10ml | Dayanıklı Kolay Uygulanan Trend Renkler \n| Hızlı Kuruma Ve Parlaklık ";
            altinci.Fiyat = 185;
            pictureBox6.Image = Properties.Resources._86;

            clsUrun yedinci = new clsUrun();
            yedinci.Adi = " Toz Yüz Pudrası  ";
            yedinci.Aciklama = "Luminous Silk Compact Powder\n Mat Bitişli Toz Yüz Pudrası 01 Beige ";
            yedinci.Fiyat = 224;
            pictureBox7.Image = Properties.Resources._615;

            clsUrun sekizinci = new clsUrun();
            sekizinci.Adi = " Yoğun Pigmentli Likit Allık  ";
            sekizinci.Aciklama = "(PEMBE) - Mood Booster Lbl. - 002 Immortal Flowe ";
            sekizinci.Fiyat = 100;
            pictureBox8.Image = Properties.Resources._52;

            degerAtma(besinci, ikinci, ucuncu, dorduncu, besinci, altinci, yedinci, sekizinci);



        }
        public void SacBakim()
        {
            clsUrun birinci = new clsUrun();
            birinci.Adi = "Bakım Şampuanı";
            birinci.Aciklama = "L'oréal Paris Mucizevi Yağ Besleyici Bakım Şampuanı 360 ml ";
            birinci.Fiyat = 150;
            pictureBox1.Image = Properties.Resources._11;



            clsUrun ikinci = new clsUrun();
            ikinci.Adi = " Saç Bakım Sütü ";
            ikinci.Aciklama = " 200 ml Saçınıza bakım yapar ve ipeksi yumuşaklık kazanmasını sağlar. ";
            ikinci.Fiyat = 170;
            pictureBox2.Image = Properties.Resources._22;

            clsUrun ucuncu = new clsUrun();
            ucuncu.Adi = " Renk Koruyucu Bakım Yağı ";
            ucuncu.Aciklama = "lixir Ultime L'huile Rose Boyalı Saçlara \nÖzel Saça Parlıklık Veren Ve Renk Koruyan Saç Ba ";
            ucuncu.Fiyat = 1500;
            pictureBox3.Image = Properties.Resources._33;


            clsUrun dorduncu = new clsUrun();
            dorduncu.Adi = "Saç Maskesi \nve Saç Bakım Yağı ";
            dorduncu.Aciklama = " Sadece %100 saf Fas Argan Yağı içerir ve başka ek bileşenler içermez ";
            dorduncu.Fiyat = 490;
            pictureBox4.Image = Properties.Resources._44;

            clsUrun besinci = new clsUrun();
            besinci.Adi = "  Besleyici Şampuan";
            besinci.Aciklama = " Kolajen Ve Keratin Saç Dökülmesine Karşı Hızlı\n Sac Uzatan Dolgunlaştırıcı Onarıcı Besleyici Şampuan. ";
            besinci.Fiyat = 235;
            pictureBox5.Image = Properties.Resources._55;

            clsUrun altinci = new clsUrun();
            altinci.Adi = " Saç Bakım Serumu 50ml";
            altinci.Aciklama = "Hızlı Saç Uzatma Serumu Keratin -\n Argan Içerikli Çay Ağacı Özlü Saç Bakım Serumu 50ml ";
            altinci.Fiyat = 244;
            pictureBox6.Image = Properties.Resources._66;

            clsUrun yedinci = new clsUrun();
            yedinci.Adi = "  Şampuan 390ml ";
            yedinci.Aciklama = "Elseve Hydra [Hyaluronic] Nem Dolduran Şampuan, \nHyaluronik Asit içeren formülü ile saçı ağırlaştırmadan \nnem ile doldurarak canlı görünüm kazandırır. ";
            yedinci.Fiyat = 100;
            pictureBox7.Image = Properties.Resources._77;

            clsUrun sekizinci = new clsUrun();
            sekizinci.Adi = " Şampuan - Sülfatsız & Vegan  ";
            sekizinci.Aciklama = "Saç Dökülmesine Karşı (anti-chute) Güçlendirici Prebiyotik Şampuan - Sülfatsız & Vegan-300 Ml";
            sekizinci.Fiyat = 279;
            pictureBox8.Image = Properties.Resources._88;

            degerAtma(besinci, ikinci, ucuncu, dorduncu, besinci, altinci, yedinci, sekizinci);



        }
        public void Agiz()
        {
            clsUrun birinci = new clsUrun();
            birinci.Adi = "Diş Beyazlatma Bandı";
            birinci.Aciklama = "InsignoWhite diş beyazlatma bantlarının kullanımı basit, ağrısız ve zararsızdır güvenle kullanabilirsiniz. ";
            birinci.Fiyat = 560;
            pictureBox1.Image = Properties.Resources._111;



            clsUrun ikinci = new clsUrun();
            ikinci.Adi = " Diş Beyazlatma Seti ";
            ikinci.Aciklama = " (Diş macunu 50ml + Toz 50gr) ";
            ikinci.Fiyat = 170;
            pictureBox2.Image = Properties.Resources._222;

            clsUrun ucuncu = new clsUrun();
            ucuncu.Adi = "Diş Temizleme Set ";
            ucuncu.Aciklama = "Aktif Karbon Diş Temizleme Tozu 50 gr + Bambu Diş Fırçası Set ";
            ucuncu.Fiyat = 190;
            pictureBox3.Image = Properties.Resources._333;


            clsUrun dorduncu = new clsUrun();
            dorduncu.Adi = "Diş Beyazlatma Seti ";
            dorduncu.Aciklama = " Med-Blue Teknolojisi ile Diş Beyazlatma Seti \n" +
                "Smileshop benzersiz formüllü Diş Beyazlatma Jeli ve Med-Blue teknolojisi \n" +
                "ile günde sadece 10 dakikalık kullanımla 2 haftada\n bembeyaz dişlere kavuşmanızı sağlar. ";
            dorduncu.Fiyat = 499;
            pictureBox4.Image = Properties.Resources._444;

            clsUrun besinci = new clsUrun();
            besinci.Adi = "   Diş Beyazlatıcı Jel ";
            besinci.Aciklama = " Anında Beyazlık\r\nDaha Işıltılı Görünüm\r\nLeke Karşıtı Bakım\r\nSıcak ve Soğuk Tonların Dengelenmesi ";
            besinci.Fiyat = 100;
            pictureBox5.Image = Properties.Resources._555;

            clsUrun altinci = new clsUrun();
            altinci.Adi = " Diş Beyazlatıcı Seti";
            altinci.Aciklama = "Mor Aktif Karbon Diş Beyazlatma Seti (Mor Karbon Diş Macunu 75 Gr + Mor Karbon Diş Tozu 50 Gr) ";
            altinci.Fiyat = 299;
            pictureBox6.Image = Properties.Resources._666;

            clsUrun yedinci = new clsUrun();
            yedinci.Adi = "  Beyazlatıcı Diş Jeli  ";
            yedinci.Aciklama = "Diş fırçasının üzerine bir miktar alarak dairesel hareketler \nile dişlerinizi fırçalayınız. \nUygulama sonrası ağzınızı çalkalayarak durulayanız. \nHello Smile ürünü köpürmez.";
                 
            yedinci.Fiyat = 180;
            pictureBox7.Image = Properties.Resources._777;

            clsUrun sekizinci = new clsUrun();
            sekizinci.Adi = " Misvak";
            sekizinci.Aciklama = "3 Adet Misvak Diş Sağlığı Taze Vakumlu Poşette Misfak\r\n";
            sekizinci.Fiyat = 98;
            pictureBox8.Image = Properties.Resources._888;

            degerAtma(besinci, ikinci, ucuncu, dorduncu, besinci, altinci, yedinci, sekizinci);



        }
        private void HesapaGirisYapilmadi()
        {
            MessageBox.Show("Hesapa Giriş Yapmadınız ,Lütfen Hesapanızı açınız Yada Yeni Hesap Oluşturunuz", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btn1UrunSpete_Click(object sender, EventArgs e)
        {
            HesapaGirisYapilmadi();
        }

        private void btn2UrunSpete_Click(object sender, EventArgs e)
        {
            HesapaGirisYapilmadi();

        }

        private void btn3UrunSpete_Click(object sender, EventArgs e)
        {
            HesapaGirisYapilmadi();

        }

        private void btn4UrunSpete_Click(object sender, EventArgs e)
        {
            HesapaGirisYapilmadi();

        }

        private void btn5UrunSpete_Click(object sender, EventArgs e)
        {
            HesapaGirisYapilmadi();

        }

        private void btn6UrunSpete_Click(object sender, EventArgs e)
        {
            HesapaGirisYapilmadi();

        }

        private void btn7UrunSpete_Click(object sender, EventArgs e)
        {
            HesapaGirisYapilmadi();

        }

        private void btn8UrunSpete_Click(object sender, EventArgs e)
        {
            HesapaGirisYapilmadi();

        }
    }
}
