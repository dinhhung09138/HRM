using HRM.Api.Providers;
using HRM.Application.Common;
using HRM.Model.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IActionResult> Grid([FromBody] CertificatedGridParameterModel model)
        {
            return Ok(await _certificatedService.GridAsync(model));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Item(long id)
        {
            return Ok(await _certificatedService.FindByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CertificatedModel model)
        {
            model.CreateBy = base.EmployeeId;
            return Ok(await _certificatedService.SaveAsync(model, true));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, CertificatedModel model)
        {
            model.UpdateBy = base.EmployeeId;
            return Ok(await _certificatedService.SaveAsync(model, false));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            CertificatedModel model = new CertificatedModel();
            model.Id = id;
            model.UpdateBy = base.EmployeeId;
            return Ok(await _certificatedService.DeleteAsync(model));
        }
    }
}
