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
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }
        void loaadForm (Form form)
        {
            if (this.mainPanel.Controls.Count > 0)
                this.mainPanel.Controls.RemoveAt(0);
           
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            this.mainPanel.Controls.Add(form);
            this.mainPanel.Tag = form;
            form.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var kokko = MessageBox.Show("çıkmak üzerindesiniz", "dikkat", MessageBoxButtons.OKCancel);
            if (kokko == DialogResult.OK)
                this.Close();
         
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var kokko =MessageBox.Show("çıkmak üzerindesiniz","dikkat",MessageBoxButtons.OKCancel);
            if (kokko==DialogResult.OK)
            this.Close();
            
        }

        private void button5_Click(object sender, EventArgs e)
        {

            loaadForm(new BirinciSoru());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            loaadForm(new İkinciSoru());
        }


            private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            loaadForm(new Abaut());
        }

        private void mainPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
