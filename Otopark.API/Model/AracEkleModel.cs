using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Otopark.API.Model
{
    public class AracEkleModel
    {
        public int Id { get; set; }
        public string TcKimlikNo { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TelefonNo { get; set; }
        public string Plaka { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Renk { get; set; }

        public string KonumId { get; set; }
    }
}
