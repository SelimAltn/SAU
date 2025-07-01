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
using WindowsFormsApp3.GeometrikŞekiller;

namespace WindowsFormsApp3
{
    public partial class SilindirFormu : Form

    {
        Nokta3d merkez = new Nokta3d();
        int yukseklik;
        int yaricap;
        public SilindirFormu()
        {
            InitializeComponent();
        }

       
       

        private void SilindirFormu_Load(object sender, EventArgs e)
        {
            merkez.X = 200;
            merkez.Y = 50;
            yaricap = 50;
            yukseklik = 100;
        }

        private void SilindirFormu_Paint(object sender, PaintEventArgs e)
        {
            // Üst yüzeyi çiz
            e.Graphics.FillEllipse(Brushes.Gray, merkez.X - yaricap, merkez.Y - yaricap, 2 * yaricap, 2 * yaricap);

            // Alt yüzeyi çiz
            e.Graphics.FillEllipse(Brushes.Gray, merkez.X - yaricap, merkez.Y - yaricap + yukseklik, 2 * yaricap, 2 * yaricap);

            // Yan yüzeyi çiz
            e.Graphics.DrawLine(Pens.Gray, merkez.X - yaricap, merkez.Y, merkez.X - yaricap, merkez.Y + yukseklik);
            e.Graphics.DrawLine(Pens.Gray, merkez.X + yaricap, merkez.Y, merkez.X + yaricap, merkez.Y + yukseklik);
            e.Graphics.DrawLine(Pens.Gray, merkez.X - yaricap, merkez.Y, merkez.X - yaricap, merkez.Y + yukseklik);
            e.Graphics.DrawLine(Pens.Gray, merkez.X + yaricap, merkez.Y, merkez.X + yaricap, merkez.Y + yukseklik);
        }
    }
}
