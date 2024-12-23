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
    public partial class AidatTahsilat : Form
    {
        public AidatTahsilat()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            AidatOde AidatlariOde = new AidatOde();
            AidatlariOde.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            BorcGöster BorclariGöster = new BorcGöster();
            BorclariGöster.Show();
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            AnaMenu AnaMenu = new AnaMenu();  
            AnaMenu.Show();  
        }

        private void AidatTahsilat_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
