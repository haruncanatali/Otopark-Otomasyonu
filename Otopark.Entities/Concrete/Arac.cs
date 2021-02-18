using Otopark.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
                                    
namespace Otopark.Entities.Concrete
{
    public class Arac : IEntity
    {
        public int Id { get ; set ; }
        public string TcKimlikNo { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TelefonNo { get; set; }
        public string Plaka { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Renk { get; set; }

        public int KonumId { get; set; }

        public virtual Konum Konum { get; set; }
        public virtual Fatura Fatura { get; set; }
    }
}
