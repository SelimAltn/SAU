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
    public partial class HizmetFormu : Form
    {
        
        clsHizmetlerTanimlari hizmetTanimi=new clsHizmetlerTanimlari();

        public HizmetFormu()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void HizmetFormu_Load(object sender, EventArgs e)
        {

        }
        public void CilitBakimi ()
        {
            clsHizmetler cilitbakimi = new clsHizmetler();
            hizmetTanimi.CilitBakimi(cilitbakimi);
            pictureBox2.Image =Properties.Resources.Firefly_Buhar__Buhar__cildi_nemlendirir_ve_gözeneklerin_açılmasını_sağlar__Bu__cildin_daha_derinleme;
            pictureBox1.Image =Properties.Resources.Firefly_Yüz_Temizleme_3d_güzelik_salonuda_23573__1_;
            pictureBox3.Image = Properties.Resources.pexels_gabby_k_6621434;
            DegerlerAtma(cilitbakimi);

        }
        public void Makyaj()
        {
            clsHizmetler makyaj = new clsHizmetler();
            hizmetTanimi.Makyaj(makyaj);
            pictureBox2.Image = Properties.Resources.Firefly_Makyaj_kuafor__3d_13269;
            pictureBox1.Image = Properties.Resources.Firefly_Gündelik_Makyaj__Doğal_ve_hafif__3D_Örtülü_kadın_90809;
            pictureBox3.Image = Properties.Resources.Firefly_Gelin_Makyajı_3d_15173;
            DegerlerAtma(makyaj);
        }
        public void SacBakimi()
        {
            clsHizmetler sac = new clsHizmetler();
            hizmetTanimi.SacBakimi(sac);
           
            pictureBox2.Image= Properties.Resources.Firefly_saç_boyama__Kuaförda_3d_kadın_15173__1_;
            pictureBox1.Image= Properties.Resources.Firefly_kadın_saç_Kesim_güzelik_salonu_3d_31595;
            pictureBox3.Image = Properties.Resources.Firefly_kıvırcık_saç_hizmeti_kuafor__3d_5912;
            DegerlerAtma(sac);
            
        }
        private void DegerlerAtma(clsHizmetler obj)
        {
            lbBilgi1.Text = obj.Bilgi1;
            lbBilgi2.Text = obj.Bilgi2;
            lbBilgi3.Text = obj.Bilgi3;
            lbYanHizmetAdi1.Text = obj.yanHizmet1;
            lbYanHizmetAdi2.Text = obj.yanHizmet2;
            lbYanHizmetAdi3.Text = obj.yanHizmet3;
            lbAnaHizmetAdi.Text = obj.Adi;
           
        }
        public void Manikur()
        {
            clsHizmetler manikur = new clsHizmetler();
            hizmetTanimi.Manikur(manikur);
           
           pictureBox2.Image= Properties.Resources.Firefly_Manikür_ve_Pedikür_el_tırnak__3d_32930;
           pictureBox1.Image = Properties.Resources.Firefly_Manikür_ve_Pedikür_Cila_el_tırnak__3d_57236;
           pictureBox3.Image = Properties.Resources.Firefly_Manikür_ve_Pedikür_Topuk_Bakımı__3d_57236;
           DegerlerAtma(manikur);


        }
        public void Epilisyon()
        {
            clsHizmetler epilisyon = new clsHizmetler();
            hizmetTanimi.Epilisyon(epilisyon);
            pictureBox1.Image = Properties.Resources.Firefly_Lazer_Epilasyon_yapan_kadın__3d_81355;
            pictureBox2.Image = Properties.Resources.Firefly_Lazer_Epilasyon_yapan_kadın__Güzellik_Merkezi_3d_74053;
            pictureBox3.Image = Properties.Resources.Firefly_Lazer_Epilasyon_yapan_kadın__Güzellik_Merkezi_3d_39947;
            DegerlerAtma(epilisyon);
        }
        public void Mesaj()
        {
           clsHizmetler mesaj = new clsHizmetler();
            hizmetTanimi.Mesaj(mesaj);
            pictureBox1.Image = Properties.Resources.Firefly_mesaj_yatağı__guzellik_salon_3d_99771;
            pictureBox2.Image = Properties.Resources.Firefly_mesaj_yatağı__Güzellik_Merkezi_3d_çalışan_kadın_99771;
            pictureBox3.Image = Properties.Resources.Firefly_mesaj_yatağı__guzellik_salon_3d_99218;
            DegerlerAtma(mesaj);
        }
        public void Kirpik()
        {
            clsHizmetler kirpik = new clsHizmetler();
            hizmetTanimi.Kirpik(kirpik);
            pictureBox1.Image = Properties.Resources.Firefly_Kaş_Boyama__guzelik_salonda_Örtülü_kadın_3d_36128;
            pictureBox2.Image = Properties.Resources.Firefly_Kirpik_Kıvırma_yapan_kadın__3d_65923;
            pictureBox3.Image = Properties.Resources.Firefly_Kaş_ve_Kirpik_Bakımı_yapan_kadın__3d_65923;
            DegerlerAtma(kirpik);
        }
        public void Bronz()
        {
            clsHizmetler bronz = new clsHizmetler();
            hizmetTanimi.Bronz(bronz);
            pictureBox1.Image = Properties.Resources.Firefly_Bronzlaşma__Ciltte_bronz_bir_renk_elde_etmek_için_bronzlaşma_kremi_veya_sprey_kullanılması_i__2_;
            pictureBox2.Image = Properties.Resources.Firefly_Bronzlaşma__Ciltte_bronz_bir_renk_elde_etmek_için_bronzlaşma_kremi_veya_sprey_kullanılması_i__3_;
            pictureBox3.Image = Properties.Resources.Firefly_Bronzlaşma__Ciltte_bronz_bir_renk_elde_etmek_için_bronzlaşma_kremi_veya_sprey_kullanılması_i;
            DegerlerAtma(bronz);
        }
        public void Danisma()
        {
            clsHizmetler danisma = new clsHizmetler();
           
            hizmetTanimi.Danisma(danisma);
            lbBilgi2.Visible = false;
            lbBilgi3.Visible = false;
            lbYanHizmetAdi2.Visible = false;
            lbYanHizmetAdi3.Visible = false;
            pictureBox1.Image = Properties.Resources.Firefly_uzman_kadın_ve_odası__guzellik_salon_3d_99771;
            DegerlerAtma(danisma);
        }

        
    }
}
