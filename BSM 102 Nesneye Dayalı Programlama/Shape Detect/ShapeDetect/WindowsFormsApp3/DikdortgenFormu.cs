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
    public partial class DikdortgenFormu : Form
    {
        Nokta2d n1 = new Nokta2d();
        Nokta2d n2 = new Nokta2d();
        Nokta2d n3 = new Nokta2d();
        Nokta2d n4 = new Nokta2d();
        public DikdortgenFormu()
        {
           
            InitializeComponent();
        }

        private void DikdortgenFormu_Load(object sender, EventArgs e)
        {
            n1.X = 143;n1.Y = 178;
            n1.X = 446;n1.Y = 178;
            n1.X = 446;n1.Y = 252;
            n1.X = 143;n1.Y = 252;
        }

        private void DikdortgenFormu_Paint(object sender, PaintEventArgs e)
        {
            // Formun genişliği ve yüksekliği
            int formWidth = this.ClientSize.Width;
            int formHeight = this.ClientSize.Height;

            // Dikdörtgenleri ortalamak için ofset hesaplaması
            int offsetX = 50;
            int offsetY = 50;
            e.Graphics.DrawRectangle(Pens.Black, n1.X+offsetX, n1.Y+offsetY, n2.X - n1.X, n3.Y - n2.Y );
            e.Graphics.DrawRectangle(Pens.Black, n2.X+offsetX, n2.Y+offsetY, n3.X - n2.X, n4.Y - n3.Y);
            e.Graphics.DrawRectangle(Pens.Black, n3.X+offsetX, n3.Y+offsetY, n4.X - n3.X, n1.Y - n4.Y);
            e.Graphics.DrawRectangle(Pens.Black, n4.X+offsetX, n4.Y+offsetY, n1.X - n4.X, n1.Y - n2.Y);

        }
    } 
}
