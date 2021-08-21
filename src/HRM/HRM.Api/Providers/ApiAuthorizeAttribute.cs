using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace HRM.Api.Providers
{
    public class ApiAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter, IActionFilter
    {
        public ApiAuthorizeAttribute()
        {

        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var claims = context.HttpContext.User.Identity as ClaimsIdentity;

            if (claims != null && claims.IsAuthenticated == true)
            {
                return;
            }

            context.Result = new UnauthorizedResult();
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var isAuthenticated = context.HttpContext.User.Identity.IsAuthenticated;
            if (isAuthenticated)
            {
                return;
            }
            context.Result = new UnauthorizedResult();
        }
    }
}
