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
    public partial class EtkinlikDuyuru : Form
    {
        public EtkinlikDuyuru()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Etkinlik EtkinlikOlustur = new Etkinlik();
            EtkinlikOlustur.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Duyuru DuyuruOlustur = new Duyuru();
            DuyuruOlustur.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            AnaMenu AnaMenu = new AnaMenu(); 
            AnaMenu.Show();  
        }

        private void EtkinlikDuyuru_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
