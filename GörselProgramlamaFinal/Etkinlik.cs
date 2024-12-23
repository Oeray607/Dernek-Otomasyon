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
    public partial class Etkinlik : Form
    {
        private FonksiyonK FonksiyonK = new FonksiyonK(); 
        public Etkinlik()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                string etkinlikAdi = textBox1.Text;
                string etkinlikYeri = textBox2.Text;
                DateTime etkinlikSaati = dateTimePicker2.Value;

             
                FonksiyonK.EtkinlikEpostasiGonder(etkinlikAdi, etkinlikYeri, etkinlikSaati);

                MessageBox.Show("E-postalar başarıyla gönderildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();  
            EtkinlikDuyuru EtkinlikDuyuru = new EtkinlikDuyuru();  
            EtkinlikDuyuru.Show();  
        }

        private void Etkinlik_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
