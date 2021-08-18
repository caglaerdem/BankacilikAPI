using BankacilikAPI.Data;
using BankacilikAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankacilikAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HareketlerController
    {
        private readonly DataContext context;
        public HareketlerController(DataContext context)
        {
            this.context = context;
        }
        [HttpGet("[action]")]
        public async Task<IEnumerable<Hareket>> HareketlerGet()
        {
            return await context.Hareketler
                        .Include(x => x.AlanHesap)
                        .Include(y => y.GonderenHesap).ToListAsync();
        }
        [HttpPost("[action]")]
        public async Task<Hareket> HareketPost(Hareket hareket)
        {
           var yapilan = await context.Hareketler.AddAsync(hareket);
            _ = await context.SaveChangesAsync();
            return yapilan.Entity;
        }
    }
}
