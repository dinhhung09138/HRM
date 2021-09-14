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
    public class EmployeeController : BaseController
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(
            IHttpContextAccessor httpContext,
            IEmployeeService employeeService) : base(httpContext)
        {
            _employeeService = employeeService;
        }

        [HttpPost("grid")]
        public async Task<IActionResult> Grid([FromBody] EmployeeGridParameterModel model)
        {
            return Ok(await _employeeService.GridAsync(model));
        }

        [HttpGet("dropdown")]
        public async Task<IActionResult> Dropdown()
        {
            return Ok(await _employeeService.DropdownAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Item(long id)
        {
            return Ok(await _employeeService.FindByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] EmployeeModel model)
        {
            model.CreateBy = base.EmployeeId;
            return Ok(await _employeeService.SaveAsync(model, true));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, EmployeeModel model)
        {
            model.UpdateBy = base.EmployeeId;
            return Ok(await _employeeService.SaveAsync(model, false));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            EmployeeModel model = new EmployeeModel();
            model.Id = id;
            model.UpdateBy = base.EmployeeId;
            return Ok(await _employeeService.DeleteAsync(model));
        }
    }
}
