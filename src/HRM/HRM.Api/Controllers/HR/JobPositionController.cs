using HRM.Api.Providers;
using HRM.Application.HR;
using HRM.Model.HR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HRM.Api.Controllers.HR
{
    [Route("api/hr/job-position")]
    [ApiController]
    public class JobPositionController : BaseController
    {
        private readonly IJobPositionService _jobPositionService;

        public JobPositionController(
            IHttpContextAccessor httpContext,
            IJobPositionService jobPositionService) : base(httpContext)
        {
            _jobPositionService = jobPositionService;
        }

        [HttpPost("grid")]
        public async Task<IActionResult> Grid([FromBody] JobPositionGridParameterModel model)
        {
            return Ok(await _jobPositionService.GridAsync(model));
        }

        [HttpGet("dropdown")]
        public async Task<IActionResult> Dropdown()
        {
            return Ok(await _jobPositionService.DropdownAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Item(long id)
        {
            return Ok(await _jobPositionService.FindByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] JobPositionModel model)
        {
            model.CreateBy = base.EmployeeId;
            return Ok(await _jobPositionService.SaveAsync(model, true));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, JobPositionModel model)
        {
            model.UpdateBy = base.EmployeeId;
            return Ok(await _jobPositionService.SaveAsync(model, false));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            JobPositionModel model = new JobPositionModel();
            model.Id = id;
            model.UpdateBy = base.EmployeeId;
            return Ok(await _jobPositionService.DeleteAsync(model));
        }
    }
}
