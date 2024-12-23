using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GörselProgramlamaFinal
{
    public partial class Giris : Form
    {
        public Giris()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {

            string KullaniciAdi = "eray";
            string Sifre = "123";

            string kullaniciAdi = textBox1.Text;
            string sifre = textBox2.Text;

            if (kullaniciAdi == KullaniciAdi && sifre == Sifre)
            {
                MessageBox.Show("Giriş başarılı! Panele Yönlendiriliyorsunuz.", "Tebrikler!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AnaMenu AnaMenu = new AnaMenu();
                AnaMenu.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı veya şifre hatalı.", "Hata Kodu: 183", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Clear();
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Giris_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            decimal aidatMiktari = 200m;
            if (DateTime.Now.Day == 1)
            {
                FonksiyonK FonksiyonK = new FonksiyonK();
                FonksiyonK.AidatGuncellemeTumu(aidatMiktari);
                MessageBox.Show("Aidat başarıyla güncellendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Giris_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
