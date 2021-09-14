using HRM.Api.Providers;
using HRM.Application.HR;
using HRM.Model.HR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HRM.Api.Controllers.HR
{
    [Route("api/hr/employee-info")]
    [ApiController]
    public class EmployeeInfoController : BaseController
    {
        private readonly IEmployeeInfoService _employeeInfoService;

        public EmployeeInfoController(
            IHttpContextAccessor httpContext,
            IEmployeeInfoService employeeInfoService) : base(httpContext)
        {
            _employeeInfoService = employeeInfoService;
        }

        [HttpGet("find-by-employee/{id}")]
        public async Task<IActionResult> FindByEmployeeIdAsync(long id)
        {
            return Ok(await _employeeInfoService.FindByEmployeeIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] EmployeeInfoModel model)
        {
            model.CreateBy = base.EmployeeId;
            return Ok(await _employeeInfoService.SaveAsync(model, true));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, EmployeeInfoModel model)
        {
            model.UpdateBy = base.EmployeeId;
            return Ok(await _employeeInfoService.SaveAsync(model, false));
        }
    }
}
