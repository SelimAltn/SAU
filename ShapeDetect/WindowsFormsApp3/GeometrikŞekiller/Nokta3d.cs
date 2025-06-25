using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3.GeometrikŞekiller
{
    public class Nokta3d:Nokta2d
    {
        private Random random = new Random(Guid.NewGuid().GetHashCode());
        public int X;
        public int Y;
        public int Z;
        public Nokta3d()
        {
            X = 0; Y = 0;Z = 0;
            X = random.Next(1, 301);
            Y = random.Next(1, 301);
            Z = random.Next(1, 301);
        }
       
    }
}
