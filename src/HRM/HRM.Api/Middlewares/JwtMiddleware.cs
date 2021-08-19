using HRM.Application.System;
using HRM.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HRM.Api.Middlewares
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ApiSettingModel _apiSettingModel;

        public JwtMiddleware(RequestDelegate next, IOptions<ApiSettingModel> apiSettingModel)
        {
            _next = next;
            _apiSettingModel = apiSettingModel.Value;
        }

        public async Task Invoke(HttpContext context, IAuthenticationService authService)
        {
            if (context.Request.Headers["Authorization"].FirstOrDefault() != null)
            {
                var token = context.Request.Headers["Authorization"].FirstOrDefault().Split(" ").Last();

                if (token != null)
                {
                    AttachUserToContext(context, authService, token);
                }
            }

            await _next(context);
        }

        private void AttachUserToContext(HttpContext context, IAuthenticationService authService, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_apiSettingModel.SecretKey);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var employeeId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                // attach user to context on successful jwt validation
                context.Items["EmployeeId"] = employeeId;
            }
            catch(Exception ex)
            {

            }
        }

    }
}
