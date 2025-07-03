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
    public partial class frmRandevuDuzenle : Form
    {
        public frmRandevuDuzenle()
        {
            InitializeComponent();
        }

        private void frmRandevuDuzenle_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            // clsMusteriManager.Instance.LsMusteriler özelliğine erişerek müşteri listesine ulaşabiliriz
            BindingList<clsMusteri> musteriler = clsMusteriManager.Instance.LsMusteriler;

            // DataGridView kontrolüne müşteri listesini bağlayabiliriz
            dataGridView1.DataSource = musteriler.ToList();
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
        }
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
        private void button1_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Seçilen satırı al
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Seçilen satırdaki müşteri nesnesini al
                clsMusteri selectedMusteri = (clsMusteri)selectedRow.DataBoundItem;



                string personelAd;

                var manager = clsPersonelManager.Instance;
                var selectedDate = dateTimePicker1.Value.Date;
                var selectedPersonelIndex = cbxPersonelSecme.SelectedIndex;

                var randevuDurumu = manager.GetOrCreateRandevuDurumu(selectedDate, selectedPersonelIndex);


                // İptal işlemini gerçekleştir
                DialogResult result = MessageBox.Show($"Seçilen randevuyu duzenlemek etmek istediğinizden emin misiniz?\nAdı: {selectedMusteri.Adi}\nSoyadı: {selectedMusteri.Soyadi}\nTelefon: {selectedMusteri.Telefon_numara}\nHizmet: {selectedMusteri.Hizmet}\nRandevu Tarihi: {selectedMusteri.RandevuTarihi}",
                                                        "Randevu duzenle", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // İptal işlemi burada gerçekleştirilir
                    clsMusteriManager.Instance.LsMusteriler.Remove(selectedMusteri); // Seçilen müşteriyi listeden kaldır

                    if (cbxPersonelSecme.SelectedIndex==-1||cbxRandevuSaati.SelectedIndex==-1)
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

                         

                                clsMusteriManager.Instance.LsMusteriler.Add(new clsMusteri(
                                selectedMusteri.Adi,
                                selectedMusteri.Soyadi,
                                selectedMusteri.Telefon_numara,
                                selectedMusteri.Hizmet,
                                cbxPersonelSecme.SelectedItem.ToString(),
                                dateTimePicker1.Value,
                                cbxRandevuSaati.SelectedItem.ToString(), selectedMusteri.Maliyet));

                           

                            // Formu sıfırla
                            
                            dateTimePicker1.Value = DateTime.Now;
                           
                            cbxPersonelSecme.SelectedIndex = -1;
                            cbxRandevuSaati.SelectedIndex = -1;
                            dateTimePicker1.Enabled = false;
                            cbxRandevuSaati.Enabled = false;

                            dataGridView1.DataSource = clsMusteriManager.Instance.LsMusteriler.ToList(); // DataGridView'i güncelle
                                                                                                         // İlgili personelin saat durumunu güncelle
                            clsPersonelManager.Instance.UpdateRandevuDurumu(selectedMusteri.RandevuTarihi.Date,
                                clsPersonelManager.Instance.LsCalisanlar.IndexOf(
                                    clsPersonelManager.Instance.LsCalisanlar.FirstOrDefault(c => c.Adi == selectedMusteri.Personel)),
                                GetSaatIndex(selectedMusteri.Saat), true);

                            MessageBox.Show("Randevu duzenleme edildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("Geçersiz randevu saati.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }






                 
                }
            }
            else
            {
                MessageBox.Show("Lütfen duzenleme edilecek bir randevu seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private int GetSaatIndex(string randevuSaati)
        {
            switch (randevuSaati)
            {
                case "09:00 - 10:00":
                    return 0;
                case "10:00 - 11:00":
                    return 1;
                case "11:00 - 12:00":
                    return 2;
                case "13:00 - 14:00":
                    return 3;
                default:
                    return -1;
            }
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

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            cbxRandevuSaati.Enabled = true;
        }
    }
}
