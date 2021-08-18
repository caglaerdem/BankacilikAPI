using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace BankacilikAPI.Model
{
    public class Base
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
    }
}
