using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class İkinciSoru : Form
    {
        public İkinciSoru()
        {
            InitializeComponent();
        }
        void loaadForm(Form form)
        {
            if (this.panel2.Controls.Count > 0)
                this.panel2.Controls.RemoveAt(0);

            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.panel2.Controls.Add(form);
            this.panel2.Tag = form;
            form.Show();
        }
        private void btrSekilCizme_Click(object sender, EventArgs e)
        {
            if (CmbBoxSekilCizilcek.SelectedIndex == 0)//n
            {
                NoktaFormu form = new NoktaFormu();
                loaadForm(form);

            }
            else if (CmbBoxSekilCizilcek.SelectedIndex == 1)//dikdörtgen
            {
                DikdortgenFormu form = new DikdortgenFormu();
                loaadForm(form);
            }

            else if (CmbBoxSekilCizilcek.SelectedIndex == 2)//çember
            {
                DaireFormu form = new DaireFormu();
                loaadForm(form);

            }
            else if (CmbBoxSekilCizilcek.SelectedIndex == 3)//silindir
            {
                SilindirFormu form = new SilindirFormu();
                loaadForm(form);
            }


            else if (CmbBoxSekilCizilcek.SelectedIndex == 4)//küre
            {
                KureFormu form = new KureFormu();
                loaadForm(form);
            }
            else if (CmbBoxSekilCizilcek.SelectedIndex == 5)//küre
            {
                YuzeyForm form = new YuzeyForm();
                loaadForm(form);
            }



            else if (CmbBoxSekilCizilcek.SelectedIndex == 6)//dörtgen
            {
                DortgenFormu form = new DortgenFormu();
                loaadForm(form);

            }
        }
    }
}
