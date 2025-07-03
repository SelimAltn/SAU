using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandevuSistemi
{
    public class RandevuDurumu
    {
        public DateTime Tarih { get; set; }
        public int PersonelIndex { get; set; }
        public List<bool> SaatDurumlari { get; set; }

        // Yapıcı Metot
        public RandevuDurumu(DateTime tarih, int personelIndex)
        {
            Tarih = tarih;
            PersonelIndex = personelIndex;
            SaatDurumlari = new List<bool> { true, true, true, true };
        }

        // Belirli bir saat diliminin durumunu günceller
        //Bu metod, belirli bir saat diliminin dolu veya boş olduğunu günceller.
        

        public void SetSaatDurumu(int saatIndex, bool durum)//saatIndex < SaatDurumlari.Count ifadesi,
                                                            //indeksin SaatDurumlari listesinin uzunluğunu aşmadığını kontrol eder.
                                                            //Eğer indeks, listenin uzunluğundan büyükse geçersiz olur ve bu kontrol bunu önler.
        {
            if (saatIndex >= 0 && saatIndex < SaatDurumlari.Count)
            {
                SaatDurumlari[saatIndex] = durum;
            }
        }
    }
    //Bu kod parçası, belirli bir saat diliminin dolu veya boş olduğunu güncellerken,
    //geçerli bir indeks olup olmadığını kontrol eder. Bu kontrol, hatalı indeks erişimlerini
    //önler ve randevu saatlerinin durumlarının doğru bir şekilde yönetilmesini sağlar.






}
