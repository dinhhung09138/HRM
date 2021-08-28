using HRM.Api.Providers;
using HRM.Application.Common;
using HRM.Model.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HRM.Api.Controllers.Common
{
    [Route("api/marital-status")]
    [ApiController]
    public class MaritalStatusController : BaseController
    {
        private readonly IMaritalStatusService _maritalStatusService;

        public MaritalStatusController(
            IHttpContextAccessor httpContext,
            IMaritalStatusService maritalStatusService) : base(httpContext)
        {
            _maritalStatusService = maritalStatusService;
        }

        [HttpPost("grid")]
        public async Task<IActionResult> Grid([FromBody] MaritalStatusGridParameterModel model)
        {
            return Ok(await _maritalStatusService.GridAsync(model));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Item(long id)
        {
            return Ok(await _maritalStatusService.FindByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] MaritalStatusModel model)
        {
            model.CreateBy = base.EmployeeId;
            return Ok(await _maritalStatusService.SaveAsync(model, true));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, MaritalStatusModel model)
        {
            model.UpdateBy = base.EmployeeId;
            return Ok(await _maritalStatusService.SaveAsync(model, false));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            MaritalStatusModel model = new MaritalStatusModel();
            model.Id = id;
            model.UpdateBy = base.EmployeeId;
            return Ok(await _maritalStatusService.DeleteAsync(model));
        }
    }
}
