using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandevuSistemi.Forms
{
    internal class clsRandevusuzMusteriManger
    {
        private static clsRandevusuzMusteriManger instance;
        private BindingList<clsRandevusuzMusteri> lsrandevusuzMusteriler = new BindingList<clsRandevusuzMusteri>();

        public static clsRandevusuzMusteriManger Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new clsRandevusuzMusteriManger();
                }
                return instance;
            }
        }

        public BindingList<clsRandevusuzMusteri> LsrandevusuzMusteriler
        {
            get { return lsrandevusuzMusteriler; }
        }


        private clsRandevusuzMusteriManger() { }
    }
}

