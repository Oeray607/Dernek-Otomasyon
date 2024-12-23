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
    public partial class UyeListele : Form
    {
        public UyeListele()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FonksiyonK FonksiyonK = new FonksiyonK(); 
            List<Uye> uyeler = FonksiyonK.UyeListele();

       
            if (uyeler == null || uyeler.Count == 0)
            {
                MessageBox.Show("Veritabanında üye bulunamadı.","Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            dataGridView1.Columns.Clear(); 

          
            foreach (var prop in typeof(Uye).GetProperties())
            {
                dataGridView1.Columns.Add(prop.Name, prop.Name);  
            }

          
            foreach (var uye in uyeler)
            {
                dataGridView1.Rows.Add(uye.ID, uye.AdSoyad, uye.Telefon, uye.Email, uye.Adres, uye.KayıtTarihi, uye.GüncelBorc, uye.Aile);
            }
        }

        private void UyeListele_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();  
            UyeIslem UyeIslem = new UyeIslem();  
            UyeIslem.Show(); 
        }

        private void UyeListele_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
