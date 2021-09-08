using BankacilikAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankacilikAPI.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizationAttribute:ActionFilterAttribute
    {
        private readonly Rol rol;
        public AuthorizationAttribute(Rol rol)
        {
            this.rol = rol;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if ((Rol)Convert.ToInt32(context.HttpContext.Session.GetString("kullanici_rol")) != rol)
            {
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
            }
            base.OnActionExecuting(context);
        }
    }
}
