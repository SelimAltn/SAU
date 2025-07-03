/****************************************************************************
** SAKARYA ÜNİVERSİTESİ
** BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
** BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
** NESNEYE DAYALI PROGRAMLAMA DERSİ
** 2023-2024 BAHAR DÖNEMİ
**
** ÖDEV NUMARASI 3 PROJE:
** ÖĞRENCİ ADI SELİM ALTIN:
** ÖĞRENCİ NUMARASI G231210558:
** DERSİN ALINDIĞI GRUP A:
****************************************************************************/



using RandevuSistemi.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandevuSistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            random = new Random();
            Color arkaPlanRengi = Color.FromArgb(51, 51, 76);
            panelMenu.BackColor = arkaPlanRengi;
            panelLogo.BackColor = arkaPlanRengi;
            panelUst.BackColor = arkaPlanRengi;
            btnBackhizmet.Visible = false;
            btnBackSatisİcin.Visible = false;
            this.Text = string.Empty;
            this.ControlBox = false;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }


           ///--------------------------------------------------------------------
          /// Form hareket ettirme işlevleri için kullanıcı32.dll'den çağrılar
         ///---------------------------------------------------------------------
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        // Formu taşımak için panel üzerine tıklama olayını işler
        private void panelUst_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }


        // Uygulamanın pencere boyutunu değiştirir
        private void button2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }


        // Uygulamayı simge durumuna küçültür
        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        ///---------------------------------------------------
        ///---------------- Özel alanlar
        ///-------------------------------------------------------

        private Button btn;  // Aktif butonu takip eder
        private Random random;  // Rastgele renk seçimi için kullanılır
        private int tempIndex;  // Son kullanılan renk indeksini tutar
        private Form activeForm;  // Aktif alt formu takip eder


         ///----------------------------------------------------
        ///---------------Rastgele bir tema rengi seçer
       ///-------------------------------------------------------

        public Color SelectThemeColor()
        {
            int index = random.Next(clsTemaRenki.RenkListesi.Count);
            while (tempIndex == index)
            {
                index = random.Next(clsTemaRenki.RenkListesi.Count);
            }
            tempIndex = index;
            string color = clsTemaRenki.RenkListesi[index];
            return ColorTranslator.FromHtml(color);
        }

          ///-------------------------------------------------------
         ///Belirli bir butonu etkinleştirir ve rengini değiştirir
        ///-------------------------------------------------------
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (btn != (Button)btnSender)
                {
                    DisableButton();
                    Color color = SelectThemeColor();
                    btn = (Button)btnSender;
                    btn.BackColor = color;
                    btn.ForeColor = Color.White;
                    btn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                    panelLogo.BackColor = clsTemaRenki.RenkParliklgi(color, -0.3);
                    clsTemaRenki.PrimaryColor = color;
                    clsTemaRenki.SecondaryColor = clsTemaRenki.RenkParliklgi(color, -0.3);
                }
            }
        }


          ///---------------------------------------------------
         ///Tüm butonları devre dışı bırakır ve varsayılan stiline geri döner
        ///-------------------------------------------------------
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.FromArgb(51, 51, 76);
                    previousBtn.ForeColor = Color.Gainsboro;
                    previousBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                }
            }
        }


          ///---------------------------------------------------
         ///------------- Panel içinde alt formu açar
        ///-------------------------------------------------------
        private void AltFormAcPanelİcinde(Form childForm, object btnSender ,string sayfa_adi)
        {
            if (activeForm != null)
                activeForm.Close();

            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelFormlar.Controls.Add(childForm);
            this.panelFormlar.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            LBBulunduSayfaAdi.Text = sayfa_adi;

            // Geri butonlarının (Back) görünürlüğünü ayarlar
            SetBackButtonVisibility(childForm);
        }



          ///---------------------------------------------------
         ///------------------- Formlar Açma
        ///-------------------------------------------------------
     
        private void btnHizmetlerimiz_Click(object sender, EventArgs e)
        {
            AltFormAcPanelİcinde(new frmHizmetlerimiz(), sender,"Hizmetlerimiz");
        }

        private void btnCalisanlarimiz_Click(object sender, EventArgs e)
        {
            AltFormAcPanelİcinde(new frmCalisanlar1(), sender, "Çalışanlarımız");
        }

        private void btnMemnuniyet_Click(object sender, EventArgs e)
        {
            AltFormAcPanelİcinde(new MemnuniyetMesajlari(), sender,"Memnuniyet Mesajlarınız");
        }

        private void btnHakkimizda_Click(object sender, EventArgs e)
        {
            AltFormAcPanelİcinde(new Hakkimizda(), sender,"Hakkımızda");
        }

        private void btnDegerlendir_Click(object sender, EventArgs e)
        {
            AltFormAcPanelİcinde(new BizeDegerlendiriniz(), sender,"Bize Değerlendiriniz");
        }
        private void btnHostGirisi_Click_1(object sender, EventArgs e)
        {
            AltFormAcPanelİcinde(new HostGirisi(), sender, "Host Sayfası");
        }



        ///---------------------------------------------------------------
        ///Alt forma göre geri (Back) butonlarının görünürlüğünü ayarlar
        ///----------------------------------------------------------------
        private void SetBackButtonVisibility(Form form)
        {
            if (form is frmHizmetlerimiz || form is HizmetFormu)
            {
                btnBackhizmet.Visible = true;
                btnBackSatisİcin.Visible = false;
            }
            else if (form is frmKozmatikUrunlerKategori || form is frmUrunler)
            {
                btnBackhizmet.Visible = false;
                btnBackSatisİcin.Visible = true;
            }
            else
            {
                btnBackhizmet.Visible = false;
                btnBackSatisİcin.Visible = false;
            }
        }

       
        //Geri fonksiyonu, belirtilen iki form arasında geçiş yapar
       
        public void back(Form frmAc, Form frmKapat, object sender ,string Sayfa_Adi)
        {
            if (frmKapat != null)
            {
                frmKapat.Close();
                AltFormAcPanelİcinde(frmAc, sender, Sayfa_Adi);
            }
        }

        // Hizmetlerimiz formuna geri döner 
        private void btnBack_Click(object sender, EventArgs e)
        {
            back(new frmHizmetlerimiz(), new HizmetFormu(), sender ,"Hizmetlerimiz");
        }

        private void btnKozmatikUrunler_Click(object sender, EventArgs e)
        {
            frmKozmatikUrunlerKategori urun = new frmKozmatikUrunlerKategori();
            AltFormAcPanelİcinde(urun, sender, "Ürünlerimiz");
        }

        private void btnBackSatisİcin_Click(object sender, EventArgs e)
        {
            back(new frmKozmatikUrunlerKategori(), new frmUrunler(), sender, "Ürünlerimiz");
        }


        
        ///---------------------------------------------------
        ///---------------- Uygulamayı kapatma
        ///-------------------------------------------------------
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
/*
  +-------------------+          +-----------------------+
 |   ClsIHizmet      |<---------|     clsHizmetler      |
 +-------------------+          +-----------------------+
 | +Adi: string      |          | -adi: string          |
 | +Bilgi1: string   |          | -bilgi1: string       |
 | +Bilgi2: string   |          | -bilgi2: string       |
 | +Bilgi3: string   |          | -bilgi3: string       |
 | +Fiyat: int       |          | -fiyat: int           |
 +-------------------+          | +getter/setter        |
                                 +-----------------------+
                                        |
                                        |
                                        v
                                 +---------------------------+
                                 |   clsHizmetlerTanimlari   |
                                 +---------------------------+
                                 | -lsHizmet: List<clsHizmetler>|
                                 | +methodlar                 |
                                 +---------------------------+
                                    
 +---------------------------+                  +-----------------------------+
 |      clsMusteriManager    |<-----------------|           clsMusteri        |
 +---------------------------+                  +-----------------------------+
 | -instance: clsMusteriManager|                | -adi: string                |
 | -lsMusteriler: List<clsMusteri>|             | -soyadi: string             |
 | +Instance: clsMusteriManager   |             | -telefon_numara: string     |
 | +GetGunlukMaliyetler(): Dict<DateTime, int>| | -randevutarihi: DateTime    |
 +---------------------------+                  | +getter/setter              |
                                                 +-----------------------------+

  +---------------------------+                 +-----------------------------+
  |    clsPersonelManager     |<--------------->|         clsCalisanlar       |
  +---------------------------+                 +-----------------------------+
  | -instance: clsPersonelManager|             | -adisoyAdi: string          |
  | -LsCalisanlar: List<clsCalisanlar>|        | -uzmanAlani: string         |
  | -RandevuDurumlari: List<RandevuDurumu>|    | -ozGecmis: string           |
  | +Instance: clsPersonelManager |            | +getter/setter              |
  +---------------------------+                +-----------------------------+

  +-----------------------------+                  +-----------------------------+
  |   clsRandevusuzMusteriManger |<-------------->|      clsRandevusuzMusteri    |
  +-----------------------------+                  +-----------------------------+
  | -instance: clsRandevusuzMusteriManger|        | -adi: string                 |
  | -lsrandevusuzMusteriler: List<clsRandevusuzMusteri>| | -soyadi: string        |
  | +Instance: clsRandevusuzMusteriManger |       | -telefon_numara: string      |
  +-----------------------------+                 | +getter/setter               |
                                                  +-----------------------------+

  +-----------------------------+
  |          clsUrun            |
  +-----------------------------+
  | -adi: string                |
  | -aciklama: string           |
  | -fiyat: int                 |
  | +getter/setter              |
  +-----------------------------+

  +-----------------------------+
  |       RandevuDurumu         |
  +-----------------------------+
  | -tarih: DateTime            |
  | -personelIndex: int         |
  | -saatDurumlari: List<bool>  |
  | +SetSaatDurumu(int, bool)   |
  +-----------------------------+

 */