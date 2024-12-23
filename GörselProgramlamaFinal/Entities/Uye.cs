using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GörselProgramlamaFinal.Entities
{
    internal class Uye
    {
        public int ID { get; set; }
        public string AdSoyad { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }
        public string Adres { get; set; }
        public DateTime KayıtTarihi { get; set; }
        public decimal GüncelBorc { get; set; }
        public string Aile { get; set; }

    }
}
