using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{

    public partial class NoktaFormu : Form
    {
        Rectangle r;
        Nokta2d n = new Nokta2d();
        public NoktaFormu()
        {
            InitializeComponent();
        }

        private void NoktaFormu_Load(object sender, EventArgs e)
        {
            n.X = 100;
            n.Y = 100;
             r = new Rectangle(n.X, n.Y, 10, 10);
        }

        private void NoktaFormu_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillEllipse(Brushes.Black, r);

        }
    }
}
