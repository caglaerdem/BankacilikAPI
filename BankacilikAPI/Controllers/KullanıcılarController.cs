using BankacilikAPI.Data;
using BankacilikAPI.Filters;
using BankacilikAPI.Model;
using Microsoft.AspNetCore.Http;
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
        [HttpPost("[action]")]
        public async Task<string> Login(long tcNum, string parola)
        {
            if (await context.Kullanicilar.AnyAsync(x => x.Tc == tcNum) == true)
            {
                var kullanici = await context.Kullanicilar.FirstOrDefaultAsync(x => x.Tc == tcNum);
                if (kullanici.Sifre ==parola)
                {
                    HttpContext.Session.SetString("kullanici_adi", kullanici.Ad +" "+ kullanici.Soyad);
                    HttpContext.Session.SetString("kullanici_id", kullanici.Id.ToString());
                    HttpContext.Session.SetString("login", "evet");
                    HttpContext.Session.SetString("kullanici_rol", ((int)kullanici.Rol).ToString());
                    return SelamVer();
                   
                }
                else return "Şifre yanlış!";
                
            }
            else return "Geçerli bir Tc numarası giriniz.";

            
           
        }
        [HttpGet("[action]")]
        [Authentication]
        [Authorization(Rol.Admin)]
        public string SelamVer()
        {
            return "Merhaba " + HttpContext.Session.GetString("kullanici_adi") + " sisteme hosgeldiniz, id'niz= "
                + HttpContext.Session.GetString("kullanici_id")+" ,Rolunuz= " + HttpContext.Session.GetString("kullanici_rol");          
        }
    }
}
