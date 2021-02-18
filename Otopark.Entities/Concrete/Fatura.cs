using Otopark.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otopark.Entities.Concrete
{
    public class Fatura : IEntity
    {
        public int Id { get ; set ; }
        public string ParkSuresi { get; set; }
        public decimal Ucret { get; set; }
        public DateTime Tarih { get; set; }

        public int AracId { get; set; }

        public virtual Arac Arac { get; set; }
    }
}
