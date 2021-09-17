using HRM.Api.Providers;
using HRM.Application.HR;
using HRM.Model.HR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HRM.Api.Controllers.HR
{
    [Route("api/hr/leave-type")]
    [ApiController]
    public class LeaveTypeController : BaseController
    {
        private readonly ILeaveTypeService _LeaveTypeService;

        public LeaveTypeController(
            IHttpContextAccessor httpContext,
            ILeaveTypeService LeaveTypeService) : base(httpContext)
        {
            _LeaveTypeService = LeaveTypeService;
        }

        [HttpPost("grid")]
        public async Task<IActionResult> Grid([FromBody] LeaveTypeGridParameterModel model)
        {
            return Ok(await _LeaveTypeService.GridAsync(model));
        }

        [HttpGet("dropdown")]
        public async Task<IActionResult> Dropdown()
        {
            return Ok(await _LeaveTypeService.DropdownAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Item(long id)
        {
            return Ok(await _LeaveTypeService.FindByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] LeaveTypeModel model)
        {
            model.CreateBy = base.EmployeeId;
            return Ok(await _LeaveTypeService.SaveAsync(model, true));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, LeaveTypeModel model)
        {
            model.UpdateBy = base.EmployeeId;
            return Ok(await _LeaveTypeService.SaveAsync(model, false));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            LeaveTypeModel model = new LeaveTypeModel();
            model.Id = id;
            model.UpdateBy = base.EmployeeId;
            return Ok(await _LeaveTypeService.DeleteAsync(model));
        }
    }
}
