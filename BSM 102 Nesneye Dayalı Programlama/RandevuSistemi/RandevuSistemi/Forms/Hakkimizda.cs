using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandevuSistemi
{
    public partial class Hakkimizda : Form
    {
        public Hakkimizda()
        {
            InitializeComponent();
        }

        private void Hakkimizda_Load(object sender, EventArgs e)
        {
            LoadTheme();
            pic1.Visible = true;
        }
        private void LoadTheme()
        {
            foreach (Control btns in this.Controls)
            {
                if (btns.GetType() == typeof(Button))
                {
                    Button btn = (Button)btns;
                    btn.BackColor = clsTemaRenki.PrimaryColor;
                    btn.ForeColor = Color.White;
                    btn.FlatAppearance.BorderColor = clsTemaRenki.SecondaryColor;
                }
            }
         
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

      

        private void button1_Click(object sender, EventArgs e)
        {
            pic1.Visible = true;
            pic2.Visible = false;
            pic3.Visible = false;
            pic4.Visible = false;
            pic6.Visible = false;
            pic7.Visible = false;
            pic8.Visible = false;
            pic9.Visible = false;
        }

        private void btnaİkinciFormuAc_Click(object sender, EventArgs e)
        {
            pic1.Visible = false;
            pic2.Visible = true;
            pic3.Visible = true;
            pic4.Visible = true;
            pic6.Visible = true;
            pic7.Visible = false;
            pic8.Visible = false;
            pic9.Visible = false;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            pic1.Visible = false;
            pic2.Visible = false;
            pic3.Visible = false;
            pic4.Visible = false;
            pic6.Visible = false;
            pic7.Visible = true;
            pic8.Visible=true;
            pic9.Visible=true;
        }
    }
}
