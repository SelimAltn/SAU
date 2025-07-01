using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp3.GeometrikŞekiller;

namespace WindowsFormsApp3
{
    public partial class YuzeyForm : Form
    {
        Dikdortgen d = new Dikdortgen();
        Rectangle r;
        public YuzeyForm()
        {
            InitializeComponent();
        }
        private void YuzeyForm_Load(object sender, EventArgs e)
        {
            d.X = 200;
            d.Y = 200;
            d.Gen = 200;
            d.Boy = 20;
           


        }
        private void YuzeyForm_Paint(object sender, PaintEventArgs e)
        {
            r = new Rectangle(d.X, d.Y, d.Gen, d.Boy);
            PointF nokta1 = new PointF(d.X, d.Y);
            PointF nokta2 = new PointF(d.X + d.Gen, d.Y);
            PointF nokta3 = new PointF(300, 50);
            PointF nokta4 = new PointF(500, 50);
            PointF[] noktalar = { nokta1, nokta2, nokta3, nokta4 };

            Pen pen = new Pen(Color.DarkBlue);
            // PaintEventArgs parametresini kullanarak Graphics nesnesini al
            Graphics g = this.CreateGraphics();

            g.DrawRectangle(pen, r);
            g.DrawPolygon(pen, noktalar);

            pen.Dispose();
            g.Dispose();

        }


    }
}
