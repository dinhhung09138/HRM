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
    public class DepartmentController : BaseController
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(
            IHttpContextAccessor httpContext,
            IDepartmentService departmentService) : base(httpContext)
        {
            _departmentService = departmentService;
        }

        [HttpPost("grid")]
        public async Task<IActionResult> Grid([FromBody] DepartmentGridParameterModel model)
        {
            return Ok(await _departmentService.GridAsync(model));
        }

        [HttpGet("dropdown")]
        public async Task<IActionResult> Dropdown()
        {
            return Ok(await _departmentService.DropdownAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Item(long id)
        {
            return Ok(await _departmentService.FindByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] DepartmentModel model)
        {
            model.CreateBy = base.EmployeeId;
            return Ok(await _departmentService.SaveAsync(model, true));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, DepartmentModel model)
        {
            model.UpdateBy = base.EmployeeId;
            return Ok(await _departmentService.SaveAsync(model, false));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            DepartmentModel model = new DepartmentModel();
            model.Id = id;
            model.UpdateBy = base.EmployeeId;
            return Ok(await _departmentService.DeleteAsync(model));
        }
    }
}
