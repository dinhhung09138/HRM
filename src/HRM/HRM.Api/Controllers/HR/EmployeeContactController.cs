using HRM.Api.Providers;
using HRM.Application.HR;
using HRM.Model.HR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HRM.Api.Controllers.HR
{
    [Route("api/hr/employee-contact")]
    [ApiController]
    public class EmployeeContactController : BaseController
    {
        private readonly IEmployeeContactService _employeeContactService;

        public EmployeeContactController(
            IHttpContextAccessor httpContext,
            IEmployeeContactService employeeContactService) : base(httpContext)
        {
            _employeeContactService = employeeContactService;
        }

        [HttpGet("find-by-employee/{id}")]
        public async Task<IActionResult> FindByEmployeeIdAsync(long id)
        {
            return Ok(await _employeeContactService.FindByEmployeeIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] EmployeeContactModel model)
        {
            model.CreateBy = base.EmployeeId;
            return Ok(await _employeeContactService.SaveAsync(model, true));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, EmployeeContactModel model)
        {
            model.UpdateBy = base.EmployeeId;
            return Ok(await _employeeContactService.SaveAsync(model, false));
        }
    }
}
