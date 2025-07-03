using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandevuSistemi
{
    public class clsMusteri
    {
        private string adi, soyadi,personel;

        protected int id;
        private string telefon_numara,hizmet;
        protected HashSet<int> Setİd = new HashSet<int>();
        protected static Random random = new Random();
        protected DateTime randevutarihi;
        string saat;
        private string maliyet;


        public clsMusteri()
        {

            adi = ""; soyadi = ""; telefon_numara = "" ;personel = "";saat = ""; maliyet = "";

        }
        public clsMusteri(string adi, string soyadi ,string telefon_numara,string hizmet,string personel, DateTime randevutarihi ,string saat,string maliyet)

        {

            Adi = adi; Soyadi = soyadi;  Telefon_numara = telefon_numara;
            RandevuTarihi=randevutarihi; id = idUretme(); // id alanına rastgele değer atanıyor
            Hizmet = hizmet;
            Personel=personel;
            Saat = saat;
            Maliyet = maliyet;





        }
        public int idUretme()
        {
            int newID;

            do
            {
                newID = random.Next(1, 1001); // 1 ile 1000 arasında rastgele bir ID oluştur
            } while (Setİd.Contains(newID)); // Oluşturulan ID zaten mevcutsa tekrar oluştur.

            Setİd.Add(newID); // Yeni ID'yi sakla
            return newID;
        }
        public int Id { get { return id; } } 
        public string Adi { get => adi; set => adi = value; }
        public string Soyadi { get => soyadi; set => soyadi = value; }
        public string Telefon_numara { get => telefon_numara; set => telefon_numara = value; }
        public string Hizmet { get => hizmet; set => hizmet = value; }
        public string Personel { get => personel; set => personel = value; }
        public string Saat { get => saat; set => saat = value; }
        public DateTime RandevuTarihi { get => randevutarihi; set => randevutarihi = value; }
        public string Maliyet { get => maliyet; set => maliyet = value; }



    }
}
