using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RandevuSistemi.Forms
{
    public partial class frmKayitliMusterilerimiz : Form
    {
        private static bool kayitlarEklendi = false; // Bu alan kayıtların eklenip eklenmediğini izler

        public frmKayitliMusterilerimiz()
        {
            InitializeComponent();
        }

        private void frmKayitliMusterilerimiz_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            BindingList<clsRandevusuzMusteri> musteriler = clsRandevusuzMusteriManger.Instance.LsrandevusuzMusteriler;

            if (!kayitlarEklendi) // Kayıtlar daha önce eklenmediyse ekle
            {
                clsRandevusuzMusteriManger.Instance.LsrandevusuzMusteriler.Add(new clsRandevusuzMusteri("Selin", "Kaya", "9050606050"));
                clsRandevusuzMusteriManger.Instance.LsrandevusuzMusteriler.Add(new clsRandevusuzMusteri("ayçe", "oz", "90508566050"));
                clsRandevusuzMusteriManger.Instance.LsrandevusuzMusteriler.Add(new clsRandevusuzMusteri("fatima", "yılmaz", "9057806050"));
                clsRandevusuzMusteriManger.Instance.LsrandevusuzMusteriler.Add(new clsRandevusuzMusteri("ada", "yuksel", "758572887275"));
                clsRandevusuzMusteriManger.Instance.LsrandevusuzMusteriler.Add(new clsRandevusuzMusteri("Merve", "demir", "5275582828"));
                clsRandevusuzMusteriManger.Instance.LsrandevusuzMusteriler.Add(new clsRandevusuzMusteri("malisa", "can", "9050606050"));
                clsRandevusuzMusteriManger.Instance.LsrandevusuzMusteriler.Add(new clsRandevusuzMusteri("Bahar", "Öztürk", "785278527"));
                kayitlarEklendi = true; // Kayıtların eklendiğini işaretle
            }

            dataGridView1.DataSource = musteriler.ToList();
        }
    }
}
