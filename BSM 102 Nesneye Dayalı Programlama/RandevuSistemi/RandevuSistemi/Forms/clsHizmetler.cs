using RandevuSistemi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandevuSistemi.Forms
{
    public class clsHizmetler
    {
        public string adi;
        public string bilgi1, bilgi2, bilgi3;
        public string yanHizmet1, yanHizmet2, yanHizmet3;
        public int fiyat;

        public clsHizmetler()
        {

            adi = ""; bilgi1 = ""; bilgi2 = ""; bilgi3 = ""; fiyat = 0;

        }
        public clsHizmetler(string adi, string bilgi1, string bilgi2, string bilgi3
                         , string yanHizmet1, string yanHizmet2, int fiyat,
                        string yanHizmet3)
        {
            Adi = adi; Bilgi1 = bilgi1; Bilgi2 = bilgi2; Bilgi3 = bilgi3; Fiyat = fiyat;
            YanHizmet1 = yanHizmet1;
            YanHizmet2 = yanHizmet2;
            YanHizmet3 = yanHizmet3;


        }

        public int Fiyat { get => fiyat; set => fiyat = value; }
        public string Adi { get => adi; set => adi = value; }

        public string Bilgi1 { get => bilgi1; set => bilgi1 = value; }
        public string Bilgi3 { get => bilgi3; set => bilgi3 = value; }
        public string Bilgi2 { get => bilgi2; set => bilgi2 = value; }
        public string YanHizmet1 { get => yanHizmet1; set => yanHizmet1 = value; }
        public string YanHizmet2 { get => yanHizmet2; set => yanHizmet2 = value; }
        public string YanHizmet3 { get => yanHizmet3; set => yanHizmet3 = value; }

    }
}
