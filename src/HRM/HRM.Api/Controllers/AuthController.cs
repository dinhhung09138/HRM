using HRM.Application.System;
using HRM.Model.Common;
using HRM.Model.System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HRM.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IAuthenticationService _authenticationService;

        public AuthController(
            IHttpContextAccessor httpContext,
            IAuthenticationService authenticationService) : base(httpContext)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> SignInAsync([FromBody] LoginModel model)
        {
            var token = await _authenticationService.SignInAsync(model);
            return Ok(token);
        }

    }
}
