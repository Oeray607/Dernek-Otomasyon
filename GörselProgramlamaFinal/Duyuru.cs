using GörselProgramlamaFinal.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GörselProgramlamaFinal
{
    public partial class Duyuru : Form
    {
        private FonksiyonK FonksiyonK = new FonksiyonK(); 
        public Duyuru()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string duyuruMetni = richTextBox1.Text;

                if (string.IsNullOrEmpty(duyuruMetni))
                {
                    MessageBox.Show("Lütfen bir duyuru metni girin."," ", MessageBoxButtons.OK);
                    return;
                }

                
                FonksiyonK fonksiyonK = new FonksiyonK();
                List<string> emailListesi = FonksiyonK.UyeEmailListele(); 

                foreach (string email in emailListesi)
                {
                    try
                    {
                        
                        FonksiyonK.DuyuruGonder(email, duyuruMetni);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"E-posta gönderilemedi: {email}\nHata: {ex.Message}");
                    }
                }

                MessageBox.Show("Duyuru başarıyla gönderildi!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();  
            EtkinlikDuyuru EtkinlikDuyuru = new EtkinlikDuyuru();  
            EtkinlikDuyuru.Show();  
        }

        private void Duyuru_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
