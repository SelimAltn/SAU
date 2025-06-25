using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace WindowsFormsApp3
{
    public partial class DikdortgenPrizmaFormu : Form
    {
        Nokta2d p = new Nokta2d();
        public DikdortgenPrizmaFormu()
        {
            InitializeComponent();
        }
        private void DikdortgenPrizmaFormu_Load(object sender, EventArgs e)
        {

        }
        private void DikdortgenPrizmaFormu_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int boy = 100;
            int gen = 150;
            int derinlik = 75;
            p.X = 50;
            p.Y = 50;
            
           

        }

    }

       
    
}
