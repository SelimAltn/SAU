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
    public partial class frmOnayBeklenenPersoneller : Form
    {
        public frmOnayBeklenenPersoneller()
        {
            InitializeComponent();
        }

        private void frmOnayBeklenenPersoneller_Load(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            dataGridView1.DataSource = clsPersonelManager.Instance.LsCalisanlar.ToList();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
