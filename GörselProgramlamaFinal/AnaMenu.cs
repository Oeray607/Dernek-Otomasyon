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
    public partial class AnaMenu : Form
    {
        public AnaMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UyeIslem uyeIslemleriForm = new UyeIslem();
            uyeIslemleriForm.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AidatTahsilat aidatTahsilatForm = new AidatTahsilat(); 
            aidatTahsilatForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            EtkinlikDuyuru etkinlikDuyuruForm = new EtkinlikDuyuru();
            etkinlikDuyuruForm.Show();
            this.Hide();
        }

        private void AnaMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
