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
    public partial class Kampanyalar : Form
    {

        public Kampanyalar()
        {
            InitializeComponent();
        }
        private string baglanti = "server=localHost; port=5432; Database=Biletim; user ID=postgres; password=123456";

        private void Kampanyalar_Load(object sender, EventArgs e)
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void Kampanyalar_Load_1(object sender, EventArgs e)
        {
            try
            {
                // PostgreSQL sorgusunu çalıştır.
                string sorgu = "select * from kampanyalar";
                using (NpgsqlConnection con = new NpgsqlConnection(baglanti))
                {
                    con.Open();
                    NpgsqlDataAdapter da = new NpgsqlDataAdapter(sorgu, con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);

                    // DataGridView'e verileri aktar.
                    dataGridView1.DataSource = ds.Tables[0];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message);
            }
        }
    }
}
