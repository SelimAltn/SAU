using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandevuSistemi.Forms
{
    public class clsUrun
    {
        public string adi, aciklama;
        public PictureBox resmi;
        public int fiyat;
       
            
        public clsUrun()
        {

            adi = ""; aciklama = ""; fiyat =0;

        }
        public clsUrun(string adi, string aciklama, int fiyat)
                        
        {
            Adi = adi;Aciklama=aciklama;Fiyat=fiyat;


        }

        public int Fiyat { get => fiyat; set => fiyat = value; }
        public string Adi { get => adi; set => adi = value; }
        public string Aciklama { get => aciklama; set => aciklama = value; }

    }
}
