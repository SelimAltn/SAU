using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class YeniHesapOlustur : Form
    {
        public YeniHesapOlustur()
        {
            InitializeComponent();
        }

        private void YeniHesapOlustur_Load(object sender, EventArgs e)
        {

        }

        private void lbCalısanAdi1_Click(object sender, EventArgs e)
        {

        }
        private string baglanti = "server=localHost; port=5432; Database=Biletim; user ID=postgres; password=123456";
        private void ClearForm()
        {
            // Formdaki tüm metin kutularını temizler
            txtMusteriAdi.Text = string.Empty;
            txtMusteriSoyAdi.Text = string.Empty;
            txtMusteriGmaili.Text = string.Empty;
            textBox1.Text = string.Empty;
            txtMusteriSifre.Text = string.Empty;
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            string ad = txtMusteriAdi.Text;
            string soyad = txtMusteriSoyAdi.Text;
            string email = txtMusteriGmaili.Text;
            string telefon = textBox1.Text;
            string sifre = txtMusteriSifre.Text;

            // Gerekli alanların doldurulduğunu kontrol et
            if (string.IsNullOrWhiteSpace(ad))
            {
                MessageBox.Show("Lütfen adınızı giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(soyad))
            {
                MessageBox.Show("Lütfen soyadınızı giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(email))
            {
                MessageBox.Show("Lütfen e-posta adresinizi giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(telefon))
            {
                MessageBox.Show("Lütfen telefon numaranızı giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(sifre))
            {
                MessageBox.Show("Lütfen sifre  giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            try
            {
                using (NpgsqlConnection con = new NpgsqlConnection(baglanti))
                {
                    con.Open();

                    using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT ekle_kullanici(@ad, @soyad, @email, @Kullancici_Sifre, @telefon)", con))
                    {
                        cmd.Parameters.AddWithValue("ad", ad);
                        cmd.Parameters.AddWithValue("soyad", soyad);
                        cmd.Parameters.AddWithValue("email", email);
                        cmd.Parameters.AddWithValue("Kullancici_Sifre", sifre);
                        cmd.Parameters.AddWithValue("telefon", telefon);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Kullanıcı başarıyla kaydedildi!");
                // Formu temizle
                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message);
            }
        }
    }
}
