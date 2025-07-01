using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3.GeometrikŞekiller
{
    public class Yuzey
    {
        public int X;
        public int Y;
        public int Z;
        public int Boy;
        public int Gen;
        public int Derinlik;

        public Yuzey()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            X = random.Next(1, 301);
            Y = random.Next(1, 301);
            Z = random.Next(1, 301);
            Boy = random.Next(1, 301);
            Gen = random.Next(1, 301);
            Derinlik = 1;
        }
        public void YuzeyCiz(Panel panel)
        {
            Graphics r = panel.CreateGraphics();
            Pen pen = new Pen(Color.CornflowerBlue);
            r.DrawRectangle(pen, X, Y, Gen, Boy);
            r.DrawRectangle(pen, X + Derinlik, Y + Derinlik, Gen, Boy);

            r.DrawLine(pen, X, Y, X + Derinlik, Y + Derinlik);

            r.DrawLine(pen, X + Gen, Y, X + Gen + Derinlik, Y + Derinlik);

            r.DrawLine(pen, X, Y + Boy, X + Derinlik, Y + Derinlik + Boy);

            r.DrawLine(pen, X + Gen, Y + Boy, X + Gen, Y + Derinlik + Boy);

        }
    }
}
