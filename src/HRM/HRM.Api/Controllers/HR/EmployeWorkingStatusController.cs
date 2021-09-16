using HRM.Api.Providers;
using HRM.Application.HR;
using HRM.Model.HR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HRM.Api.Controllers.HR
{
    [Route("api/hr/employee-working-status")]
    [ApiController]
    public class EmployeeWorkingStatusController : BaseController
    {
        private readonly IEmployeeWorkingStatusService _employeeWorkingStatusService;

        public EmployeeWorkingStatusController(
            IHttpContextAccessor httpContext,
            IEmployeeWorkingStatusService employeeWorkingStatusService) : base(httpContext)
        {
            _employeeWorkingStatusService = employeeWorkingStatusService;
        }

        [HttpPost("grid")]
        public async Task<IActionResult> Grid([FromBody] EmployeeWorkingStatusGridParameterModel model)
        {
            return Ok(await _employeeWorkingStatusService.GridAsync(model));
        }

        [HttpGet("dropdown")]
        public async Task<IActionResult> Dropdown()
        {
            return Ok(await _employeeWorkingStatusService.DropdownAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Item(long id)
        {
            return Ok(await _employeeWorkingStatusService.FindByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] EmployeeWorkingStatusModel model)
        {
            model.CreateBy = base.EmployeeId;
            return Ok(await _employeeWorkingStatusService.SaveAsync(model, true));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, EmployeeWorkingStatusModel model)
        {
            model.UpdateBy = base.EmployeeId;
            return Ok(await _employeeWorkingStatusService.SaveAsync(model, false));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            EmployeeWorkingStatusModel model = new EmployeeWorkingStatusModel();
            model.Id = id;
            model.UpdateBy = base.EmployeeId;
            return Ok(await _employeeWorkingStatusService.DeleteAsync(model));
        }
    }
}
