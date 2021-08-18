﻿using BankacilikAPI.Data;
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
    public class KullanıcılarController:ControllerBase
    {
        private readonly DataContext context;
        public KullanıcılarController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Kullanici>> KullaniciGet()
        {
            return await context.Kullanicilar.Include(x=>x.Hesaplar).ToListAsync();
        }
        [HttpPost("[action]")]
        public async Task<string> KullaniciPost(Kullanici kullanici)
        {
            await context.Kullanicilar.AddAsync(kullanici);
            _ = await context.SaveChangesAsync();
            return "Kullanıcı eklendi!";
        }
    }
}
