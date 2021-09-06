using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankacilikAPI.Filters
{
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Method)]
    public class AuthenticationAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.Session.GetString("login") != "evet")
            {
                context.Result = new StatusCodeResult(StatusCodes.Status401Unauthorized);
            }
            base.OnActionExecuting(context);
        }
    }
}
