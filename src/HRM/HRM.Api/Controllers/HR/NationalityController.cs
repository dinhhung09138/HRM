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
    public class NationalityController : BaseController
    {
        private readonly INationalityService _nationalityService;

        public NationalityController(
            IHttpContextAccessor httpContext,
            INationalityService nationalityService) : base(httpContext)
        {
            _nationalityService = nationalityService;
        }

        [HttpPost("grid")]
        public async Task<IActionResult> Grid([FromBody] NationalityGridParameterModel model)
        {
            return Ok(await _nationalityService.GridAsync(model));
        }

        [HttpGet("dropdown")]
        public async Task<IActionResult> Dropdown()
        {
            return Ok(await _nationalityService.DropdownAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Item(long id)
        {
            return Ok(await _nationalityService.FindByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] NationalityModel model)
        {
            model.CreateBy = base.EmployeeId;
            return Ok(await _nationalityService.SaveAsync(model, true));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, NationalityModel model)
        {
            model.UpdateBy = base.EmployeeId;
            return Ok(await _nationalityService.SaveAsync(model, false));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            NationalityModel model = new NationalityModel();
            model.Id = id;
            model.UpdateBy = base.EmployeeId;
            return Ok(await _nationalityService.DeleteAsync(model));
        }
    }
}
