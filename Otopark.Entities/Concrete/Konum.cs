using Otopark.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Otopark.Entities.Concrete
{
    public class Konum : IEntity
    {
        public int Id { get; set ; }
        public int Kat { get; set; }
        public string Yer { get; set; }
        public string Cephe { get; set; }
        public bool Durum { get; set; }

        public virtual Arac Arac { get; set; }
    }
}
