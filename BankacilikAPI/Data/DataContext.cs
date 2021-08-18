using BankacilikAPI.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankacilikAPI.Data
{
    public class DataContext:DbContext
    {
        public DbSet<Kullanıcı> Kullanicilar { get; set; }
        public DbSet<Hesap> Hesaplar { get; set; }
        public DbSet<Sube>  Subeler { get; set; }
        public DbSet<Hareket> Hareketler { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
