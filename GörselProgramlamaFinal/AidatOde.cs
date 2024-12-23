using GörselProgramlamaFinal.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GörselProgramlamaFinal
{
    public partial class AidatOde : Form
    {
        FonksiyonK FonksiyonK = new FonksiyonK(); 
        public AidatOde()
        {
            InitializeComponent();
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
               
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Lütfen ID giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; 
                }

                
                int id = int.Parse(textBox1.Text);
                Uye uye = FonksiyonK.UyeBilgileriniGetir(id);

                if (uye != null)
                {
                    label3.Text = "Ad Soyad: " + uye.AdSoyad;
                    label4.Text = "Güncel Borç: " + uye.GüncelBorc.ToString("C");
                    label3.Visible = true;
                    label4.Visible = true;
                    label8.Visible = true;
                    label9.Visible = true;
                    label10.Visible = true;
                    label11.Visible = true;
                    label12.Visible = true;
                    label13.Visible = true;
                    button2.Enabled = true;
                    textBox2.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Kullanıcı bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(textBox1.Text);
            decimal odemeMiktari = Convert.ToDecimal(textBox2.Text);

            FonksiyonK FonksiyonK = new FonksiyonK();
            Uye uye = FonksiyonK.UyeBilgileriniGetir(id);

            if (uye == null)
            {
                MessageBox.Show("Girilen ID'ye ait üye bulunamadı.","Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (odemeMiktari > uye.GüncelBorc)
            {
                MessageBox.Show("Girilen miktarı kontrol ediniz.","Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //if (Math.Round(uye.GüncelBorc, 6) == 0) 
            //{
            //    MessageBox.Show("Üyenin borcu bulunmamaktadır.", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}

      
            FonksiyonK.AidatOde(id, odemeMiktari);

         
            FonksiyonK.MakbuzOlustur(uye, odemeMiktari);

            MessageBox.Show("Ödeme başarıyla tamamlandı.","Başarılı");
            label3.Visible=false;
            label4.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
            textBox1.Clear();
            textBox2.Clear();
            button2.Enabled = false;
            textBox2.Enabled=false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            AidatTahsilat AidatTahsilat = new AidatTahsilat();  
            AidatTahsilat.Show();  
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Liste Liste = new Liste();
            Liste.Show();
        }

        private void AidatOde_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            textBox2.Enabled = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
            string input = textBox2.Text;

           
            if (string.IsNullOrWhiteSpace(input))
                return;

           
            int cursorPosition = textBox2.SelectionStart;

            
            string unformattedInput = input.Replace(".", "").Replace(",", "");

           
            if (decimal.TryParse(unformattedInput, out decimal value))
            {
                
                string formattedValue = string.Format("{0:N0}", value);

                
                int diff = formattedValue.Length - unformattedInput.Length;
                cursorPosition += diff;

               
                textBox2.Text = formattedValue;

             
                textBox2.SelectionStart = Math.Max(0, Math.Min(cursorPosition, textBox2.Text.Length));
            }
            else
            {
                
                MessageBox.Show("Lütfen sadece sayısal bir değer girin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox2.Text = "";
                textBox2.SelectionStart = 0;
            }

        }

        private void AidatOde_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}

