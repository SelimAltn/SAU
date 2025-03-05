using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
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
        private int aktifKullaniciId = -1; // Global değişken olarak tanımlayın

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
                aktifKullaniciId = KullaniciGirisKontrolu(kullaniciAdi, sifre);
                // Burada kullanıcı ID'yi saklayabilir veya başka bir formu açabilirsiniz
                panelMenu.Visible = true;
                groupBox1.Visible = false;
                string kullanciAdSoyad = KullaniciAdSoyadGetir(aktifKullaniciId);
                lbKullanciAdi.Text = "Hoş geldin " + kullanciAdSoyad;



            }
            catch (Exception ex)
            {
                MessageBox.Show($"Giriş başarısız: {ex.Message}");
            }
        }
        private DataTable GetUygunSeferler(int kalkisSehirID, int varisSehirID, DateTime aramaTarihi)
        {
            DataTable dataTable = new DataTable();

            using (var connection = new NpgsqlConnection(baglanti))
            {
                try
                {
                    connection.Open();

                    // Fonksiyon çağrısı için SQL komutu
                    string query = "SELECT * FROM UygunSeferler(@kalkis, @varis, @aramaTarihi)";
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        // Parametreler
                        command.Parameters.AddWithValue("@kalkis", NpgsqlTypes.NpgsqlDbType.Integer, kalkisSehirID);
                        command.Parameters.AddWithValue("@varis", NpgsqlTypes.NpgsqlDbType.Integer, varisSehirID);
                        command.Parameters.AddWithValue("@aramaTarihi", NpgsqlTypes.NpgsqlDbType.Date, aramaTarihi);

                        // Veri okuyucu
                        using (var reader = command.ExecuteReader())
                        {
                            dataTable.Load(reader);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return dataTable;
        }
        private bool KontrolSeferID(int kalkisSehirID, int varisSehirID, DateTime aramaTarihi, int secilenSeferID)
        {
            bool sonuc = false;

            using (var connection = new NpgsqlConnection(baglanti))
            {
                try
                {
                    connection.Open();

                    // Fonksiyon çağrısı için SQL komutu
                    string query = "SELECT KontrolSeferID(@kalkis, @varis, @aramaTarihi, @secilenSeferID)";
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        // Parametreleri ekle
                        command.Parameters.AddWithValue("@kalkis", NpgsqlTypes.NpgsqlDbType.Integer, kalkisSehirID);
                        command.Parameters.AddWithValue("@varis", NpgsqlTypes.NpgsqlDbType.Integer, varisSehirID);
                        command.Parameters.AddWithValue("@aramaTarihi", NpgsqlTypes.NpgsqlDbType.Date, aramaTarihi);
                        command.Parameters.AddWithValue("@secilenSeferID", NpgsqlTypes.NpgsqlDbType.Integer, secilenSeferID);

                        // Fonksiyonun sonucunu al
                        sonuc = (bool)command.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return sonuc;
        }


        private void btnSeferAra_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            label5.Text = "Aramak istediniz sefer bilgileri gieeriniz";
            button1.Visible = true;
            btnBilet_degistir.Visible = false;
            btnBiletİptali.Visible = false;
            button2.Visible = true;
            button3.Visible = false;
            dataGridView1.Visible = false;
            groupBox2.Visible = false;
            button2.Text = "Rezervasyon yap";
            txtUygunSeferId.Text = "";
            try
            {
                // PostgreSQL bağlantısı aç
                using (NpgsqlConnection con = new NpgsqlConnection(baglanti))
                {
                    con.Open();

                    // Şehir adlarını alacak SQL sorgusu
                    string sorgu = "SELECT ad FROM sehirler"; // Şehirlerin tutulduğu tablo adı 'sehirler' v

                    using (NpgsqlCommand cmd = new NpgsqlCommand(sorgu, con))
                    {
                        using (NpgsqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                // Şehir adını ComboBox'a ekle
                                cmbKalkisSehirler.Items.Add(dr["ad"].ToString());
                                cmbVarisSehirler.Items.Add(dr["ad"].ToString());

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
            gboxSefer.Visible = true;


        }

        private void btnSeferlerimGoruntule_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            groupBox3.Visible = false;
            btnBilet_degistir.Visible = false;
            gboxSefer.Visible = false;
            button3.Visible = false;
            dataGridView1.Visible = true;
            groupBox2.Visible = false;
            button2.Visible = false;
            btnBiletİptali.Visible = false;
            button1.Visible = false;
            // Kullanıcı ID ve Şikayet Metni alınır
            try
            {
                using (var connection = new NpgsqlConnection(baglanti))
                {
                    connection.Open();

                    using (var command = new NpgsqlCommand("SELECT * FROM kullaniciya_ait_biletler(@kullanici_id)", connection))
                    {
                        command.Parameters.AddWithValue("@kullanici_id", aktifKullaniciId);

                        // Sorguyu çalıştır ve sonucu al
                        using (var reader = command.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            // DataGridView'e veri kaynağı olarak ata
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Kalkış şehri seçildi mi?
            if (cmbKalkisSehirler.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen kalkış şehrini seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Varış şehri seçildi mi?
            if (cmbVarisSehirler.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen varış şehrini seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kalkış ve varış şehirleri aynı mı?
            if (cmbKalkisSehirler.SelectedIndex == cmbVarisSehirler.SelectedIndex)
            {
                MessageBox.Show("Kalkış şehri ile varış şehri aynı olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tarih bugünden veya daha sonraki bir tarihte mi?
            if (dateTimePicker1.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Lütfen bugünün veya daha sonraki bir tarihi seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Seyahat türü seçildi mi?
            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked)
            {
                MessageBox.Show("Lütfen bir seyahat türü seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Eğer tüm kontroller doğruysa, uygun seferleri ara
            MessageBox.Show("Uygun seferler aranıyor...", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dataGridView1.Visible = true;
            // Parametreleri al
            int kalkisSehirID = cmbKalkisSehirler.SelectedIndex + 1; // ID mantığınıza göre güncelleyebilirsiniz
            int varisSehirID = cmbVarisSehirler.SelectedIndex + 1;
            DateTime aramaTarihi = dateTimePicker1.Value.Date;
            string formattedDate = aramaTarihi.ToString("yyyy-MM-dd");


            // Uygun seferleri getir
            DataTable seferler = GetUygunSeferler(kalkisSehirID, varisSehirID, DateTime.Parse(formattedDate));

            // Sonuçları DataGridView'e bağla
            if (seferler.Rows.Count > 0)
            {
                dataGridView1.DataSource = seferler;
                groupBox2.Visible = true;
            }
            else
            {
                MessageBox.Show("Uygun sefer bulunamadı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = null;
            }
            // Uygun seferleri arama işlemleri burada gerçekleştirilecek...
        }


        private void txtKullaniciID_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Eğer basılan tuş bir rakam değilse ve geri al (Backspace) değilse
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Tuşu kabul etme
            }
        }

        private void RezervasyonEkle(int kullaniciId, int seferId)
        {
            using (var connection = new NpgsqlConnection(baglanti))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT ekle_rezervasyon(@kullanici_id, @sefer_id)";
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@kullanici_id", kullaniciId);
                        command.Parameters.AddWithValue("@sefer_id", seferId);

                        command.ExecuteNonQuery(); // Sorguyu çalıştır
                        MessageBox.Show("Rezervasyon başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Rezervasyon ekleme sırasında bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {

            int secilenSeferID;
            // Kullanıcının girdiği SeferID'yi al ve doğrula
            if (!int.TryParse(txtUygunSeferId.Text, out secilenSeferID))
            {
                MessageBox.Show("Lütfen geçerli bir Sefer ID giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int kalkisSehirID = cmbKalkisSehirler.SelectedIndex + 1; // ID mantığınıza göre güncelleyebilirsiniz
            int varisSehirID = cmbVarisSehirler.SelectedIndex + 1;
            DateTime aramaTarihi = dateTimePicker1.Value.Date;
            // Kontrol işlemi
            bool sonuc = KontrolSeferID(kalkisSehirID, varisSehirID, aramaTarihi, secilenSeferID);

            // Sonuç mesajı
            if (sonuc)
            {
                MessageBox.Show($"Seçilen Sefer ID ({secilenSeferID}) uygun.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RezervasyonEkle(aktifKullaniciId, secilenSeferID); // Rezervasyon ekle
                dataGridView1.Visible = false;
                groupBox2.Visible = false;
                radioButton1.Checked = false;
                radioButton2.Checked = false;
                radioButton3.Checked = false;
                cmbKalkisSehirler.SelectedIndex = -1;
                cmbVarisSehirler.SelectedIndex = -1;
                txtUygunSeferId.Text = "";

            }
            else
            {
                MessageBox.Show($"Seçilen Sefer ID ({secilenSeferID}) uygun değil!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBiletAl_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            btnBilet_degistir.Visible = false;
            btnBiletİptali.Visible = false;
            gboxSefer.Visible = false;
            button3.Visible = true;
            dataGridView1.Visible = true;
            groupBox2.Visible = true;
            button2.Visible = false;
            label8.Text = "rezervasyon id :";
            DataTable dataTable = new DataTable();

            using (var connection = new NpgsqlConnection(baglanti))
            {
                try
                {
                    connection.Open();

                    string query = "SELECT * FROM get_rezervasyonlar(@kullaniciId)";
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        // Kullanıcı ID parametresini ekle
                        command.Parameters.AddWithValue("@kullaniciId", aktifKullaniciId);

                        using (var reader = command.ExecuteReader())
                        {
                            dataTable.Load(reader);
                        }
                    }

                    // DataGridView'e veriyi bağla
                    dataGridView1.DataSource = dataTable;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private bool KontrolRezervasyon(int rezervasyonId, int kullaniciId)
        {
            bool sonuc = false;
            using (var connection = new NpgsqlConnection(baglanti))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT kontrol_rezervasyon(@rezervasyon_id, @kullanici_id)";
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@rezervasyon_id", rezervasyonId);
                        command.Parameters.AddWithValue("@kullanici_id", kullaniciId);

                        sonuc = (bool)command.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
            return sonuc;
        }

        // Rezervasyonu bilete dönüştürme fonksiyonu
        private int RezervasyonuBileteDonustur(int rezervasyonId)
        {
            int biletId = 0;
            using (var connection = new NpgsqlConnection(baglanti))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT rezervasyonu_bilete_donustur(@rezervasyon_id)";
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@rezervasyon_id", rezervasyonId);

                        biletId = (int)command.ExecuteScalar();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
            return biletId;
        }


        // Bilet ödeme ekleme fonksiyonu
        private void BiletiOdemeyeEkle(int biletId, string odemeTuru)
        {
            using (var connection = new NpgsqlConnection(baglanti))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT bileti_odemeye_ekle(@bilet_id, @odeme_turu)";
                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@bilet_id", biletId);
                        command.Parameters.AddWithValue("@odeme_turu", odemeTuru);

                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int rezervasyonId;

            // Rezervasyon ID'nin geçerli olup olmadığını kontrol et
            if (!int.TryParse(txtUygunSeferId.Text, out rezervasyonId))
            {
                MessageBox.Show("Lütfen geçerli bir rezervasyon ID giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            bool rezervasyonGeçerli = KontrolRezervasyon(rezervasyonId, aktifKullaniciId);
            if (rezervasyonGeçerli)
            {
                // Rezervasyonu bilete dönüştür
                int biletId = RezervasyonuBileteDonustur(rezervasyonId);

                // Bilet ödemesini ekle
                string odemeTuru = "Kredi kart"; // cmbOdemeTuru bir ComboBox
                BiletiOdemeyeEkle(biletId, odemeTuru);

                // DataGridView'i güncelle
                btnBiletAl_Click(sender, e);
                txtUygunSeferId.Text = "";

                MessageBox.Show("Bilet ve ödeme işlemi başarıyla tamamlandı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Rezervasyon geçerli değil veya zaten ödenmiş.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void txtUygunSeferId_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            // Eğer basılan tuş bir rakam değilse ve geri al (Backspace) değilse
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true; // Tuşu kabul etme
            }
        }

        private void btnBiletiptalet_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            btnBilet_degistir.Visible = false;
            gboxSefer.Visible = false;
            button3.Visible = false;
            dataGridView1.Visible = true;
            groupBox2.Visible = true;
            button2.Visible = false;
            label8.Text = "Bilet id :";
            txtUygunSeferId.Text = "";
            btnBiletİptali.Visible = true;
            try
            {
                using (var connection = new NpgsqlConnection(baglanti))
                {
                    connection.Open();

                    using (var command = new NpgsqlCommand("SELECT * FROM kullaniciya_ait_biletler(@kullanici_id)", connection))
                    {
                        command.Parameters.AddWithValue("@kullanici_id", aktifKullaniciId);

                        // Sorguyu çalıştır ve sonucu al
                        using (var reader = command.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            // DataGridView'e veri kaynağı olarak ata
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnBiletİptali_Click(object sender, EventArgs e)
        {
            int rezervasyonId;

            // Rezervasyon ID'nin geçerli olup olmadığını kontrol et
            if (!int.TryParse(txtUygunSeferId.Text, out rezervasyonId))
            {
                MessageBox.Show("Lütfen geçerli bir rezervasyon ID giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (var connection = new NpgsqlConnection(baglanti))
                {
                    connection.Open();

                    using (var command = new NpgsqlCommand("SELECT bilet_iptali(@bilet_id, @kullanici_id)", connection))
                    {
                        command.Parameters.AddWithValue("@bilet_id", rezervasyonId);
                        command.Parameters.AddWithValue("@kullanici_id", aktifKullaniciId);

                        // Fonksiyonu çalıştır
                        command.ExecuteNonQuery();
                        btnBiletiptalet_Click(sender, e);
                        MessageBox.Show("Bilet ve ödeme başarıyla iptal edildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBiletDegistir_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = false;
            btnBilet_degistir.Visible = true;
            label5.Text = "yeni sefer bilgileriniz giriniz";
            gboxSefer.Visible = true;
            button3.Visible = false;
            dataGridView1.Visible = true;
            groupBox2.Visible = true;
            button2.Visible = false;
            label8.Text = "Bilet id :";
            txtUygunSeferId.Text = "";
            btnBiletİptali.Visible = false;
            button1.Visible = false;
            try
            {
                using (var connection = new NpgsqlConnection(baglanti))
                {
                    connection.Open();

                    using (var command = new NpgsqlCommand("SELECT * FROM kullaniciya_ait_biletler(@kullanici_id)", connection))
                    {
                        command.Parameters.AddWithValue("@kullanici_id", aktifKullaniciId);

                        // Sorguyu çalıştır ve sonucu al
                        using (var reader = command.ExecuteReader())
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            // DataGridView'e veri kaynağı olarak ata
                            dataGridView1.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnBilet_degistir_Click(object sender, EventArgs e)
        {
            int rezervasyonId;
            // Kalkış şehri seçildi mi?
            if (cmbKalkisSehirler.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen kalkış şehrini seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Varış şehri seçildi mi?
            if (cmbVarisSehirler.SelectedIndex == -1)
            {
                MessageBox.Show("Lütfen varış şehrini seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kalkış ve varış şehirleri aynı mı?
            if (cmbKalkisSehirler.SelectedIndex == cmbVarisSehirler.SelectedIndex)
            {
                MessageBox.Show("Kalkış şehri ile varış şehri aynı olamaz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tarih bugünden veya daha sonraki bir tarihte mi?
            if (dateTimePicker1.Value.Date < DateTime.Now.Date)
            {
                MessageBox.Show("Lütfen bugünün veya daha sonraki bir tarihi seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Seyahat türü seçildi mi?
            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked)
            {
                MessageBox.Show("Lütfen bir seyahat türü seçin!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Rezervasyon ID'nin geçerli olup olmadığını kontrol et
            if (!int.TryParse(txtUygunSeferId.Text, out rezervasyonId))
            {
                MessageBox.Show("Lütfen geçerli bir rezervasyon ID giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int kullaniciId = aktifKullaniciId; // Aktif kullanıcı ID'si
            int biletId = rezervasyonId; // Kullanıcının değiştirmek istediği bilet ID'si
            int yeniKalkisSehirId = cmbKalkisSehirler.SelectedIndex + 1; // Yeni kalkış şehir ID'si
            int yeniVarisSehirId = cmbVarisSehirler.SelectedIndex + 1; // Yeni varış şehir ID'si
            DateTime yeniSeferTarihi = dateTimePicker1.Value.Date; // Yeni sefer tarihi


            try
            {
                // PostgreSQL bağlantısını aç
                using (var connection = new NpgsqlConnection(baglanti))
                {
                    connection.Open();

                    // Fonksiyon çağrısı için SQL komutu
                    string query = "SELECT bilet_degistir(@kullanici_id, @bilet_id, @yeni_kalkis_sehir_id, @yeni_varis_sehir_id, @yeni_sefer_tarihi)";

                    using (var command = new NpgsqlCommand(query, connection))
                    {
                        // Parametreleri ekle
                        command.Parameters.AddWithValue("@kullanici_id", NpgsqlTypes.NpgsqlDbType.Integer, kullaniciId);
                        command.Parameters.AddWithValue("@bilet_id", NpgsqlTypes.NpgsqlDbType.Integer, biletId);
                        command.Parameters.AddWithValue("@yeni_kalkis_sehir_id", NpgsqlTypes.NpgsqlDbType.Integer, yeniKalkisSehirId);
                        command.Parameters.AddWithValue("@yeni_varis_sehir_id", NpgsqlTypes.NpgsqlDbType.Integer, yeniVarisSehirId);
                        command.Parameters.AddWithValue("@yeni_sefer_tarihi", NpgsqlTypes.NpgsqlDbType.Date, yeniSeferTarihi);

                        // Fonksiyonu çalıştır ve sonucu al
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Bilet başarıyla değiştirildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnBiletDegistir_Click(sender, e);


            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSeferinizDegerlendiriniz_Click(object sender, EventArgs e)
        {
            groupBox3.Visible = true;
            btnBilet_degistir.Visible = false;
            gboxSefer.Visible = false;
            button3.Visible = false;
            dataGridView1.Visible = false;
            groupBox2.Visible = false;
            button2.Visible = false;
            btnBiletİptali.Visible = false;
            button1.Visible = false;
            // Kullanıcı ID ve Şikayet Metni alınır





        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string sikayetMetni = richTextBox1.Text;
            if (string.IsNullOrWhiteSpace(sikayetMetni))
            {
                MessageBox.Show("Şikayet metni boş olamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            try
            {
                using (var connection = new NpgsqlConnection(baglanti))
                {
                    connection.Open();

                    // Fonksiyon çağrısı
                    using (var cmd = new NpgsqlCommand("SELECT SikayetEkle(@kullanici_id, @sikayet_metni);", connection))
                    {
                        cmd.Parameters.AddWithValue("kullanici_id", aktifKullaniciId);
                        cmd.Parameters.AddWithValue("sikayet_metni", sikayetMetni);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Şikayet başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        richTextBox1.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

     
    
        
    }
}