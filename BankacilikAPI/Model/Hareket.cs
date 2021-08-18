using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BankacilikAPI.Model
{
    [Table("hareket")]
    public class Hareket:Base
    {
        [Column("neredenId")]
        public int NeredenId { get; set; }
        [ForeignKey(nameof(NeredenId))]
        public Hesap GonderenHesap { get; set; }
        [Column("nereyeId")]
        public int NereyeId { get; set; }
        [ForeignKey(nameof(NereyeId))]
        public Hesap AlanHesap { get; set; }
        [Column("tutar")]
        public decimal Tutar { get; set; }
        [Column("tarih")]
        public DateTime Tarih { get; set; }
        [Column("onay")]
        public bool Onay { get; set; }
        [Column("onayTarihi")]
        public DateTime OnayTarihi { get; set; }
    }
}
