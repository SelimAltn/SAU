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

namespace RandevuSistemi.Resources
{
    public partial class frmRandevuİptal : Form
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
        public frmRandevuİptal()
        {
            InitializeComponent();
        }

        private void frmRandevuİptal_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            // clsMusteriManager.Instance.LsMusteriler özelliğine erişerek müşteri listesine ulaşabiliriz
            BindingList<clsMusteri> musteriler = clsMusteriManager.Instance.LsMusteriler;

            // DataGridView kontrolüne müşteri listesini bağlayabiliriz
            dataGridView1.DataSource = musteriler.ToList();

            //renk seçimi 
            random = new Random();
            Color color1 = SelectThemeColor();
            btnRandevuDüzenle.BackColor = color1;
            lb.BackColor = color1;
        }

        private void btnRandevuDüzenle_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Seçilen satırı al
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Seçilen satırdaki müşteri nesnesini al
                clsMusteri selectedMusteri = (clsMusteri)selectedRow.DataBoundItem;

                // İptal işlemini gerçekleştir
                DialogResult result = MessageBox.Show($"Seçilen randevuyu iptal etmek istediğinizden emin misiniz?\nAdı: {selectedMusteri.Adi}\nSoyadı: {selectedMusteri.Soyadi}\nTelefon: {selectedMusteri.Telefon_numara}\nHizmet: {selectedMusteri.Hizmet}\nRandevu Tarihi: {selectedMusteri.RandevuTarihi}",
                                                        "Randevu İptali", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // İptal işlemi burada gerçekleştirilir
                    clsMusteriManager.Instance.LsMusteriler.Remove(selectedMusteri); // Seçilen müşteriyi listeden kaldır
                    dataGridView1.DataSource = clsMusteriManager.Instance.LsMusteriler.ToList(); // DataGridView'i güncelle

                    // İlgili personelin saat durumunu güncelle
                    clsPersonelManager.Instance.UpdateRandevuDurumu(selectedMusteri.RandevuTarihi.Date,
                        clsPersonelManager.Instance.LsCalisanlar.IndexOf(
                            clsPersonelManager.Instance.LsCalisanlar.FirstOrDefault(c => c.Adi == selectedMusteri.Personel)),
                        GetSaatIndex(selectedMusteri.Saat), true);

                    MessageBox.Show("Randevu iptal edildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Lütfen iptal edilecek bir randevu seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
    }
}