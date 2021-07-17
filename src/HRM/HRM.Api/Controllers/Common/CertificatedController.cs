using HRM.Application.Common;
using HRM.Model.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HRM.Api.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificatedController : BaseController
    {
        private readonly ICertificatedService _certificatedService;

        public CertificatedController(
            IHttpContextAccessor httpContext,
            ICertificatedService certificatedService) : base(httpContext)
        {
            _certificatedService = certificatedService;
        }

        [HttpPost("grid")]
        public async Task<IActionResult> Grid(CertificatedGridParameterModel model)
        {
            return Ok(await _certificatedService.GridAsync(model));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(CertificatedModel model)
        {
            model.CreateBy = base.EmployeeId;
            return Ok(await _certificatedService.SaveAsync(model, true));
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync(CertificatedModel model)
        {
            model.UpdateBy = base.EmployeeId;
            return Ok(await _certificatedService.SaveAsync(model, false));
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteAsync(CertificatedModel model)
        {
            model.UpdateBy = base.EmployeeId;
            return Ok(await _certificatedService.DeleteAsync(model));
        }


    }
}
