using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BankacilikAPI.Model
{
    public class Sube:Base
    {
        public ICollection<Hesap> Hesaplar { get; set; }
        [Column("ad")]
        public string Ad { get; set; }
        [Column("il")]
        public string Il { get; set; }
        [Column("ilce")]
        public string Ilce { get; set; }
    }
}
