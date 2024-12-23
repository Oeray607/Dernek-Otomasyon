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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GörselProgramlamaFinal
{
    public partial class UyeEkleGuncelle : Form
    {
        public UyeEkleGuncelle()
        {
            InitializeComponent();
            button2.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(textBox5.Text))
                {
                    MessageBox.Show("Lütfen geçerli bir ID giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Uye guncellenenUye = new Uye
                {
                    ID = Convert.ToInt32(textBox5.Text),
                    AdSoyad = textBox1.Text,
                    Telefon = textBox2.Text,
                    Email = textBox3.Text,
                    Adres = textBox4.Text,
                    KayıtTarihi = dateTimePicker1.Value,
                    GüncelBorc = Convert.ToDecimal(textBox7.Text),
                    Aile = textBox6.Text.ToString()
                };
                if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||
                   string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrEmpty(textBox6.Text))
                {
                    MessageBox.Show("Üye verilerinde eksik mevcut.", "DİKKAT!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else { 

              
                FonksiyonK FonksiyonK = new FonksiyonK();
                FonksiyonK.UyeGuncelle(guncellenenUye);

                MessageBox.Show("Üye başarıyla güncellendi!");

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox7.Clear();
                textBox6.Clear();
                textBox5.Clear();


                button2.Enabled = false;
                    }
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Hata: {ex.Message}", "Güncelleme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

               
                if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) ||
                    string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(textBox4.Text) || string.IsNullOrEmpty(textBox6.Text))
                {
                    MessageBox.Show("Lütfen tüm alanları doldurdurunuz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Uye yeniUye = new Uye
                {
                    AdSoyad = textBox1.Text,
                    Telefon = textBox2.Text,
                    Email = textBox3.Text,
                    Adres = textBox4.Text,
                    KayıtTarihi = dateTimePicker1.Value,
                    GüncelBorc = Convert.ToDecimal(textBox7.Text),
                    Aile = textBox6.Text.ToString()
                };

                FonksiyonK FonksiyonK = new FonksiyonK();
                FonksiyonK.UyeEkle(yeniUye);

                MessageBox.Show("Üye başarıyla eklendi!");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox7.Clear();
                textBox6.Clear();
                textBox5.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                int id = Convert.ToInt32(textBox5.Text);

                FonksiyonK FonksiyonK = new FonksiyonK();
                Uye uye = FonksiyonK.UyeTumBilgileriniGetir(id);

                if (uye != null)
                {
                    
                    textBox1.Text = uye.AdSoyad;
                    textBox2.Text = uye.Telefon;
                    textBox3.Text = uye.Email;
                    textBox4.Text = uye.Adres;
                    textBox6.Text = uye.Aile;
                    textBox7.Text = uye.GüncelBorc.ToString();
                    button2.Enabled = true; 
                    MessageBox.Show("Üye bilgileri başarıyla yüklendi.");
                }
                else
                {
                    MessageBox.Show("Girilen ID'ye ait üye bulunamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Lütfen geçerli bir ID giriniz.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Bir hata oluştu: {ex.Message}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void UyeEkleGuncelle_Load(object sender, EventArgs e)
        {
            textBox2.Text = "+90";
            toolTip1.SetToolTip(textBox2, "Telefon numarasını +90 formatında giriniz.");
            toolTip1.AutoPopDelay = 5000; 
            toolTip1.InitialDelay = 1; 
            toolTip1.ReshowDelay = 100;  // Yeniden gösterilme süresi (ms)
            toolTip1.IsBalloon = true;   // Baloncuk stili
        }

        private void UyeEkleGuncelle_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
