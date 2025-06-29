using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3.GeometrikŞekiller
{
    public class Daire
    {
        private Random random = new Random(Guid.NewGuid().GetHashCode()); 
        public int R;
        public int X;
        public int Y;
        public Daire() 
        {
           X=0; Y=0;R=0;
            X = random.Next(1, 301);
            Y = random.Next(1, 301);
            R = random.Next(1, 201);
        }
        public void CemberCiz(Panel panel)
        {
            Graphics m = panel.CreateGraphics();
            Pen pen = new Pen(Color.Blue);
            m.DrawEllipse(pen, X, Y, R, R);
        }

    }
}
