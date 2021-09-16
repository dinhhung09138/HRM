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
    public class PositionController : BaseController
    {
        private readonly IPositionService _positionService;

        public PositionController(
            IHttpContextAccessor httpContext,
            IPositionService positionService) : base(httpContext)
        {
            _positionService = positionService;
        }

        [HttpPost("grid")]
        public async Task<IActionResult> Grid([FromBody] PositionGridParameterModel model)
        {
            return Ok(await _positionService.GridAsync(model));
        }

        [HttpGet("dropdown")]
        public async Task<IActionResult> Dropdown()
        {
            return Ok(await _positionService.DropdownAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Item(long id)
        {
            return Ok(await _positionService.FindByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] PositionModel model)
        {
            model.CreateBy = base.EmployeeId;
            return Ok(await _positionService.SaveAsync(model, true));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, PositionModel model)
        {
            model.UpdateBy = base.EmployeeId;
            return Ok(await _positionService.SaveAsync(model, false));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            PositionModel model = new PositionModel();
            model.Id = id;
            model.UpdateBy = base.EmployeeId;
            return Ok(await _positionService.DeleteAsync(model));
        }
    }
}
