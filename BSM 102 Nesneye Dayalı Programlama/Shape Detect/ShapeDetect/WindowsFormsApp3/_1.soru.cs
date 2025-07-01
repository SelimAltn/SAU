using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3.GeometrikŞekiller;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;

namespace WindowsFormsApp3
{
    public partial class BirinciSoru : Form
    {

        public BirinciSoru()
        {
            InitializeComponent();
            
        }
        private void HerSeyinFalseYap()
        {
            //birinicinin :
            txtBirinciXkordinati.Visible = false;
            txtBirinciYkordinati.Visible = false;
            txtBirinciZkordinati.Visible = false;
            txtBirinciGenişlik.Visible = false;
            txtBirinciYukseklik.Visible = false;
            txtBirinciYariCab.Visible = false;
            txtBirinciDerinlik.Visible = false;

            lbBirinciXkordinati.Visible = false;
            lbBirinciYkordinati.Visible = false;
            lbBirinciZkordinati.Visible = false;
            lbBirinciGenişlik.Visible = false;
            lbBirinciYukseklik.Visible = false;
            lbBirinciYariCab.Visible = false;
            lbBirinciDerinlik.Visible = false;
            //ikincinin : 
            
            txtİkinciXkordinati.Visible = false;
            txtİkinciYkordinati.Visible = false;
            txtİkinciZkordinati.Visible = false;
            txtİkinciGenislik.Visible = false;
            txtİkinciYukseklik.Visible = false;
            txtİkinciYaricabi.Visible = false;
            txtİkinciDerinlik.Visible=false;


            lbİkinciXkordinati.Visible = false;
            lbİkinciYkordinati.Visible = false;
            lbİkinciZkordinati.Visible = false;
            lbİkinciGenislik.Visible = false;
            lbİkinciYukseklik.Visible = false;
            lbİkinciYaricabi.Visible = false;
            lbİkinciDerinlik.Visible=false;

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void NoktaUzunluklari ()
        {
            txtBirinciXkordinati.Visible = true;
            txtBirinciYkordinati.Visible = true;
            lbBirinciXkordinati.Visible = true;
            lbBirinciYkordinati.Visible = true;
           
           


        }
        private void dikdortgenUzunluklariİkinciSekil()
        {
            txtİkinciXkordinati.Visible=true;
            lbİkinciXkordinati.Visible=true;
            txtİkinciYkordinati.Visible=true;
            lbİkinciYkordinati.Visible=true;
            txtİkinciGenislik.Visible = true;
            lbİkinciGenislik.Visible = true;
            txtİkinciYukseklik.Visible = true;
            lbİkinciYukseklik.Visible = true;
          
             
        }
        private void dikdortgenUzunluklariBirinciSekil()
        {
            txtBirinciXkordinati.Visible = true;
            txtBirinciYkordinati.Visible = true;
            txtBirinciGenişlik.Visible = true;
            txtBirinciYukseklik.Visible = true;
            lbBirinciXkordinati.Visible = true;
            lbBirinciYkordinati.Visible = true;
            lbBirinciGenişlik.Visible = true;
            lbBirinciYukseklik.Visible = true;
           
        }
        private void CemberUzunluklariBirinciSekil()
        {

            txtBirinciXkordinati.Visible = true;
            lbBirinciXkordinati.Visible = true;
            txtBirinciYkordinati.Visible = true;
            lbBirinciYkordinati.Visible = true;
            txtBirinciYariCab.Visible = true;
            lbBirinciYariCab.Visible = true;
        }
        private void CemberUzunluklariİkincinciSekil()
        {

            txtİkinciXkordinati.Visible = true;
            lbİkinciXkordinati.Visible = true;
            txtİkinciYkordinati.Visible = true;
            lbİkinciYkordinati.Visible = true;
            txtİkinciYaricabi.Visible = true;
            lbİkinciYaricabi.Visible = true;
        }
        private void kureninUzunluklariBirincisekil()
        {
            txtBirinciXkordinati.Visible = true;
            lbBirinciXkordinati.Visible = true;
            txtBirinciYkordinati.Visible = true;
            txtBirinciZkordinati.Visible = true;
            lbBirinciYkordinati.Visible = true;
            lbBirinciZkordinati.Visible = true;
            txtBirinciYariCab.Visible = true;
            lbBirinciYariCab.Visible = true;
        }
        private void kureninUzunluklariİkinciSekil()
        {
            txtİkinciXkordinati.Visible = true;
            lbİkinciXkordinati.Visible = true;
            txtİkinciYkordinati.Visible = true;
            txtİkinciZkordinati.Visible = true;
            lbİkinciYkordinati.Visible = true;
            lbİkinciZkordinati.Visible = true;
            txtİkinciYaricabi.Visible = true;
            lbİkinciYaricabi.Visible = true;
        }
        private void DikdortgenPrizmaUzunluklariİkinci()
        {
            txtİkinciXkordinati.Visible = true;
            txtİkinciYkordinati.Visible = true;
            txtİkinciZkordinati.Visible = true;
            txtİkinciGenislik.Visible = true;
            txtİkinciYukseklik.Visible = true;
            txtİkinciDerinlik.Visible = true;

            lbİkinciXkordinati.Visible = true;
            lbİkinciYkordinati.Visible = true;
            lbİkinciZkordinati.Visible = true;
            lbİkinciGenislik.Visible = true;
            lbİkinciYukseklik.Visible = true;
            lbİkinciDerinlik.Visible = true;
        }
        private void DikdortgenPrizmaUzunluklariBirinci()
        {
            // Dikdörtgen prizma1 için gerekli kontrol ve etiketleri alt alta görünür yap
            txtBirinciXkordinati.Visible = true;
            txtBirinciYkordinati.Visible = true;
            txtBirinciZkordinati.Visible = true;
            txtBirinciGenişlik.Visible = true;
            txtBirinciYukseklik.Visible = true;
            txtBirinciDerinlik.Visible = true;
           
            lbBirinciXkordinati.Visible = true;
            lbBirinciYkordinati.Visible = true;
            lbBirinciZkordinati.Visible = true;
            lbBirinciGenişlik.Visible = true;
            lbBirinciYukseklik.Visible = true;
            lbBirinciDerinlik.Visible = true;

        }
        private void SilindirUzunluklariBirinciSekil()
        {
            txtBirinciXkordinati.Visible = true;
            txtBirinciYkordinati.Visible = true;
            txtBirinciZkordinati.Visible = true;
            txtBirinciYariCab.Visible = true;
            txtBirinciYukseklik.Visible = true;

            lbBirinciXkordinati.Visible = true;
            lbBirinciYkordinati.Visible = true;
            lbBirinciZkordinati.Visible = true;
            lbBirinciYariCab.Visible = true;
            lbBirinciYukseklik.Visible = true;
        }
        private void SilindirUzunluklariİkinciSekil()
        {
            txtİkinciXkordinati.Visible = true;
            txtİkinciYkordinati.Visible = true;
            txtİkinciZkordinati.Visible = true;
            txtİkinciYaricabi.Visible = true;
            txtİkinciYukseklik.Visible = true;

            lbİkinciXkordinati.Visible = true;
            lbİkinciYkordinati.Visible = true;
            lbİkinciZkordinati.Visible = true;
            lbİkinciYaricabi.Visible = true;
            lbİkinciYukseklik.Visible = true;
        }
        private void YuzeyinUzunluklariBirinciSekil()
        {
            txtBirinciXkordinati.Visible = true;
            txtBirinciYkordinati.Visible = true;
            txtBirinciZkordinati.Visible = true;
            txtBirinciDerinlik.Visible = true;
            txtBirinciGenişlik.Visible = true;
            txtBirinciYukseklik.Visible=true;

            lbBirinciXkordinati.Visible = true;
            lbBirinciYkordinati.Visible = true;
            lbBirinciZkordinati.Visible = true;
            lbBirinciDerinlik.Visible = true;
            lbBirinciGenişlik.Visible = true;
            lbBirinciYukseklik.Visible = true;
        }
        private void YuzeyinUzunluklariİkinciSekil()
        {
            txtİkinciXkordinati.Visible = true;
            txtİkinciYkordinati.Visible = true;
            txtİkinciZkordinati.Visible = true;
            txtİkinciDerinlik.Visible = true;
            txtİkinciGenislik.Visible = true;
            txtİkinciYukseklik.Visible = true;

            lbİkinciXkordinati.Visible = true;
            lbİkinciYkordinati.Visible = true;
            lbİkinciZkordinati.Visible = true;
            lbİkinciDerinlik.Visible = true;
            lbİkinciGenislik.Visible = true;
            lbİkinciYukseklik.Visible = true;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (comboBox2.SelectedIndex >= 0)
            {
                lbSecilenBirinciCisim.Visible = true;
                lbSecilenİkinciCisim.Visible = true;
                lbBirinciCisimYazdirma.Visible = true;
                lbİkinciCisimYazdirma.Visible = true;

            }
            switch (comboBox2.SelectedIndex) 
            {
                case 0:
                    lbBirinciCisimYazdirma.Text = "Nokta";
                    lbİkinciCisimYazdirma.Text = "Dörtgen";
                   
                    
                    HerSeyinFalseYap();
                    NoktaUzunluklari();
                    dikdortgenUzunluklariİkinciSekil();

                   
                    
                    break;
                case 1:
                    lbBirinciCisimYazdirma.Text = "Nokta";
                    lbİkinciCisimYazdirma.Text = "Çember";
                    HerSeyinFalseYap();
                    NoktaUzunluklari();
                    CemberUzunluklariİkincinciSekil();
                    break;
                case 2:
                    lbBirinciCisimYazdirma.Text = "Dikdörtgen";
                    lbİkinciCisimYazdirma.Text = "Dikdörtgen";
                    HerSeyinFalseYap();
                    dikdortgenUzunluklariBirinciSekil();
                    dikdortgenUzunluklariİkinciSekil();
                    break;
                case 3:
                    lbBirinciCisimYazdirma.Text = "Dikdörtgen";
                    lbİkinciCisimYazdirma.Text = "Çember";
                    HerSeyinFalseYap();
                    dikdortgenUzunluklariBirinciSekil();
                    CemberUzunluklariİkincinciSekil();
                    break;
                case 4:
                    lbBirinciCisimYazdirma.Text = "Çember";
                    lbİkinciCisimYazdirma.Text = "Çember";
                    HerSeyinFalseYap();
                    CemberUzunluklariBirinciSekil();
                    CemberUzunluklariİkincinciSekil();
                    break;
                case 5:
                    lbBirinciCisimYazdirma.Text = "Nokta";
                    lbİkinciCisimYazdirma.Text = "Küre";
                    HerSeyinFalseYap();
                    NoktaUzunluklari();
                    kureninUzunluklariİkinciSekil();
                    break;
                case 6:
                    lbBirinciCisimYazdirma.Text = "Nokta";
                    lbİkinciCisimYazdirma.Text = "Dikdörtgen Prizma";
                    HerSeyinFalseYap();
                    NoktaUzunluklari();
                    DikdortgenPrizmaUzunluklariİkinci();

                    break;
                case 7:
                    lbBirinciCisimYazdirma.Text = "Nokta";
                    lbİkinciCisimYazdirma.Text = "Silindir";
                    HerSeyinFalseYap();
                    NoktaUzunluklari();
                    SilindirUzunluklariİkinciSekil();

                    break;
                case 8:
                    lbBirinciCisimYazdirma.Text = "Silindir";
                    lbİkinciCisimYazdirma.Text = "Silindir";
                    HerSeyinFalseYap();
                    SilindirUzunluklariBirinciSekil();
                    SilindirUzunluklariİkinciSekil();
                    break;
                case 9:
                    lbBirinciCisimYazdirma.Text = "Küre";
                    lbİkinciCisimYazdirma.Text = "Küre";
                    HerSeyinFalseYap();
                    kureninUzunluklariBirincisekil();
                    kureninUzunluklariİkinciSekil();
                    break;
                case 10:
                    lbBirinciCisimYazdirma.Text = "Küre";
                    lbİkinciCisimYazdirma.Text = "Silindir";
                    HerSeyinFalseYap();
                    kureninUzunluklariBirincisekil();
                    SilindirUzunluklariİkinciSekil();
                    break;
                case 11:
                    lbBirinciCisimYazdirma.Text = "Yüzey";
                    lbİkinciCisimYazdirma.Text = "Küre";
                    HerSeyinFalseYap();
                    YuzeyinUzunluklariBirinciSekil();
                    kureninUzunluklariİkinciSekil();
                    break;
                case 12:
                    lbBirinciCisimYazdirma.Text = "Yüzey";
                    lbİkinciCisimYazdirma.Text = "Dikdörtgen Prizma";
                    HerSeyinFalseYap();
                    YuzeyinUzunluklariBirinciSekil();
                    DikdortgenPrizmaUzunluklariİkinci();
                    break;
                case 13:
                    lbBirinciCisimYazdirma.Text = "Yüzey";
                    lbİkinciCisimYazdirma.Text = "Silindir";
                    HerSeyinFalseYap();
                    YuzeyinUzunluklariBirinciSekil();
                    SilindirUzunluklariİkinciSekil();
                    break;
                case 14:
                    lbBirinciCisimYazdirma.Text = "Küre";
                    lbİkinciCisimYazdirma.Text = "Dikdörtgen Prizma";
                    HerSeyinFalseYap();
                    kureninUzunluklariBirincisekil();
                    DikdortgenPrizmaUzunluklariİkinci();
                    break;
                case 15:
                    lbBirinciCisimYazdirma.Text = "Dikdörtgen Prizma";
                    lbİkinciCisimYazdirma.Text = "Dikdörtgen Prizma";
                    HerSeyinFalseYap();
                    DikdortgenPrizmaUzunluklariBirinci();
                    DikdortgenPrizmaUzunluklariİkinci();
                    break;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            switch (comboBox2.SelectedIndex)
            {
                case 0://nokta-dortgen2
                    Nokta2d nokta = new Nokta2d();
                    Dortgen dortgen2 = new Dortgen();
                   
                    panel2.Invalidate();
                    panel2.Refresh();
                    txtBirinciXkordinati.Text = nokta.X.ToString();
                    txtBirinciYkordinati.Text = nokta.Y.ToString();
                    txtİkinciXkordinati.Text = dortgen2.X.ToString();
                    txtİkinciYkordinati.Text = dortgen2.Y.ToString();
                    txtİkinciYukseklik.Text = dortgen2.Boy.ToString();
                    txtİkinciGenislik.Text = dortgen2.Gen.ToString();

                    if (Carpismalar.NoktaDikdortgen(nokta, dortgen2))
                    {
                        lbSonuc.Visible = true;
                        lbSonuc.Text = "Çarpışma Var";
                    }
                       
                    else
                        lbSonuc.Text = "Çarpışma Yok";
                   

                    nokta.NoktaCiz(panel2);
                    dortgen2.DortgenCiz(panel2);

                    break;
                case 1://Nokta-cember1 Değer Atma
                    Nokta2d nokta1 = new Nokta2d();
                    Daire cember2 = new Daire();
                    txtBirinciXkordinati.Text = nokta1.X.ToString();
                    txtBirinciYkordinati.Text = nokta1.Y.ToString();
                    txtİkinciXkordinati.Text = cember2.X.ToString();
                    txtİkinciYkordinati.Text = cember2.Y.ToString();
                    txtİkinciYaricabi.Text = cember2.R.ToString();

                    panel2.Invalidate();
                    panel2.Refresh();
                    
                    if (Carpismalar.NoktaCember(nokta1,cember2))
                        lbSonuc.Text = "Çarpışma Var";
                    else
                        lbSonuc.Text = "Çarpışma Yok";
                    nokta1.NoktaCiz(panel2);
                    cember2.CemberCiz(panel2);
                    

                    break;
                   
                case 2://dikdortgen1-dikdortgen2 Değer Atma
                   
                    panel2.Invalidate();
                    panel2.Refresh();
                      
                    Dikdortgen dikdortgen1 = new Dikdortgen();
                  
                    txtBirinciXkordinati.Text = dikdortgen1.X.ToString();
                    txtBirinciYkordinati.Text = dikdortgen1.Y.ToString();
                    txtBirinciGenişlik.Text = dikdortgen1.Gen.ToString();
                    txtBirinciYukseklik.Text = dikdortgen1.Boy.ToString();

                    Dortgen dikdortgen2 = new Dortgen();

                    txtİkinciXkordinati.Text = dikdortgen2.X.ToString();
                    txtİkinciYkordinati.Text = dikdortgen2.Y.ToString();
                    txtİkinciGenislik.Text = dikdortgen2.Gen.ToString();
                    txtİkinciYukseklik.Text = dikdortgen2.Boy.ToString();
                    if (Carpismalar.DikdortgenDikdortgen(dikdortgen1, dikdortgen2))
                        lbSonuc.Text = "Çarpışma Var";
                    else
                        lbSonuc.Text = "Çarpışma Yok";
                    dikdortgen1.DikdortgenCiz(panel2);
                    dikdortgen2.DortgenCiz(panel2);

                    
                    break;
                case 3://dikdortgen2-cember1 Değer Atma
                    
                    Dikdortgen dikdortgen3 = new Dikdortgen();
                    txtBirinciXkordinati.Text = dikdortgen3.X.ToString();
                    txtBirinciYkordinati.Text = dikdortgen3.Y.ToString();
                    txtBirinciGenişlik.Text = dikdortgen3.Gen.ToString();
                    txtBirinciYukseklik.Text = dikdortgen3.Boy.ToString();
                    Daire cember3 = new Daire();
                    txtİkinciXkordinati.Text = cember3.X.ToString();
                    txtİkinciYkordinati.Text = cember3.Y.ToString();
                    txtİkinciYaricabi.Text = cember3.R.ToString();
                    panel2.Invalidate();
                    panel2.Refresh();
                    if (Carpismalar.DikdortgenCember(dikdortgen3, cember3))
                        lbSonuc.Text = "Çarpışma Var";
                    else
                        lbSonuc.Text = "Çarpışma Yok";

                    dikdortgen3.DikdortgenCiz(panel2);
                    cember3.CemberCiz(panel2);


                    break;
                case 4://çember-çember Değer Atma

                    Daire cember4 = new Daire();
                    txtBirinciXkordinati.Text = cember4.X.ToString();
                    txtBirinciYkordinati.Text = cember4.Y.ToString();
                    txtBirinciYariCab.Text = cember4.R.ToString();
                    panel2.Invalidate();
                    panel2.Refresh();
                 
                    Daire cember5 = new Daire();
                    txtİkinciXkordinati.Text = cember5.X.ToString();
                    txtİkinciYkordinati.Text = cember5.Y.ToString();
                    txtİkinciYaricabi.Text = cember5.R.ToString();
                    if (Carpismalar.CemberCember(cember4, cember5))
                        lbSonuc.Text = "Çarpışma Var";
                    else
                        lbSonuc.Text = "Çarpışma Yok";
                    cember4.CemberCiz(panel2);
                    cember5.CemberCiz(panel2);

                    break;
                case 5: //Nokta-kure2 Değer Atma
                    Nokta3d nokta3d = new Nokta3d();
                    //KureİkinciSekilİcinDegerAtma();
                    panel2.Invalidate();
                    panel2.Refresh();
                    txtBirinciXkordinati.Text = nokta3d.X.ToString();
                    txtBirinciYkordinati.Text = nokta3d.Y.ToString();
                    txtBirinciZkordinati.Text = nokta3d.Z.ToString();
                    Kure kure2 = new Kure();
                    txtİkinciXkordinati.Text = kure2.X.ToString();
                    txtİkinciYkordinati.Text = kure2.Y.ToString();
                    txtİkinciZkordinati.Text = kure2.Z.ToString();
                    txtİkinciYaricabi.Text = kure2.R.ToString();
                    if (Carpismalar.NoktaKure(nokta3d, kure2))
                        lbSonuc.Text = "Çarpışma Var";
                    else
                        lbSonuc.Text = "Çarpışma Yok";
                    //nokta.NoktaCiz(panel2);
                    kure2.KureCiz(panel2);
                    nokta3d.NoktaCiz(panel2);
                    break;



                case 6: //Nokta-dikdörtgen prizma1 Değer Atma
                   
                    
                    panel2.Invalidate();
                    panel2.Refresh();
                    Nokta3d nokta3 = new Nokta3d();
                    txtBirinciXkordinati.Text = nokta3.X.ToString();
                    txtBirinciYkordinati.Text = nokta3.Y.ToString();
                    txtBirinciZkordinati.Text = nokta3.Z.ToString();
                    DikdortgenPrizmasi prizma = new DikdortgenPrizmasi();
                    txtİkinciXkordinati.Text = prizma.X.ToString();
                    txtİkinciYkordinati.Text = prizma.Y.ToString();
                    txtİkinciZkordinati.Text = prizma.Z.ToString();
                    txtİkinciGenislik.Text = prizma.Gen.ToString();
                    txtİkinciDerinlik.Text = prizma.Derinlik.ToString();
                    txtİkinciYukseklik.Text = prizma.Boy.ToString();
                    if (Carpismalar.NoktaDikdortgenPrizmasi(nokta3, prizma))
                        lbSonuc.Text = "Çarpışma Var";
                    else
                        lbSonuc.Text = "Çarpışma Yok";
                    nokta3.NoktaCiz(panel2);
                    prizma.PrizmaCiz(panel2);
                    break;


                case 7://Nokta-Silindir Değer Atma 
                   
                    Nokta3d nokta4 = new Nokta3d();
                    txtBirinciXkordinati.Text = nokta4.X.ToString();
                    txtBirinciYkordinati.Text = nokta4.Y.ToString();
                    txtBirinciZkordinati.Text = nokta4.Z.ToString();
                    Silindir silindir = new Silindir();
                    txtİkinciXkordinati.Text = silindir.X.ToString();
                    txtİkinciYkordinati.Text = silindir.Y.ToString();
                    txtİkinciZkordinati.Text = silindir.Z.ToString();
                    txtİkinciYukseklik.Text = silindir.H.ToString();
                    txtİkinciYaricabi.Text = silindir.R.ToString();
                    panel2.Invalidate();
                    panel2.Refresh();
                    if (Carpismalar.NoktaSilindir(nokta4, silindir))
                        lbSonuc.Text = "Çarpışma Var";
                    else
                        lbSonuc.Text = "Çarpışma Yok";
                    nokta4.NoktaCiz(panel2);
                    silindir.SilindirCiz(panel2);
                    break;
                case 8: //Silindir-Silindir Değer Atma 
                   Silindir silindir1 = new Silindir();
                    txtBirinciXkordinati.Text = silindir1.X.ToString();
                    txtBirinciYkordinati.Text = silindir1.Y.ToString();
                    txtBirinciZkordinati.Text = silindir1.Z.ToString();
                    txtBirinciYukseklik.Text = silindir1.H.ToString();
                    txtBirinciYariCab.Text = silindir1.R.ToString();
                    panel2.Invalidate();
                    panel2.Refresh();
                    Silindir silindir2 = new Silindir();
                    txtİkinciXkordinati.Text = silindir2.X.ToString();
                    txtİkinciYkordinati.Text = silindir2.Y.ToString();
                    txtİkinciZkordinati.Text = silindir2.Z.ToString();
                    txtİkinciYukseklik.Text = silindir2.H.ToString();
                    txtİkinciYaricabi.Text = silindir2.R.ToString();
                    if (Carpismalar.SilindirSilindir(silindir1, silindir2))
                        lbSonuc.Text = "Çarpışma Var";
                    else
                        lbSonuc.Text = "Çarpışma Yok";
                    silindir1.SilindirCiz(panel2);
                    silindir2.SilindirCiz(panel2);

                    break;

                case 9://küre-küre Değer Atma 
                   Kure kure1 = new Kure();
                    txtBirinciXkordinati.Text = kure1.X.ToString();
                    txtBirinciYkordinati.Text = kure1.Y.ToString();
                    txtBirinciZkordinati.Text = kure1.Z.ToString();
                    txtBirinciYariCab.Text = kure1.R.ToString();
                    Kure kure3 = new Kure();
                    txtİkinciXkordinati.Text = kure3.X.ToString();
                    txtİkinciYkordinati.Text = kure3.Y.ToString();
                    txtİkinciZkordinati.Text = kure3.Z.ToString();
                    txtİkinciYaricabi.Text = kure3.R.ToString();
                    panel2.Invalidate();
                    panel2.Refresh();
                    if (Carpismalar.KureKure(kure1, kure3))
                        lbSonuc.Text = "Çarpışma Var";
                    else
                        lbSonuc.Text = "Çarpışma Yok";
                    kure1.KureCiz(panel2);
                    kure3.KureCiz(panel2);
                    break;
                case 10://Küre-Silindir Değer Atma
                    Kure kure5 = new Kure();
                    txtBirinciXkordinati.Text = kure5.X.ToString();
                    txtBirinciYkordinati.Text = kure5.Y.ToString();
                    txtBirinciZkordinati.Text = kure5.Z.ToString();
                    txtBirinciYariCab.Text = kure5.R.ToString();
                    panel2.Invalidate();
                    panel2.Refresh();
                    Silindir silindir5 = new Silindir();
                    txtİkinciXkordinati.Text = silindir5.X.ToString();
                    txtİkinciYkordinati.Text = silindir5.Y.ToString();
                    txtİkinciZkordinati.Text = silindir5.Z.ToString();
                    txtİkinciYukseklik.Text = silindir5.H.ToString();
                    txtİkinciYaricabi.Text = silindir5.R.ToString();
                    if (Carpismalar.KureSilindir(kure5, silindir5))
                        lbSonuc.Text = "Çarpışma Var";
                    else
                        lbSonuc.Text = "Çarpışma Yok";
                    kure5.KureCiz(panel2);
                    silindir5.SilindirCiz(panel2);
                    break;
                case 11: //Yuzey-Kure Değer Atma
                    Kure kure6 = new Kure();
                    txtİkinciXkordinati.Text =kure6.X.ToString();
                    txtİkinciYkordinati.Text =kure6.Y.ToString();
                    txtİkinciZkordinati.Text = kure6.Z.ToString();
                    txtİkinciYaricabi.Text = kure6.R.ToString();

                    Yuzey yuzey =new Yuzey();
                    txtBirinciXkordinati.Text = yuzey.X.ToString();
                    txtBirinciYkordinati.Text = yuzey.Y.ToString();
                    txtBirinciZkordinati.Text = yuzey.Z.ToString();
                    txtBirinciDerinlik.Text = yuzey.Derinlik.ToString();
                    txtBirinciGenişlik.Text = yuzey.Gen.ToString();
                    txtBirinciYukseklik.Text = yuzey.Boy.ToString();
                    panel2.Invalidate();
                    panel2.Refresh();
                    if (Carpismalar.KureYuzy(kure6, yuzey))
                        lbSonuc.Text = "Çarpışma Var";
                    else
                        lbSonuc.Text = "Çarpışma Yok";
                    yuzey.YuzeyCiz(panel2);
                    kure6.KureCiz(panel2);
                    break;
                case 12://Yüzey-dikdörtgen prizma1 Değer Atma
                    Yuzey yuzey1 = new Yuzey();
                    txtBirinciXkordinati.Text = yuzey1.X.ToString();
                    txtBirinciYkordinati.Text = yuzey1.Y.ToString();
                    txtBirinciZkordinati.Text = yuzey1.Z.ToString();
                    txtBirinciDerinlik.Text = yuzey1.Derinlik.ToString();
                    txtBirinciGenişlik.Text = yuzey1.Gen.ToString();
                    txtBirinciYukseklik.Text = yuzey1.Boy.ToString();
                    panel2.Invalidate();
                    panel2.Refresh();
                    DikdortgenPrizmasi prizma2 = new DikdortgenPrizmasi();
                    txtİkinciXkordinati.Text = prizma2.X.ToString();
                    txtİkinciYkordinati.Text = prizma2.Y.ToString();
                    txtİkinciZkordinati.Text = prizma2.Z.ToString();
                    txtİkinciGenislik.Text = prizma2.Gen.ToString();
                    txtİkinciDerinlik.Text = prizma2.Derinlik.ToString();
                    txtİkinciYukseklik.Text = prizma2.Boy.ToString();
                    if (Carpismalar.DikdotgenPrizmasiYuzey(prizma2, yuzey1))
                        lbSonuc.Text = "Çarpışma Var";
                    else
                        lbSonuc.Text = "Çarpışma Yok";
                    yuzey1.YuzeyCiz(panel2);
                    prizma2.PrizmaCiz(panel2);
                    break;
                case 13://Yuzey-Silindir  Değer Atma
                    Yuzey yuzey5 = new Yuzey();
                    txtBirinciXkordinati.Text = yuzey5.X.ToString();
                    txtBirinciYkordinati.Text = yuzey5.Y.ToString();
                    txtBirinciZkordinati.Text = yuzey5.Z.ToString();
                    txtBirinciDerinlik.Text = yuzey5.Derinlik.ToString();
                    txtBirinciGenişlik.Text = yuzey5.Gen.ToString();
                    txtBirinciYukseklik.Text = yuzey5.Boy.ToString();
                    panel2.Invalidate();
                    panel2.Refresh();
                    Silindir silindir6 = new Silindir();
                    txtİkinciXkordinati.Text = silindir6.X.ToString();
                    txtİkinciYkordinati.Text = silindir6.Y.ToString();
                    txtİkinciZkordinati.Text = silindir6.Z.ToString();
                    txtİkinciYukseklik.Text = silindir6.H.ToString();
                    txtİkinciYaricabi.Text = silindir6.R.ToString();
                    if (Carpismalar.SilindirYuzey(silindir6, yuzey5))
                        lbSonuc.Text = "Çarpışma Var";
                    else
                        lbSonuc.Text = "Çarpışma Yok";
                    yuzey5.YuzeyCiz(panel2);
                    silindir6.SilindirCiz(panel2);
                    break;
                case 14://Küre-Prizma  Değer Atma
                    Kure kure7 = new Kure();
                    txtBirinciXkordinati.Text = kure7.X.ToString();
                    txtBirinciYkordinati.Text = kure7.Y.ToString();
                    txtBirinciZkordinati.Text = kure7.Z.ToString();
                    txtBirinciYariCab.Text = kure7.R.ToString();
                    panel2.Invalidate();
                    panel2.Refresh();
                    DikdortgenPrizmasi prizma4 = new DikdortgenPrizmasi();
                    txtİkinciXkordinati.Text = prizma4.X.ToString();
                    txtİkinciYkordinati.Text = prizma4.Y.ToString();
                    txtİkinciZkordinati.Text = prizma4.Z.ToString();
                    txtİkinciGenislik.Text = prizma4.Gen.ToString();
                    txtİkinciDerinlik.Text = prizma4.Derinlik.ToString();
                    txtİkinciYukseklik.Text = prizma4.Boy.ToString();
                    if (Carpismalar.KurePrizma(kure7, prizma4))
                        lbSonuc.Text = "Çarpışma Var";
                    else
                        lbSonuc.Text = "Çarpışma Yok";
                    kure7.KureCiz(panel2);
                    prizma4.PrizmaCiz(panel2);

                    break;
                case 15://prizma1-prizma1 Değer Atma
                    DikdortgenPrizmasi prizma0 = new DikdortgenPrizmasi();
                    txtBirinciXkordinati.Text = prizma0.X.ToString();
                    txtBirinciYkordinati.Text = prizma0.Y.ToString();
                    txtBirinciZkordinati.Text = prizma0.Z.ToString();
                    txtBirinciGenişlik.Text = prizma0.Gen.ToString();
                    txtBirinciDerinlik.Text = prizma0.Derinlik.ToString();
                    txtBirinciYukseklik.Text = prizma0.Boy.ToString();
                    panel2.Invalidate();
                    panel2.Refresh();
                    DikdortgenPrizmasi prizma3 = new DikdortgenPrizmasi();
                    txtİkinciXkordinati.Text = prizma3.X.ToString();
                    txtİkinciYkordinati.Text = prizma3.Y.ToString();
                    txtİkinciZkordinati.Text = prizma3.Z.ToString();
                    txtİkinciGenislik.Text = prizma3.Gen.ToString();
                    txtİkinciDerinlik.Text = prizma3.Derinlik.ToString();
                    txtİkinciYukseklik.Text = prizma3.Boy.ToString();
                    if (Carpismalar.DikdortgenprizmasiDikdortgenprizmasi(prizma0, prizma3))
                        lbSonuc.Text = "Çarpışma Var";
                    else
                        lbSonuc.Text = "Çarpışma Yok";
                    prizma0.PrizmaCiz(panel2);
                    prizma3.PrizmaCiz(panel2);
                    break;
            }
        }
        

        void loaadForm(Form form)
        {
            if (this.panel2.Controls.Count > 0)
                this.panel2.Controls.RemoveAt(0);

            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(form);
            this.panel2.Tag = form;
            form.Show();
        }

        private void BirinciSoru_Load(object sender, EventArgs e)
        {
            
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void butDegerleriSifirla_Click(object sender, EventArgs e)
        {
            //Birinci : 
            txtBirinciDerinlik.Text = "";
            txtBirinciGenişlik.Text = "";
            txtBirinciYukseklik.Text = "";
            txtBirinciYariCab.Text = "";
            txtBirinciXkordinati.Text = "";
            txtBirinciYkordinati.Text = "";
            txtBirinciZkordinati.Text = "";
            //ikinci : 
            txtİkinciDerinlik.Text = "";
            txtİkinciGenislik.Text = "";
            txtİkinciYukseklik.Text = "";
            txtİkinciYaricabi.Text = "";
            txtİkinciXkordinati.Text = "";
            txtİkinciYkordinati.Text = "";
            txtİkinciZkordinati.Text = "";

        }

        private void txtBirinciDerinlik_TextChanged(object sender, EventArgs e)
        {

        }

       
    }
}
