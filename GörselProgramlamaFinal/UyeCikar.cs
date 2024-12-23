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
    public partial class UyeCikar : Form
    {
        public UyeCikar()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string input = textBox1.Text; 

         
            if (int.TryParse(input, out int uyeID))
            {
              
                FonksiyonK FonksiyonK = new FonksiyonK();
                if (FonksiyonK.UyeVarMi(uyeID)) 
                {
                    FonksiyonK.UyeSil(uyeID);
                    MessageBox.Show("Üye başarıyla silindi!");
                    textBox1.Clear();
                }
                else
                {
                    MessageBox.Show("Girilen ID'ye ait üye bulunamadı.","Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox1.Clear();
                }
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir ID girin.", "Dikkat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox1.Clear();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();  
            UyeIslem UyeIslem = new UyeIslem();  
            UyeIslem.Show();  
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Liste Liste = new Liste();
            Liste.Show();
        }

        private void UyeCikar_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
