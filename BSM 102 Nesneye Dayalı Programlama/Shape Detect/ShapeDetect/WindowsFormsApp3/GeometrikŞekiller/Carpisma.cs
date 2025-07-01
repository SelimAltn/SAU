//using System;
//using System.Collections.Generic;
//using System.Drawing;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace WindowsFormsApp3.GeometrikŞekiller
//{
//    internal class Carpisma
//    {
        
//        public static void DaireCarpısma (Daire d1,Daire d2)
//        {
//            float d = (float)Math.Sqrt(Math.Pow((d1.N.X - d2.N.X), 2) 
//                + Math.Pow((d1.N.Y - d2.N.Y), 2));
//            if ((d1.R + d2.R) > d)
//                _= MessageBox.Show("çarpışma ","Sonuç",MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
//        }
//        public static void KureCarpısma(Kure k1, Kure k2)
//        {
//            float d = (float)Math.Sqrt(Math.Pow((k1.N.X - k2.N.X), 2) +
//              Math.Pow((k1.N.Y - k2.N.Y), 2) + Math.Pow((k1.N.Z - k2.N.Z), 2));
//            if ((k1.R + k2.R) > (int)d)
//                _ = MessageBox.Show("çarpışma ", "Sonuç", MessageBoxButtons.OK, MessageBoxIcon.Warning);

//        }
//        public static void DikdortgenCarpısma(Dikdortgen g1, Dikdortgen g2)
//        {
//            int Xa = g1.N.X +g1.Gen  / 2;
//            int Ya = g1.N.Y + g1.Boy / 2;
//            int Xb = g2.N.X + g2.Gen / 2;
//            int Yb = g2.N.Y + g2.Boy / 2;
//            if (Math.Abs(Xa - Xb) < (g1.Gen / 2 + g2.Gen / 2) && Math.Abs(Ya - Yb) < (g1.Boy / 2 + g2.Boy / 2))
//                _ = MessageBox.Show("çarpışma ", "Sonuç", MessageBoxButtons.OK, MessageBoxIcon.Warning);

//        }
//        public static void SilindirCarpısma(Silindir s1, Silindir s2)
//        {
//            Nokta3d pa = new Nokta3d(s1.N.X, s1.N.Y + s1.H / 2, s1.N.Z);
//            Nokta3d pb = new Nokta3d(s2.N.X, s2.N.Y + s2.H / 2, s2.N.Z);
//            float d = (float)Math.Sqrt(Math.Pow((pa.X - pb.X), 2) +
//            Math.Pow((pa.Y - pb.Y), 2) + Math.Pow((pa.Z - pb.Z), 2));
           
//            if ((s1.R + s2.R) > (int)d && Math.Abs(pa.Y - pb.Y) < ((s1.H + s2.H) / 2))
//                _ = MessageBox.Show("çarpışma ", "Sonuç", MessageBoxButtons.OK, MessageBoxIcon.Warning);

//        }
//        public static void circledikdortgenCarp(Daire c, Dikdortgen d)
//        {

//            //Rectangle rect = new Rectangle(d.N.X, d.N.Y, d.Gen, d.Boy);
//            //if (rect.IntersectsWith(new Rectangle(c.N.X - c.R, c.N.Y - c.R, c.R * 2, c.R * 2)))
              
//        }


//    }
//}
