using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BankacilikAPI.Model
{
    
    public enum Rol {
        Admin = 0,
        Musteri = 1 
    }
    [Table("kullanici")]
    public class Kullanici:Base
    {
        [InverseProperty(nameof(Hesap.Kullanici))]
        public ICollection<Hesap> Hesaplar { get; set; }
        [Column("ad")]
        public string Ad { get; set; }
        [Column("soyad")]
        public string Soyad { get; set; }
        [Column("tc")]
        public long Tc { get; set; }
        [Column("sifre")]
        public string Sifre { get; set; }
        [Column("rol")]
        public Rol Rol { get; set; }
        [Column("dogumTarihi")]
        public DateTime DogumTarihi { get; set; }
        [Column("telefon")]
        public long Telefon { get; set; }
        [Column("adres")]
        public string Adres { get; set; }
    }
}
