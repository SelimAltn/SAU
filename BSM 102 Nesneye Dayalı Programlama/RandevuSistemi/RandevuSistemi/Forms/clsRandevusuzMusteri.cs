using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandevuSistemi.Forms
{
    internal class clsRandevusuzMusteri:clsMusteri
    {
        public clsRandevusuzMusteri(string adi, string soyadi, string telefon_numara)

        {

            Adi = adi; Soyadi = soyadi; Telefon_numara = telefon_numara;
            RandevuTarihi = randevutarihi; id = idUretme(); // id alanına rastgele değer atanıyor

        }
        public string FullName => $"{Adi} {Soyadi}";

    }
   
}
