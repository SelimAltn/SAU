using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3.GeometrikŞekiller
{
    public class Kure
    {
        public int X;
        public int Y;
        public int Z;
        public int R;
        public Kure ()
        {
            Random random = new Random(Guid.NewGuid().GetHashCode());
            X = random.Next(1, 301);
            Y = random.Next(1, 301);
            Z = random.Next(1, 301);
            R = random.Next(1, 301);

        }
        public void KureCiz(Panel panel)
        {
            Graphics r = panel.CreateGraphics();
            r.FillEllipse(Brushes.White, X, Y, R, R);
        }


    }
}
