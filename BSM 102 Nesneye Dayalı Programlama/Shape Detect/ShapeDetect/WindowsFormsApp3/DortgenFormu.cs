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
    public partial class DortgenFormu : Form
    {
        Nokta2d n1 = new Nokta2d();
        Nokta2d n2 = new Nokta2d();
        Nokta2d n3 = new Nokta2d();
        Nokta2d n4 = new Nokta2d();

        public DortgenFormu()
        {
            InitializeComponent();
        }

        private void DortgenFormu_Load(object sender, EventArgs e)
        {
        
            n1.X = 350; n1.Y = 50;
            n2.X = 550; n2.Y = 100;
            n3.X = 400; n3.Y = 200;
            n4.X = 250; n4.Y = 150;
        }

        private void DortgenFormu_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawLine(Pens.Black, n1.X, n1.Y, n2.X, n2.Y);
            e.Graphics.DrawLine(Pens.DarkOliveGreen, n2.X, n2.Y, n3.X, n3.Y);
            e.Graphics.DrawLine(Pens.DarkOrchid, n3.X, n3.Y, n4.X, n4.Y);
            e.Graphics.DrawLine(Pens.DarkSlateBlue, n4.X, n4.Y, n1.X, n1.Y);
        }
    }
}