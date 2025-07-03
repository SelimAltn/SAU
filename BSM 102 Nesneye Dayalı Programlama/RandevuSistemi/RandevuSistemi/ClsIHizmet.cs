using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandevuSistemi.Interfaces
{
    public interface ClsIHizmet
    {
        string Adi { get; set; }
        string Bilgi1 { get; set; }
        string Bilgi2 { get; set; }
        string Bilgi3 { get; set; }
        int Fiyat { get; set; }
    }
}
