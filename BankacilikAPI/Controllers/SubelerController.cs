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
    public class SubelerController
    {
        private readonly DataContext context;
        public SubelerController(DataContext context)
        {
            this.context = context;
        }
        [HttpGet("[action]")]
        public async Task<IEnumerable<Sube>> SubelerGet()
        {
            return await context.Subeler.Include(x=>x.Hesaplar).ToListAsync();
        }
        [HttpPost("[action]")]
        public async Task<string> SubePost(Sube sube)
        {
            await context.Subeler.AddAsync(sube);
            _ = await context.SaveChangesAsync();
            return "Şube eklendi!";
        }
    }
}
