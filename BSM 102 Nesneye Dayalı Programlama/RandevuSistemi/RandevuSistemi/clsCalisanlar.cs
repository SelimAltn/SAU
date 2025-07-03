using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandevuSistemi
{
    public class clsCalisanlar
    {
        public string adisoyAdi, uzmanAlani;
        public byte yasi;
        public int likeSayisi;
        public string ozGecmis;
        public string[] gorusler ;
        bool birincirandevu;
        bool ikiincirandevu;
        bool ucuncurandevu;
        bool dorduncurandevu;

        public clsCalisanlar ()
        {

            adisoyAdi = ""  ; uzmanAlani = ""; ozGecmis = "";
            yasi = 0;likeSayisi= 0;
            birincirandevu  =true ;
            ikiincirandevu  =true ;
            ucuncurandevu   =true ;
            dorduncurandevu =true ;

        }
        public clsCalisanlar(string adiSoyAdi, string uzmanAlani,string ozGecmis ,bool birincirandevu, bool ikiincirandevu,bool ucuncurandevu,bool  dorduncurandevu)
        {
            Adi = adiSoyAdi; UzmanAlani = uzmanAlani;  OzGecmis = ozGecmis;
            BirinciRandevu = birincirandevu;İkiinciRandevu = ikiincirandevu;UcuncuRandevu=ucuncurandevu;DorduncuRandevu=dorduncurandevu;    
           

        }

        public string Adi { get => adisoyAdi; set => adisoyAdi = value; }
      
        public string UzmanAlani { get => uzmanAlani; set => uzmanAlani = value; }
        public string OzGecmis { get => ozGecmis; set => ozGecmis = value; }
        public bool BirinciRandevu { get => birincirandevu; set => birincirandevu = value; }
        public bool İkiinciRandevu { get => ikiincirandevu; set => ikiincirandevu = value; }
        public bool UcuncuRandevu { get => ucuncurandevu; set => ucuncurandevu = value; }
        public bool DorduncuRandevu { get => dorduncurandevu; set => dorduncurandevu = value; }

    }
 
}
