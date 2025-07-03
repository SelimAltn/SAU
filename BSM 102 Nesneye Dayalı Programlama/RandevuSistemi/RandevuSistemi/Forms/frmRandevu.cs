using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar;


namespace RandevuSistemi.Forms
{
    public partial class frmRandevu : Form
    {
        private Random random;
        private int tempIndex;
        private bool KampanyaYadaHizmetMi;
        private bool EskiYeniMusterimi;



        int Fiyat = 0;


        public frmRandevu()
        {
            InitializeComponent();

        }
        private void frmRandevu_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            random = new Random();
            Color color1 = SelectThemeColor();

            btnRandevuEkle.BackColor = color1;
            dataGridView1.DataSource = clsMusteriManager.Instance.LsMusteriler.ToList();


            // Bugünkü tarihi ayarla
            dateTimePicker1.MinDate = DateTime.Today;

            // Hafta sonlarını engelle
            TarihSinirlayici(dateTimePicker1);
            // Bir ay sonrasını ayarla
            dateTimePicker1.MaxDate = DateTime.Today.AddDays(30);


            clsPersonelManager manager = clsPersonelManager.Instance;
            foreach (var personel in manager.LsCalisanlar)
            {
                cbxPersonelSecme.Items.Add(personel.Adi);
            }
            clsRandevusuzMusteriManger manager2 = clsRandevusuzMusteriManger.Instance;
            cbxMusteriler.DataSource = manager2.LsrandevusuzMusteriler;
            cbxMusteriler.DisplayMember = "FullName";  // clsRandevusuzMusteri sınıfına FullName özelliği ekleyin
            cbxMusteriler.ValueMember = "Telefon_numara"; // DisplayMember ve ValueMember ayarları
            dataGridView1.SelectionMode = DataGridViewSelectionMode.CellSelect;



        }

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

        // Hafta sonlarını engelleyen işlev
        private void TarihSinirlayici(DateTimePicker tarih)
        {
            // CustomFormat ayarla
            tarih.CustomFormat = "dddd, dd MMMM yyyy";
            // Tarih seçimini yapma
            tarih.Format = DateTimePickerFormat.Custom;

            // ValueChanged olayını dinle
            tarih.ValueChanged += (sender, e) =>
            //Bu ifade bir olay dinleyicisi (event handler) eklemek için kullanılan bir lambda ifadesidir.
            //ValueChanged olayı, DateTimePicker kontrolünün değeri değiştiğinde tetiklenir. Bu olay,
            //kullanıcı yeni bir tarih seçtiğinde veya mevcut tarih alanlarından biri değiştirildiğinde çalışır.
            {
                DateTime selectedDate = tarih.Value;

                // Hafta sonu mu kontrol et
                if (selectedDate.DayOfWeek == DayOfWeek.Saturday || selectedDate.DayOfWeek == DayOfWeek.Sunday)
                {
                    MessageBox.Show("Hafta sonları seçilemez.");
                    // Varsayılan tarihi bugünkü tarih yap
                    tarih.Value = DateTime.Today;
                }
                // 30 gün sonrası mı kontrol et
                else if (selectedDate > DateTime.Today.AddDays(30))
                {
                    MessageBox.Show("Sistemin tarihinden 30 gün sonrasından daha ileri bir tarih seçilemez.");
                    // Varsayılan tarihi bugünkü tarih yap
                    tarih.Value = DateTime.Today;
                }
            };
        }



        private void rbKampanya_CheckedChanged(object sender, EventArgs e)
        {

            lbFiyat.Visible = false;
            lbHizmetinAdi.Visible = false;
            labelfiyatadi.Visible = false;
            lbKampanya.Visible = true;
            cbxkampanyalar.Visible = true;
            cbxHizmetler.SelectedIndex = -1;
            lbHizmet.Visible = false;
            cbxHizmetler.Visible = false;
            KampanyaYadaHizmetMi = true;//--> kampanya seçerse true atarım ve eklenen listeye kampanya girelenir
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            lbFiyat.Visible = false;
            labelfiyatadi.Visible = false;
            lbHizmetinAdi.Visible = false;
            lbHizmet.Visible = true;
            cbxHizmetler.Visible = true;
            cbxkampanyalar.SelectedIndex = -1;
            lbKampanya.Visible = false;
            cbxkampanyalar.Visible = false;
            KampanyaYadaHizmetMi = false;//--> hizmet seçerse false atarım ve eklenen listeye hizmet girelenir

        }
        private void BilgilerGosterHizmet()
        {
            lbFiyat.Visible = true;
            labelfiyatadi.Visible = true;
            lbHizmetinAdi.Visible = true;
            lbFiyat.Text = Fiyat.ToString() + "TL";
            lbHizmetinAdi.Text = cbxHizmetler.Items[cbxHizmetler.SelectedIndex].ToString();

            Color color2 = SelectThemeColor();
            lbHizmetinAdi.BackColor = color2;
            lbFiyat.BackColor = color2;
            labelfiyatadi.BackColor = color2;
        }
        private void BilgilerGosterKampanya()
        {
            lbFiyat.Visible = true;
            labelfiyatadi.Visible = true;
            lbHizmetinAdi.Visible = true;
            lbFiyat.Text = Fiyat.ToString() + "TL";
            lbHizmetinAdi.Text = cbxkampanyalar.Items[cbxkampanyalar.SelectedIndex].ToString();

            Color color2 = SelectThemeColor();
            lbHizmetinAdi.BackColor = color2;
            lbFiyat.BackColor = color2;
            labelfiyatadi.BackColor = color2;
        }

        private void cbxHizmetler_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxHizmetler.SelectedIndex)
            {
                case 0:
                    Fiyat = 350;//Yüz Temizleme
                    BilgilerGosterHizmet();
                    break;
                case 1:
                    Fiyat = 200;// Buhar
                    BilgilerGosterHizmet();

                    break;
                case 2:
                    Fiyat = 600;//Masaj
                    BilgilerGosterHizmet();
                    break;
                case 3:
                    Fiyat = 200;//Gündelik Makyaj
                    BilgilerGosterHizmet();
                    break;
                case 4:
                    Fiyat = 400;//Özel Etkinlikler
                    BilgilerGosterHizmet();
                    break;
                case 5:
                    Fiyat = 1500;//Gelin Makyajı:
                    BilgilerGosterHizmet();
                    break;
                case 6:
                    Fiyat = 750;//Kesim
                    BilgilerGosterHizmet();
                    break;
                case 7:
                    Fiyat = 400;//Renklendirme
                    BilgilerGosterHizmet();
                    break;
                case 8:
                    Fiyat = 350;//Perma
                    BilgilerGosterHizmet();
                    break;
                case 9:
                    Fiyat = 600;//Tırnak Bakımı
                    BilgilerGosterHizmet();
                    break;
                case 10:
                    Fiyat = 500;//Cila Uygulamaları
                    BilgilerGosterHizmet();
                    break;
                case 11:
                    Fiyat = 600;//Topuk Bakımı
                    BilgilerGosterHizmet();
                    break;
                case 12:
                    Fiyat = 850;//Epilasyon
                    BilgilerGosterHizmet();
                    break;
                case 13:
                    Fiyat = 900;//Ağda
                    BilgilerGosterHizmet();
                    break;
                case 14:
                    Fiyat = 900;// Vücut Peelingi
                    BilgilerGosterHizmet();
                    break;
                case 15:
                    Fiyat = 1200;//Vücut Masajı:
                    BilgilerGosterHizmet();
                    break;
                case 16:
                    Fiyat = 750;//Sırt Masajı
                    BilgilerGosterHizmet();
                    break;
                case 17:
                    Fiyat = 500;//Aromaterapi Masajı
                    BilgilerGosterHizmet();
                    break;
                case 18:
                    Fiyat = 400;//Kaş Şekillendirme
                    BilgilerGosterHizmet();
                    break;
                case 19:
                    Fiyat = 500;//Kaş Boyama
                    BilgilerGosterHizmet();
                    break;
                case 20:
                    Fiyat = 850;// Kirpik Kıvırma Ve Uzatma
                    BilgilerGosterHizmet();
                    break;
                case 21:
                    Fiyat = 600;//Solaryum
                    BilgilerGosterHizmet();
                    break;
                case 22:
                    Fiyat = 1750;//Bronzlaşma
                    BilgilerGosterHizmet();
                    break;
                case 23:
                    Fiyat = 950;//Doğal bronzlaşma maskeleri
                    BilgilerGosterHizmet();
                    break;
                case 24:
                    Fiyat = 1000;// danisma
                    BilgilerGosterHizmet();
                    break;


            }



        }

        private void cbxkampanyalar_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbxkampanyalar.SelectedIndex)
            {
                case 0://Cilt Bakımı(tüm hizmetleri) + Gündelik Makyaj + Tırnak Bakımı
                    Fiyat = 1560;
                    BilgilerGosterKampanya();

                    break;
                case 1://Paket 2: Masaj Terapisi + Kaş Şekillendirme + Güneşlenme ve Bronzlaşma
                    Fiyat = 2680;
                    BilgilerGosterKampanya();
                    break;
                case 2://Paket 3: Epilasyon ve Ağda + Saç Bakımı + Özel Etkinlikler İçin Makyaj
                    Fiyat = 2640;
                    BilgilerGosterKampanya();
                    break;
                case 3://Paket 4: Kaş ve Kirpik Bakımı + Manikür ve Pedikür + Doğal bronzlaşma maskeleri
                    Fiyat = 6240;
                    BilgilerGosterKampanya();
                    break;
                case 4://Paket 5: Vücut Masajı + Masaj ve Maske Uygulaması + Gelin Makyajı
                    Fiyat = 2760;
                    BilgilerGosterKampanya();
                    break;
                case 5://Paket 6: Sırt Masajı + Renklendirme + Topuk Bakımı
                    Fiyat = 1760;
                    BilgilerGosterKampanya();
                    break;
                case 6:
                    Fiyat = 5340;
                    BilgilerGosterKampanya();
                    break;
                case 7:
                    Fiyat = 2400;
                    BilgilerGosterKampanya();
                    break;
                case 8:
                    Fiyat = 3560;
                    BilgilerGosterKampanya();
                    break;
                case 9:
                    Fiyat = 2495;
                    BilgilerGosterKampanya();
                    break;
                case 10:
                    Fiyat = 3699;
                    BilgilerGosterKampanya();
                    break;
                case 11:
                    Fiyat = 4520;
                    BilgilerGosterKampanya();
                    break;
                case 12:
                    Fiyat = 2690;
                    BilgilerGosterKampanya();
                    break;
                case 13:
                    Fiyat = 4890;
                    BilgilerGosterKampanya();
                    break;
                case 14:
                    Fiyat = 1899;
                    BilgilerGosterKampanya();
                    break;
                case 15:
                    Fiyat = 2700;
                    BilgilerGosterKampanya();
                    break;
            }

        }



        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
            cbxRandevuSaati.Enabled = true;

        }

        private void cbxRandevuSaati_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }
      

        private void btnRandevuEkle_Click_1(object sender, EventArgs e)
        {
            var manager = clsPersonelManager.Instance;

            // Seçilen tarihi ve personel indeksini alıyoruz.
            var selectedDate = dateTimePicker1.Value.Date;
            var selectedPersonelIndex = cbxPersonelSecme.SelectedIndex;

            // Seçilen tarih ve personel için randevu durumunu alıyoruz veya yeni bir randevu durumu oluşturuyoruz.
            var randevuDurumu = manager.GetOrCreateRandevuDurumu(selectedDate, selectedPersonelIndex);
            if (EskiYeniMusterimi)
            {
                if (cbxMusteriler.SelectedIndex == -1 || (cbxHizmetler.SelectedIndex == -1 && cbxkampanyalar.SelectedIndex == -1) || cbxPersonelSecme.SelectedIndex == -1)
                {
                    MessageBox.Show("Lütfen tüm istenen alanları doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Seçilen randevu saati geçerli mi kontrol ediliyor
                    if (cbxRandevuSaati.SelectedIndex >= 0 && cbxRandevuSaati.SelectedIndex < randevuDurumu.SaatDurumlari.Count)
                    {
                        if (!randevuDurumu.SaatDurumlari[cbxRandevuSaati.SelectedIndex])
                        {
                            MessageBox.Show("Bu randevu saati zaten dolu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        var selectedMusteri = cbxMusteriler.SelectedItem as clsRandevusuzMusteri;
                        if (selectedMusteri == null)
                        {
                            MessageBox.Show("Geçersiz müşteri seçimi.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string secilen = KampanyaYadaHizmetMi ? cbxkampanyalar.SelectedItem.ToString() : cbxHizmetler.SelectedItem.ToString();
                        clsMusteriManager.Instance.LsMusteriler.Add(new clsMusteri(
                            selectedMusteri.Adi,
                            selectedMusteri.Soyadi,
                            selectedMusteri.Telefon_numara,
                            secilen,
                            cbxPersonelSecme.SelectedItem.ToString(),
                            dateTimePicker1.Value,
                            cbxRandevuSaati.SelectedItem.ToString(), lbFiyat.Text));
                        dataGridView1.DataSource = clsMusteriManager.Instance.LsMusteriler.ToList();

                        MessageBox.Show("Yeni Randevu Eklendi", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        randevuDurumu.SaatDurumlari[cbxRandevuSaati.SelectedIndex] = false;

                        // Formu sıfırla
                        txtAd.Text = "";
                        txtSoyAd.Text = "";
                        txtTel.Text = "";
                        dateTimePicker1.Value = DateTime.Now;
                        cbxHizmetler.SelectedIndex = -1;
                        cbxPersonelSecme.SelectedIndex = -1;
                        cbxRandevuSaati.SelectedIndex = -1;
                        lbFiyat.Visible = false;
                        labelfiyatadi.Visible = false;
                        lbHizmetinAdi.Visible = false;
                        lbKampanya.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Geçersiz randevu saati.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                if (txtAd.Text == "" || txtSoyAd.Text == "" || txtTel.Text == "" || (cbxHizmetler.SelectedIndex == -1 && cbxkampanyalar.SelectedIndex == -1) || cbxPersonelSecme.SelectedIndex == -1)
                {
                    MessageBox.Show("Lütfen tüm istenen alanları doldurunuz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (cbxRandevuSaati.SelectedIndex >= 0 && cbxRandevuSaati.SelectedIndex < randevuDurumu.SaatDurumlari.Count)
                    {
                        if (!randevuDurumu.SaatDurumlari[cbxRandevuSaati.SelectedIndex])
                        {
                            MessageBox.Show("Bu randevu saati zaten dolu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        string secilen = KampanyaYadaHizmetMi ? cbxkampanyalar.SelectedItem.ToString() : cbxHizmetler.SelectedItem.ToString();
                        clsMusteriManager.Instance.LsMusteriler.Add(new clsMusteri(
                            txtAd.Text,
                            txtSoyAd.Text, 
                            txtTel.Text,
                            secilen,
                            cbxPersonelSecme.SelectedItem.ToString(), 
                            dateTimePicker1.Value,
                            cbxRandevuSaati.SelectedItem.ToString(),
                            lbFiyat.Text));
                        dataGridView1.DataSource = clsMusteriManager.Instance.LsMusteriler.ToList();

                        MessageBox.Show("Yeni Randevu Eklendi", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                        randevuDurumu.SaatDurumlari[cbxRandevuSaati.SelectedIndex] = false;

                        // Formu sıfırla
                        txtAd.Text = "";
                        txtSoyAd.Text = "";
                        txtTel.Text = "";
                        dateTimePicker1.Value = DateTime.Now;
                        cbxHizmetler.SelectedIndex = -1;
                        cbxPersonelSecme.SelectedIndex = -1;
                        cbxRandevuSaati.SelectedIndex = -1;
                        lbFiyat.Visible = false;
                        labelfiyatadi.Visible = false;
                        lbHizmetinAdi.Visible = false;
                        lbKampanya.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Geçersiz randevu saati.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void menuPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbxPersonelSecme_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxPersonelSecme.SelectedIndex >= 0 && cbxPersonelSecme.SelectedIndex < clsPersonelManager.Instance.LsCalisanlar.Count)
            {
                dateTimePicker1.Enabled = true;
                clsPersonelManager manager = clsPersonelManager.Instance;
                cbxRandevuSaati.Items.Clear();
                var selectedPersonel = manager.LsCalisanlar[cbxPersonelSecme.SelectedIndex];

                if (selectedPersonel.BirinciRandevu)
                {
                    cbxRandevuSaati.Items.Add("09:00 - 10:00");
                }
                if (selectedPersonel.İkiinciRandevu)
                {
                    cbxRandevuSaati.Items.Add("10:00 - 11:00");
                }
                if (selectedPersonel.UcuncuRandevu)
                {
                    cbxRandevuSaati.Items.Add("11:00 - 12:00");
                }
                if (selectedPersonel.DorduncuRandevu)
                {
                    cbxRandevuSaati.Items.Add("13:00 - 14:00");
                }

                if (cbxRandevuSaati.Items.Count == 0)
                {
                    cbxRandevuSaati.Items.Add("Müsait randevu yok");
                }
            }
        }

        private void rbtnYeni_CheckedChanged(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel4.Visible = false;

            //cbxMusteriler.SelectedIndex = -1;

            EskiYeniMusterimi = false;//--> yeniMusteri Ekleme Seçildi
        }

        private void rbtnEski_CheckedChanged(object sender, EventArgs e)
        {

            panel1.Visible = false;
            panel4.Visible = true;

            //cbxMusteriler.SelectedIndex = -1;

            EskiYeniMusterimi = true;//--> yeniMusteri Ekleme Seçildi

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            
        }
        bool deneme;
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            deneme = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var gunlukMaliyetler = clsMusteriManager.Instance.GetGunlukMaliyetler();

            StringBuilder sb = new StringBuilder();
            foreach (var maliyet in gunlukMaliyetler)
            {
                sb.AppendLine($"{maliyet.Key.ToShortDateString()}: {maliyet.Value} TL");
            }

            MessageBox.Show(sb.ToString(), "Günlük Maliyetler", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}