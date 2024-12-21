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
    public partial class seferAra : Form
    {
        public seferAra()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }
        private string baglanti = "server=localHost; port=5432; Database=Biletim; user ID=postgres; password=123456";

        private void seferAra_Load(object sender, EventArgs e)
        {
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
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            
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

        private void btnGiris_Click(object sender, EventArgs e)
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
            }
            else
            {
                MessageBox.Show("Uygun sefer bulunamadı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = null;
            }
            // Uygun seferleri arama işlemleri burada gerçekleştirilecek...
        }
    }
}
