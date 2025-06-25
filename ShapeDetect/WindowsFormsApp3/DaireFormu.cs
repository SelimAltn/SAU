using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3.GeometrikŞekiller;

namespace WindowsFormsApp3
{
    public partial class DaireFormu : Form
    {
        Daire d = new Daire();
        Rectangle r;

        public DaireFormu()
        {
            InitializeComponent();
        }

        private void DaireFormu_Load(object sender, EventArgs e)
        {
            d.X = 100;
            d.Y = 100;
            r = new Rectangle(d.X,d.Y,100,100);
        }

        private void DaireFormu_Paint(object sender, PaintEventArgs e)
        {
         
            e.Graphics.DrawEllipse(Pens.Black, r);


        }
    }
}
