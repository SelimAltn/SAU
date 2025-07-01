/****************************************************************************
** SAKARYA ÜNİVERSİTESİ
** BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
** BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
** NESNEYE DAYALI PROGRAMLAMA DERSİ
** 2014-2015 BAHAR DÖNEMİ
**
** ÖDEV NUMARASI :1.
** ÖĞRENCİ ADI :SELİM ALTIN
** ÖĞRENCİ NUMARASI : g231210558
** DERSİN ALINDIĞI GRUP: A.
****************************************************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Simple_Word
{
    public partial class Form1 : Form
    {
        private Dictionary<RichTextBox, bool> DosyaKaydedildi = new Dictionary<RichTextBox, bool>();
        public Form1()
        {
            InitializeComponent();
            DosyaKaydedildi.Add(rtAnaBox,false);
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void yeniToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Aktif metin kutusunu al
                RichTextBox aktifTextBox = rtAnaBox;
                // Kullanıcıya yeni dosya açma uyarısı göster
                var cevab = MessageBox.Show("Yeni Dosya açmak üzerindesiniz !", "Uyarı", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                // Kullanıcı OK'i seçerse
                if (cevab == DialogResult.OK)
                {
                    // Eğer dosya kaydedilmediyse
                    if (!DosyaKaydedildi[aktifTextBox]) 
                    {
                        // Kullanıcıya kaydetme seçeneği sun
                        DialogResult cevap = MessageBox.Show("\nDosyanız kaydedilmedi. Kaydetmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                        if (cevap == DialogResult.Yes)
                        {
                            // Dosyayı kaydet
                            dosyaKaydetToolStripMenuItem_Click(sender, e);
                            rtAnaBox.Clear();
                           
                        }
                        else if (cevap == DialogResult.Cancel)
                            return;

                    }
                  
                }
                // Metin kutusunu temizle
                aktifTextBox.Clear();
                DosyaKaydedildi[aktifTextBox]=false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void dosyaAçToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            try
            {
                openFileDialog1.Filter = "Text Files(*.txt)|*.txt|All files(*.*)|*.*";
                // Eğer bir dosya seçilirse
                if (openFileDialog1.ShowDialog()==DialogResult.OK)
                {
                    // Seçilen dosyayı metin kutusuna yükle
                    rtAnaBox.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                  
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
               
            }
        }
        

        private void dosyaKaydetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Aktif metin kutusunu al
            RichTextBox aktifTextBox = rtAnaBox;
            try
            {
                // Dosya kaydetme iletişim kutusunu göster
                saveFileDialog1.Filter = "txt Files(*.txt)|*.txt|All files(*.*)|*.*";
                // Eğer bir dosya yolu seçilirse
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // Metin kutusundaki içeriği seçilen dosyaya kaydet
                    System.IO.File.WriteAllText(saveFileDialog1.FileName, rtAnaBox.Text);
                    // Dosya kaydedildiğini işaretle
                    DosyaKaydedildi[aktifTextBox] = true;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void çıkışToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            try
            {
                // Aktif metin kutusunu al 
                RichTextBox aktifTextBox = rtAnaBox;
                // Eğer dosya kaydedilmediyse
                if (!DosyaKaydedildi[aktifTextBox])
                {
                    // Kullanıcıya dosyayı kaydetme seçeneği sun
                    DialogResult cevap = MessageBox.Show("\nDosyanız kaydedilmedi. Kaydetmek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                    // Kullanıcı Evet'i seçerse 
                    if (cevap == DialogResult.Yes)
                    {
                        // Dosyayı kaydet
                        dosyaKaydetToolStripMenuItem_Click(sender, e);
                        // Kaydetme işlemi iptal edilirse, çıkış işlemi gerçekleştirilmez
                        if (!DosyaKaydedildi[aktifTextBox])
                            return;
                    }
                    else if (cevap ==DialogResult.Cancel)
                    {
                        // Çıkış işlemi iptal edilir
                        return;
                    }

                }
                // Formu kapat
                this.Close();
                // Metin kutusunu temizle
                aktifTextBox.Clear();
                // Dosya kaydedilmediğinden işareti false olarak ayarla
                DosyaKaydedildi[aktifTextBox] = false;
            }
            catch (Exception ex)
            {
                // Hata mesajını göster
                MessageBox.Show(ex.Message);
            }

        }

        private void yazdırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                printPreviewDialog1.Document = printDocument1;
                if (printPreviewDialog1.ShowDialog()==DialogResult.OK)
                {
                    printDocument1.Print();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
            try
            {
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)

        {
            e.Graphics.DrawString(rtAnaBox.Text,new Font("Arial",40,FontStyle.Bold),Brushes.Black,130,125);

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    rtAnaBox.Undo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            {
                try
                {
                    rtAnaBox.Redo();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void kopyalaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtAnaBox.Copy();
        }

        private void kesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtAnaBox.Cut();
           
        }

        private void yapıştırToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtAnaBox.Paste();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            kopyalaToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            kesToolStripMenuItem_Click(sender, e);
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            yapıştırToolStripMenuItem_Click( sender,  e);
        }

        private void renkToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
           
        }

        private void yazıÇeşitiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (fontDialog1.ShowDialog() == DialogResult.OK)
                {
                    rtAnaBox.Font = fontDialog1.Font;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ayarlarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void dosyaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void yazıRenkiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    rtAnaBox.ForeColor = colorDialog1.Color;
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void zeminRenkiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (colorDialog1.ShowDialog() == DialogResult.OK)
                {
                    rtAnaBox.BackColor = colorDialog1.Color;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
