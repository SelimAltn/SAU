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
    public partial class KureFormu : Form
    {
       Kure kure =new Kure();
         
        public KureFormu()
        {
            InitializeComponent();
        }

        private void KureFormu_Load(object sender, EventArgs e)
        {
            kure.X = 100;
            kure.Y = 100;
            kure.R = 50;

        }

        private void KureFormu_Paint(object sender, PaintEventArgs e)
        {
            Color color = Color.FromArgb(102, 51, 153);


            GraphicsPath gPath = new GraphicsPath();

            Rectangle rect = new Rectangle(kure.X- kure.R, kure.Y - kure.R, kure.R * 2, kure.R * 2);

            gPath.AddEllipse(rect);

            PathGradientBrush pathGradientBrush = new PathGradientBrush(gPath);
            pathGradientBrush.CenterPoint = new PointF(kure.X, kure.Y);
            pathGradientBrush.CenterColor = color;
            pathGradientBrush.SurroundColors = new Color[] { Color.White };

            e.Graphics.FillPath(pathGradientBrush, gPath);

            gPath.Dispose();
            pathGradientBrush.Dispose();
        }
    }
}
