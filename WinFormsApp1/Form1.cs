using Npgsql;
using System.Data;

namespace WinFormsApp1
{
    public partial class Biletim : Form
    {
        public Biletim()
        {
            InitializeComponent();
        }
        NpgsqlConnection baglanti = new NpgsqlConnection("server=localHost; port=5432; Database=Biletim; user ID=postgres; password=123456");
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panelUst_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        ///---------------------------------------------------
        ///------------- Panel iÁinde alt formu aÁar
        ///-------------------------------------------------------
        private Form activeForm;  // Aktif alt formu takip eder
        private void AltFormAcPanel›cinde(Form childForm, object btnSender)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelFormlar.Controls.Add(childForm);
            this.panelFormlar.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }
        private void btnKullanciGirisi_Click(object sender, EventArgs e)
        {
            AltFormAcPanel›cinde(new KullanciGiri˛Kontrolu(), sender);
        }

        private void btnYeniKullanci_Click(object sender, EventArgs e)
        {
            AltFormAcPanel›cinde(new YeniHesapOlustur(), sender);
        }

        private void btnKampanyalar_Click(object sender, EventArgs e)
        {
            AltFormAcPanel›cinde(new Kampanyalar(), sender);

        }

        private void btnSeferAra_Click(object sender, EventArgs e)
        {
            AltFormAcPanel›cinde(new seferAra(), sender);

        }
    }
}
