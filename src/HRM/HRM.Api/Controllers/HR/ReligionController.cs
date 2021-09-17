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
    public class ReligionController : BaseController
    {
        private readonly IReligionService _religionService;

        public ReligionController(
            IHttpContextAccessor httpContext,
            IReligionService religionService) : base(httpContext)
        {
            _religionService = religionService;
        }

        [HttpPost("grid")]
        public async Task<IActionResult> Grid([FromBody] ReligionGridParameterModel model)
        {
            return Ok(await _religionService.GridAsync(model));
        }

        [HttpGet("dropdown")]
        public async Task<IActionResult> Dropdown()
        {
            return Ok(await _religionService.DropdownAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Item(long id)
        {
            return Ok(await _religionService.FindByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ReligionModel model)
        {
            model.CreateBy = base.EmployeeId;
            return Ok(await _religionService.SaveAsync(model, true));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, ReligionModel model)
        {
            model.UpdateBy = base.EmployeeId;
            return Ok(await _religionService.SaveAsync(model, false));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            ReligionModel model = new ReligionModel();
            model.Id = id;
            model.UpdateBy = base.EmployeeId;
            return Ok(await _religionService.DeleteAsync(model));
        }
    }
}
