using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BankacilikAPI.Model
{
    public enum KurCinsi { 
        TL = 0, 
        USD = 1, 
        EURO = 2, 
        Sterlin = 3 
    }
    [Table("hesap")]
    public class Hesap:Base
    {
        [InverseProperty("GonderenHesap")]
        public ICollection<Hareket> HesaptanHareket { get; set; }
        [InverseProperty("AlanHesap")]
        public ICollection<Hareket> HesabaHareket { get; set; }
        [Column("kullaniciId")]
        public int KullaniciId { get; set; }
        [ForeignKey(nameof(KullaniciId))]
        public Kullanici Kullanici { get; set; }
        [Column("subeId")]
        public int SubeId { get; set; }
        [ForeignKey(nameof(SubeId))]
        public Sube Sube { get; set; }
        [Column("kurCinsi")]
        public KurCinsi KurCinsi { get; set; }
        [Column("bakiye")]
        public decimal Bakiye { get; set; }
        [Column("iban")]
        public string Iban { get; set; }
    }
}
