using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Otopark.API.Model
{
    public class RegisterModel
    {
        public string KullaniciAdi { get; set; }
        public string Sifre { get; set; }
        public string EMail { get; set; }
        public string TelefonNumarasi { get; set; }
    }
}
