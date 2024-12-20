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
                               cmbKalkisSehirler.Items.Add(dr["ad"].ToString()+"         --> " + dr["sehir_id"].ToString());
                               cmbVarisSehirler.Items.Add(dr["ad"].ToString() + "         --> " + dr["sehir_id"].ToString());
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
    }
}
