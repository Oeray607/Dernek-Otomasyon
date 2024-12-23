using GörselProgramlamaFinal.Entities;
using iText.Kernel.Pdf;
using iText.Layout.Element;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iText.Layout;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Runtime.Remoting.Contexts;


namespace GörselProgramlamaFinal
{
    internal class FonksiyonK
    {
        private VeriErisimK VeriErisimK = new VeriErisimK(); 

        public void UyeEkle(Uye uye)
        {
            VeriErisimK VeriErisimK = new VeriErisimK();
            if (VeriErisimK.UyeVarMi(uye.ID))
            {
                throw new Exception("Bu ID'ye sahip bir üye zaten mevcut. Lütfen farklı bir ID kullanın.");
            }
    
            VeriErisimK.UyeEkle(uye); 
        }


        public bool UyeVarMi(int id)
        {
            return VeriErisimK.UyeVarMi(id);
        }

        public void UyeSil(int uyeID)
        {
            
            VeriErisimK.UyeSil(uyeID); 
        }

        public List<Uye> UyeListele()
        {
            return VeriErisimK.UyeListele();
        }

        public void UyeGuncelle(Uye uye)
        {
            VeriErisimK.UyeGuncelle(uye);
        }

        public Uye UyeIDileGetir(int uyeID)
        {
            return VeriErisimK.UyeIDileGetir(uyeID); 
        }

        public List<string> UyeEmailListele()
        {
            return VeriErisimK.UyeEmailListele(); 
        }

        public Uye UyeBilgileriniGetir(int id)
        {
            return VeriErisimK.UyeBilgileriniGetir(id); 
        }
        public Uye UyeTumBilgileriniGetir(int id)
        {
            return VeriErisimK.UyeTumBilgileriniGetir(id); 
        }

        public void AidatOde(int id, decimal odemeMiktari)
        {
            Uye uye = UyeBilgileriniGetir(id);

            if (uye == null)
            {
                throw new Exception("Kullanıcı bulunamadı.");
            }

            if (odemeMiktari > uye.GüncelBorc)
            {
                throw new Exception("Ödeme miktarı güncel borçtan fazla olamaz.");
            }

            VeriErisimK.AidatOde(id, odemeMiktari); 
        }

        public void MakbuzOlustur(Uye uye, decimal odemeMiktari)
        {
            
            string pdfPath = $"Makbuz_{uye.AdSoyad}_MakbuzNO_{uye.ID}.pdf";

         
            using (FileStream stream = new FileStream(pdfPath, FileMode.Create))
            {
 
                PdfWriter writer = new PdfWriter(stream);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);

             
                document.Add(new Paragraph("Aidat Ödeme Makbuzu")
                    .SetTextAlignment(iText.Layout.Properties.TextAlignment.CENTER)
                    .SetFontSize(18));

           
                document.Add(new Paragraph($"Ad Soyad: {uye.AdSoyad}"));
                document.Add(new Paragraph($"ID: {uye.ID}"));
                document.Add(new Paragraph($"Ödenen Tutar: {odemeMiktari:C}")); 
                document.Add(new Paragraph($"Kalan Güncel Borç: {(uye.GüncelBorc - odemeMiktari):C}"));
                document.Add(new Paragraph($"Tarih: {DateTime.Now:yyyy-MM-dd HH:mm:ss}"));

               
                document.Close();
            }

           
            MessageBox.Show($"Makbuz oluşturuldu: {pdfPath}", "Makbuz Oluşturma", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public List<Uye> BorclariListele()
        {
            return VeriErisimK.BorclariListele();
        }

        public void EtkinlikEpostasiGonder(string etkinlikAdi, string etkinlikYeri, DateTime etkinlikSaati)
        {
           
            List<string> emailListesi = VeriErisimK.UyeEmailListele();

        
            string mesaj = $"{etkinlikAdi} etkinliğimize herkes davetlidir. Etkinliğimiz {etkinlikSaati} tarihinde  olacaktır. Hepinizi bekliyoruz.<br>Etkinlik Yeri: {etkinlikYeri}.<br>Bu mesaj Kümbetli Köyü Derneği tarafından gönderilmektedir.<br>Toplu mesajdır lütfen cevap vermeyiniz.";



       
            foreach (var email in emailListesi)
            {
                MailGonder(email, mesaj);  
            }
        }

        private void MailGonder(string aliciEmail, string mesaj)
        {


            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("eraydernekproje@gmail.com", "wxzevmxwgjtmjmiu"),
                EnableSsl = true
            };

            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress("eraydernekproje@gmail.com"),
                Subject = "Etkinlik Davetiyesi",
                Body = mesaj,
                IsBodyHtml = true
            };

            mailMessage.To.Add(aliciEmail); 

            try
            {
                smtpClient.Send(mailMessage);  
                MessageBox.Show("E-posta başarıyla gönderildi!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"E-posta gönderme hatası: {ex.Message}");
            }
        }

        public void DuyuruGonder(string aliciEmail, string mesaj)
        {

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("eraydernekproje@gmail.com", "wxzevmxwgjtmjmiu"),
                EnableSsl = true
            };

            MailMessage mailMessage = new MailMessage
            {
                From = new MailAddress("eraydernekproje@gmail.com"),
                Subject = "Kümbetli Köyü Derneği",
                Body = mesaj,
                IsBodyHtml = true
            };

            mailMessage.To.Add(aliciEmail);

            try
            {
                smtpClient.Send(mailMessage); 
                MessageBox.Show("E-posta başarıyla gönderildi!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"E-posta gönderme hatası: {ex.Message}");
            }
        }
        public void AidatGuncelle(int uyeID, decimal aidat)
        {
            VeriErisimK.AidatGuncelle(uyeID, aidat);
        }

       
        public void AidatGuncellemeTumu(decimal aidat)
        {
            List<Uye> uyeler = VeriErisimK.UyeListele();
            foreach (var uye in uyeler)
            {
                AidatGuncelle(uye.ID, aidat);
            }
        }


    }
}
