using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.Api.Controllers
{
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContext;

        public long EmployeeId { get; set; } = 1; //TODO

        public BaseController(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }
    }
}
