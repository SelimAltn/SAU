using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandevuSistemi.Forms
{
    /// 
    /// Personel yönetimi için sınıf tanımı (Singleton deseni)
    ///
    public class clsPersonelManager
    {
        //Singleton deseni 
        private static clsPersonelManager instance;
        // Singleton instance'ı almak için kullanılan özellik
        public static clsPersonelManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new clsPersonelManager();
                }
                return instance;
            }
        }

        // Çalışanların listesi
        public BindingList<clsCalisanlar> LsCalisanlar { get; set; }

        // Randevu durumlarının listesi
        public List<RandevuDurumu> RandevuDurumlari { get; set; }

        // Özel constructor, sadece sınıf içinde kullanılabilir
        private clsPersonelManager()
        {
            LsCalisanlar = new BindingList<clsCalisanlar>();
            RandevuDurumlari = new List<RandevuDurumu>();
        }
        // Belirli bir tarih ve personel için randevu durumu almak veya oluşturmak
        public RandevuDurumu GetOrCreateRandevuDurumu(DateTime tarih, int personelIndex)
        {
            var randevuDurumu = RandevuDurumlari.FirstOrDefault(r => r.Tarih == tarih && r.PersonelIndex == personelIndex);
            if (randevuDurumu == null)
            {
                randevuDurumu = new RandevuDurumu(tarih, personelIndex);
                RandevuDurumlari.Add(randevuDurumu);
            }
            return randevuDurumu;
        }

        public void UpdateRandevuDurumu(DateTime tarih, int personelIndex, int saatIndex, bool durum)
        {
            var randevuDurumu = GetOrCreateRandevuDurumu(tarih, personelIndex);
            randevuDurumu.SetSaatDurumu(saatIndex, durum);
        }
    }
}