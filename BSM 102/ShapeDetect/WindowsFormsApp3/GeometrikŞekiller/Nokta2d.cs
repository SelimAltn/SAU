using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public class Nokta2d
    {
       private Random random = new Random(Guid.NewGuid().GetHashCode());
        public int X;
        public int Y;
       public Nokta2d() 
        {
            X=0;  Y = 0;  
            X= random.Next(1,301);
            Y= random.Next(1,301);
        }
       public void NoktaCiz  (Panel panel)
        {
            Graphics r = panel.CreateGraphics();
            SolidBrush brush = new SolidBrush(Color.Red);
            r.FillRectangle(brush, X, Y, 3, 3);
        }



    }
}
