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
    public class HesaplarController
    {
        private readonly DataContext context;
        public HesaplarController(DataContext context)
        {
            this.context = context;
        }
        [HttpGet("[action]")]
        public async Task<IEnumerable<Hesap>> HesapGet()
        {
            return await context.Hesaplar
                                 .Include(x=>x.HesaptanHareket)
                                 .Include(x=>x.HesabaHareket).ToListAsync();

        }
        [HttpPost("[action]")]
        public async Task<string> HesapPost(Hesap hesap)
        {
            await context.Hesaplar.AddAsync(hesap);
            _ = await context.SaveChangesAsync();
            return "Hesap eklendi!";
        }
    }
}
