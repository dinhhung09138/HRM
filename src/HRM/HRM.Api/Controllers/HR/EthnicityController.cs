using HRM.Api.Providers;
using HRM.Application.HR;
using HRM.Model.HR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HRM.Api.Controllers.HR
{
    [Route("api/hr/[controller]")]
    [ApiController]
    public class EthnicityController : BaseController
    {
        private readonly IEthnicityService _EthnicityService;

        public EthnicityController(
            IHttpContextAccessor httpContext,
            IEthnicityService EthnicityService) : base(httpContext)
        {
            _EthnicityService = EthnicityService;
        }

        [HttpPost("grid")]
        public async Task<IActionResult> Grid([FromBody] EthnicityGridParameterModel model)
        {
            return Ok(await _EthnicityService.GridAsync(model));
        }

        [HttpGet("dropdown")]
        public async Task<IActionResult> Dropdown()
        {
            return Ok(await _EthnicityService.DropdownAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Item(long id)
        {
            return Ok(await _EthnicityService.FindByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] EthnicityModel model)
        {
            model.CreateBy = base.EmployeeId;
            return Ok(await _EthnicityService.SaveAsync(model, true));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, EthnicityModel model)
        {
            model.UpdateBy = base.EmployeeId;
            return Ok(await _EthnicityService.SaveAsync(model, false));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            EthnicityModel model = new EthnicityModel();
            model.Id = id;
            model.UpdateBy = base.EmployeeId;
            return Ok(await _EthnicityService.DeleteAsync(model));
        }
    }
}
