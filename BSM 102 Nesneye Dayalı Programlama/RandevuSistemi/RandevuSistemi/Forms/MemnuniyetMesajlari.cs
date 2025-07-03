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
    public partial class MemnuniyetMesajlari : Form
    {
        public MemnuniyetMesajlari()
        {
            InitializeComponent();
        }

        private void MemnuniyetMesajlari_Load(object sender, EventArgs e)
        {
            LoadTheme();
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
            button1.ForeColor = clsTemaRenki.SecondaryColor;
            button2.ForeColor = clsTemaRenki.PrimaryColor;

        }
    }
}
