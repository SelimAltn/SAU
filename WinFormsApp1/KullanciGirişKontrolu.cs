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
using static System.Windows.Forms.DataFormats;

namespace WinFormsApp1
{
    public partial class KullanciGirişKontrolu : Form
    {
        public KullanciGirişKontrolu()
        {
            InitializeComponent();
        }

        private void KullanciGirişKontrolu_Load(object sender, EventArgs e)
        {

        }

        private void lbBaslik_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private string baglanti = "server=localHost; port=5432; Database=Biletim; user ID=postgres; password=123456";

        private int KullaniciGirisKontrolu(string kullaniciAdi, string sifre)
        {
            int kullaniciId = -1; // Varsayılan olarak geçersiz ID

            using (NpgsqlConnection conn = new NpgsqlConnection(baglanti))
            {
                conn.Open(); // Veritabanı bağlantısını aç
                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT get_kullanici_id(@kullaniciAdi, @sifre)", conn))
                {
                    // Parametreleri ekle
                    cmd.Parameters.AddWithValue("kullaniciAdi", kullaniciAdi);
                    cmd.Parameters.AddWithValue("sifre", sifre);

                    try
                    {
                        object result = cmd.ExecuteScalar(); // Sorgu sonucunu al
                        if (result != DBNull.Value && result != null)
                        {
                            kullaniciId = Convert.ToInt32(result); // Kullanıcı ID'sini al
                        }
                        else
                        {
                            throw new Exception("Kullanıcı adı veya şifre hatalı.");
                        }
                    }
                    catch (PostgresException ex)
                    {
                        throw new Exception($"Veritabanı hatası: {ex.Message}");
                    }
                }
            }

            return kullaniciId;
        }
        private string KullaniciAdSoyadGetir(int kullaniciId)
        {
            string adSoyad = string.Empty;

            using (NpgsqlConnection conn = new NpgsqlConnection(baglanti))
            {
                conn.Open();
                using (NpgsqlCommand cmd = new NpgsqlCommand("SELECT ad, soy_ad FROM kullanicilar WHERE kullanici_id = @kullaniciId", conn))
                {
                    cmd.Parameters.AddWithValue("@kullaniciId", kullaniciId);

                    using (NpgsqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string ad = reader["ad"].ToString();
                            string soyAd = reader["soy_ad"].ToString();
                            adSoyad = $"{ad} {soyAd}";
                        }
                        else
                        {
                            throw new Exception("Kullanıcı bulunamadı.");
                        }
                    }
                }
            }

            return adSoyad;
        }
        private void btnGiris_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = txtKullanciAdi.Text; // Formdan kullanıcı adını al
            string sifre = txtSifre.Text; // Formdan şifreyi al
            if (string.IsNullOrWhiteSpace(kullaniciAdi))
            {
                MessageBox.Show("Lütfen kullanıcı Adı giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(sifre))
            {
                MessageBox.Show("Lütfen Şifrenizi giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                int kullaniciId = KullaniciGirisKontrolu(kullaniciAdi, sifre);
                // Burada kullanıcı ID'yi saklayabilir veya başka bir formu açabilirsiniz
                panelMenu.Visible = true;
                groupBox1.Visible = false;
                string kullanciAdSoyad = KullaniciAdSoyadGetir(kullaniciId);
                lbKullanciAdi.Text = kullanciAdSoyad;



            }
            catch (Exception ex)
            {
                MessageBox.Show($"Giriş başarısız: {ex.Message}");
            }
        }
    }
}
