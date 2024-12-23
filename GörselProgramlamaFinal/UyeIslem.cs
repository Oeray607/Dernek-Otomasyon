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
    public partial class UyeIslem : Form
    {
        public UyeIslem()
        {
            InitializeComponent();
            this.ActiveControl = null;
            this.Select();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            UyeEkleGuncelle UyeleriEkleGuncelle = new UyeEkleGuncelle();
            UyeleriEkleGuncelle.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            UyeCikar UyeleriCikar = new UyeCikar();
            UyeleriCikar.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            UyeListele UyeleriListele = new UyeListele();
            UyeleriListele.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();  
            AnaMenu AnaMenu = new AnaMenu(); 
            AnaMenu.Show(); 
        }

        private void UyeIslem_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
