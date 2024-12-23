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
    public partial class BorcGöster : Form
    {
        public BorcGöster()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FonksiyonK FonksiyonK = new FonksiyonK();

            try
            {
                
                List<Uye> uyeler = FonksiyonK.BorclariListele();

             
                dataGridView1.Columns.Clear();
                dataGridView1.Columns.Add("AdSoyad", "Ad Soyad");
                dataGridView1.Columns.Add("Telefon", "Telefon");
                dataGridView1.Columns.Add("GuncelBorc", "Güncel Borç");

               
                foreach (var uye in uyeler)
                {
                    dataGridView1.Rows.Add(uye.AdSoyad, uye.Telefon, uye.GüncelBorc.ToString("C"));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();  
            AidatTahsilat AidatTahsilat = new AidatTahsilat();  
            AidatTahsilat.Show();  
        }

        private void BorcGöster_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
