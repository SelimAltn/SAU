using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp3.GeometrikŞekiller;

namespace WindowsFormsApp3
{
   
    public static class Carpismalar
    {
         public static double SayininKaresi (double number)
        {
            return number * number;
        }
       
        public static bool NoktaDikdortgen(Nokta2d nokta, Dortgen dortgen)
        {
            if (nokta.X >= dortgen.X &&
                nokta.Y >= dortgen.Y &&
                nokta.X <= dortgen.X + dortgen.Gen &&
                nokta.Y <= dortgen.Y + dortgen.Boy
               )
                 { return true; }
            return false;
        }//1
        public static bool NoktaCember (Nokta2d nokta ,Daire cember)//2
        {
            int Yari = cember.R / 2;
            int Mx = cember.X + Yari;
            int My = cember.Y + Yari;
            if (Math.Sqrt((nokta.X - Mx) * (nokta.X - Mx) + (nokta.Y - My) * (nokta.Y - My)) == Yari)
            { return true; }

            return false;



        }
        public static bool DikdortgenDikdortgen (Dikdortgen dikdortgen1,Dortgen dikdortgen2 )
        {
            double N1x = dikdortgen1.X + dikdortgen1.Gen / 2;
            double N2x = dikdortgen2.X + dikdortgen2.Gen / 2;
            double N1y = dikdortgen1.Y + dikdortgen1.Boy / 2;
            double N2y = dikdortgen2.Y + dikdortgen2.Boy / 2;


            if (Math.Abs(N1x-N2x)<=(dikdortgen1.Gen/2+dikdortgen2.Gen/2)
                &&
               Math.Abs(N1y - N2y) <= (dikdortgen1.Boy  + dikdortgen2.Boy))
            { return true; }

            return false;
            

        }//3
        public static bool DikdortgenCember (Dikdortgen dikdortgen ,Daire cember)//4
        {
            int Yari = cember.R / 2;
            int Mx = cember.X + Yari;
            int My = cember.Y + Yari;
            if (Math.Abs((dikdortgen.X + dikdortgen.Gen / 2) - Mx) < dikdortgen.Gen / 2 + Yari &&
                     Math.Abs(My - (dikdortgen.Y + dikdortgen.Boy / 2)) < dikdortgen.Boy / 2 + Yari)
                      { return true; }
        
            return false;

        }
        public static bool CemberCember (Daire cember1,Daire cember2) //5
        {
            int Yari = cember1.R / 2;
            int Mx = cember1.X + Yari;
            int My = cember1.Y + Yari;
            int Yari2 = cember2.R / 2;
            int Mx2 = cember2.X + Yari;
            int My2 = cember2.Y + Yari;
            if (Math.Sqrt((Mx - Mx2)* (Mx - Mx2) + (My - My2)* (My - My2)) < Yari + Yari2)
            { return true; }
            return false;

            

        }
        public static bool NoktaKure(Nokta3d nokta, Kure kure) 
        {
            int Yari = kure.R / 2;
            int Mx = kure.X + Yari;
            int My = kure.Y + Yari;
            int Mz = kure.Z + Yari;
            if (Math.Sqrt((nokta.X - Mx) * (nokta.X - Mx) + (nokta.Y - My) * (nokta.Y - My)) <=  Yari)
                     { return true; }
          
            return false;
        }
        public static bool NoktaDikdortgenPrizmasi(Nokta3d nokta, DikdortgenPrizmasi dikdortgenPrizmasi)
        {
            
            if (
                nokta.X>=dikdortgenPrizmasi.X&&
                nokta.Y>=dikdortgenPrizmasi.Y
                 &&  nokta.X <= dikdortgenPrizmasi.X + dikdortgenPrizmasi.Gen
               
                && nokta.Y <= dikdortgenPrizmasi.Y + dikdortgenPrizmasi.Boy + dikdortgenPrizmasi.Derinlik

                && nokta.X <= dikdortgenPrizmasi.X + dikdortgenPrizmasi.Derinlik+ dikdortgenPrizmasi.Gen
                
               )
                 { return true; }
            return false;
        }
        public static bool NoktaSilindir (Nokta3d nokta,Silindir silindir)
        {
            int Yari = silindir.R / 2;
            int Mx = silindir.X +silindir.Gen/2+ Yari;
            int My = silindir.Y + Yari+silindir.H/2;
            int Mz = silindir.Z + silindir.Derinlik/2;
            int N = (nokta.X - Mx) * (nokta.X - Mx) + (nokta.Y - My) * (nokta.Y - My);
           if (N<=Yari*Yari&&nokta.Z-Mz>=0&& nokta.Z - Mz<=silindir.H)
            { return true; }
          
                
            return false;
        }
        public static bool SilindirSilindir (Silindir silindir1,Silindir silindir2)
        {
            int Yari1 = silindir1.R / 2;
            int Mx1 = silindir1.X + silindir1.Gen / 2 + Yari1;
            int My1 = silindir1.Y + Yari1 + silindir1.H / 2;
            int Mz1 = silindir1.Z + silindir1.Derinlik / 2;

            int Yari2 = silindir2.R / 2;
            int Mx2 = silindir2.X + silindir2.Gen / 2 + Yari2;
            int My2 = silindir2.Y + Yari2 + silindir2.H / 2;
            int Mz2 = silindir2.Z + silindir2.Derinlik / 2;

            int mer = (Mx2 - Mx1) * (Mx2 - Mx1) + (My2 - My1) * (My2 - My1);
            int rKar = (Yari1 + Yari2) * (Yari1 + Yari2);
            if (mer<=rKar)
            { return true; }
          
            return false;
        }
        public static bool KureKure(Kure Kure1, Kure Kure2)
        {
            int Yari1 = Kure1.R / 2;
            int Mx1 = Kure1.X + Yari1;
            int My1 = Kure1.Y + Yari1;
            int Mz1 = Kure1.Z + Yari1;

            int Yari2 = Kure2.R / 2;
            int Mx2 = Kure2.X + Yari2;
            int My2 = Kure2.Y + Yari2;
            int Mz2 = Kure2.Z + Yari2;

            if (Math.Sqrt(Math.Abs((Mx1 - Mx2) * (Mx1 - Mx2) + (My1 - My2) * (My1 - My2))) <= Yari1+Yari2)
            { return true; }
            return false;
        }
        public static bool KureSilindir (Kure kure ,Silindir silindir)
        {
            int Yari1 = kure.R / 2;
            int Mx1 = kure.X + Yari1;
            int My1 = kure.Y + Yari1;
            int Mz1 = kure.Z + Yari1;

            int Yari2 = silindir.R / 2;
            int Mx2 = silindir.X + silindir.Gen / 2 + Yari2;
            int My2 = silindir.Y + Yari2 + silindir.H / 2;
            int Mz2 = silindir.Z + silindir.Derinlik / 2;

            int dik = (My1 - silindir.H / 2) * (My1 - silindir.H / 2);
            int yat = (Mx1 - Mx2) * (Mx1 - Mx2);
            int uza = (Yari1 + Yari2) * (Yari1 + Yari2);
            if (dik<=uza&&yat<=Yari2*Yari2)
            { return true; }

            return false; // Çarpışma yok

        }
        public static bool KureYuzy(Kure kure, Yuzey yuzey)
        {
           

            double EnyakınX = Math.Max (yuzey.X , Math.Min (yuzey.X, yuzey.X + yuzey.Gen));
            double EnyakınY = Math.Max (yuzey.Y , Math.Min (yuzey.Y, yuzey.Y + yuzey.Boy));
            double EnyakınZ = Math.Max (yuzey.Z , Math.Min (yuzey.Z, yuzey.Z + yuzey.Derinlik));
            double Uzaklık = (double)Math.Sqrt(
                                               SayininKaresi(kure.X - EnyakınX) 
                                             + SayininKaresi(kure.Y - EnyakınY) 
                                             + SayininKaresi(kure.Z - EnyakınZ)
                                              );
            if (Uzaklık<=kure.R)
                 { return true; }
            return false;
        }
        public static bool DikdotgenPrizmasiYuzey( DikdortgenPrizmasi p,Yuzey yuzey)
        {
            int mx1 =yuzey.X+yuzey.Gen/2;
            int my1 =yuzey.Y+yuzey.Boy/2;
            int mz1 =yuzey.Z+yuzey.Derinlik/2;

            int mx2 = p.X + yuzey.Gen / 2;
            int my2 = p.Y + yuzey.Boy / 2;
            int mz2 = p.Z + yuzey.Derinlik / 2;
            int maxm = (my1 + yuzey.Derinlik / 2) + (my2 + p.Derinlik / 2);
            int maxyat = (mx2 + p.Gen / 2) + (mx1 + yuzey.Gen / 2);
            int key = (my2 + p.Boy / 2) + (my2 + yuzey.Boy / 2);
            int dik = (p.Boy / 2 - yuzey.Boy / 2);
            int yata = (p.Gen / 2 - yuzey.Boy / 2) + (p.Derinlik / 2 - yuzey.Derinlik / 2);
            if (dik<=key&&yata<=maxyat&&yata<=maxm)
            { return true; }
            return false;
           
        }
        public static bool SilindirYuzey (Silindir silindir,Yuzey yuzey)
        {

            int mx1 = yuzey.X + yuzey.Gen / 2;
            int my1 = yuzey.Y + yuzey.Boy / 2;
            int mz1 = yuzey.Z + yuzey.Derinlik / 2;

            int Yari2 = silindir.R / 2;
            int Mx2 = silindir.X + silindir.Gen / 2 + Yari2;
            int My2 = silindir.Y + Yari2 + silindir.H / 2;
            int Mz2 = silindir.Z + silindir.Derinlik / 2;

           

           
            if (Mx2 < yuzey.X && Mx2 > yuzey.X + yuzey.Gen &&
                 My2 < yuzey.Y && My2 > yuzey.Y + yuzey.Boy &&
                  Mz2 < yuzey.Z || Mz2 > yuzey.Derinlik + yuzey.Z)
            { return true; }


            return false;
        }
        public static bool KurePrizma(Kure k, DikdortgenPrizmasi p)
        {
            int Yari1 = k.R / 2;
            int Mx1 = k.X + Yari1;
            int My1 = k.Y + Yari1;
            int Mz1 = k.Z + Yari1;

            int mx2 = p.X + p.Gen / 2;
            int my2 = p.Y + p.Boy / 2;
            int mz2 = p.Z + p.Derinlik / 2;

            int dikøyMesafekare = (My1 - p.Boy / 2) * (My1 - p.Boy / 2);
            int yatayMesafekare = (Mx1 - mx2)* (Mx1 - mx2);
            int maxMesafekare = (Yari1 + p.Gen / 2) * (Yari1 + p.Gen / 2);
            if (dikøyMesafekare<=maxMesafekare&&yatayMesafekare<=p.Gen*p.Gen)
            { return true ; }
            return false;

        }
        public static bool DikdortgenprizmasiDikdortgenprizmasi (DikdortgenPrizmasi p1,DikdortgenPrizmasi p2)
        {
            int mx1 = p1.X + p1.Gen / 2;
            int my1 = p1.Y + p1.Boy / 2;
            int mz1 = p1.Z + p1.Derinlik / 2;

            int mx2 = p2.X + p2.Gen / 2;
            int my2 = p2.Y + p2.Boy / 2;
            int mz2 = p2.Z + p2.Derinlik / 2;
            int maxYatayMesafe = (mx2 + p2.Gen / 2) + (mx1 + p1.Gen / 2);
            int maxdikeyMesafe = my1 + p1.Gen / 2 + my2 + p2.Gen / 2;

            int dikeymesafe = p2.Boy / 2 - p1.Boy / 2;
            int yatayMesafe = p2.Gen / 2 - p1.Gen / 2 + (p2.Derinlik / 2 - p1.Derinlik / 2);

            if (dikeymesafe <= maxdikeyMesafe && yatayMesafe <= maxYatayMesafe)
            { return true; }
             return false;
        }

    }
}
