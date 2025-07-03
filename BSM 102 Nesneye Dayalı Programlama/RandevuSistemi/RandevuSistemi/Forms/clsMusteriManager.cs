using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandevuSistemi.Forms
{

    /// 
    /// Müşteri yönetimi için sınıf tanımı (Singleton deseni)
    ///
    public class clsMusteriManager
    {
        // Singleton deseni için tek örnek değişkeni
        private static clsMusteriManager instance;
        // Müşteri listesini tutan BindingList
        private BindingList<clsMusteri> lsMusteriler = new BindingList<clsMusteri>();

        // Singleton örneği için property

        public static clsMusteriManager Instance
        {
            get
            {
                // Eğer örnek null ise yeni bir clsMusteriManager oluştur
                if (instance == null)
                {
                    instance = new clsMusteriManager();
                }
                return instance;
            }
        }

        // Müşteri listesine dışarıdan erişim sağlayan property
        public BindingList<clsMusteri> LsMusteriler
        {
            get { return lsMusteriler; }
        }

        /// --------------------------------------------------
        /// Günlük maliyetleri 
        ///----------------------------------------------------------

        public Dictionary<DateTime, int> GetGunlukMaliyetler()
        {
            // Günlük maliyetleri saklamak için sözlük oluştur
            var gunlukMaliyetler = new Dictionary<DateTime, int>();

            foreach (var musteri in lsMusteriler)
            {
                // Müşterinin randevu tarihini al ve tarihi sadece gün bazında kullan
                var tarih = musteri.RandevuTarihi.Date;
                // Müşterinin maliyetini string'den int'e çevir
                var maliyet = int.Parse(musteri.Maliyet.Replace("TL", ""));

                // Eğer tarih zaten sözlükte varsa, mevcut maliyete ekle
                if (gunlukMaliyetler.ContainsKey(tarih))
                {
                    gunlukMaliyetler[tarih] += maliyet;
                }
                // Eğer tarih sözlükte yoksa, yeni bir giriş ekle
                else
                {
                    gunlukMaliyetler[tarih] = maliyet;
                }
            }

            return gunlukMaliyetler;
        }


        private clsMusteriManager() { }
    }
}
