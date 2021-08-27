using HRM.Api.Providers;
using HRM.Application.Common;
using HRM.Model.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HRM.Api.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : BaseController
    {
        private readonly ISchoolService _schoolService;

        public SchoolController(
            IHttpContextAccessor httpContext,
            ISchoolService schoolService) : base(httpContext)
        {
            _schoolService = schoolService;
        }

        [HttpPost("grid")]
        public async Task<IActionResult> Grid([FromBody] SchoolGridParameterModel model)
        {
            return Ok(await _schoolService.GridAsync(model));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Item(long id)
        {
            return Ok(await _schoolService.FindByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] SchoolModel model)
        {
            model.CreateBy = base.EmployeeId;
            return Ok(await _schoolService.SaveAsync(model, true));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, SchoolModel model)
        {
            model.UpdateBy = base.EmployeeId;
            return Ok(await _schoolService.SaveAsync(model, false));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            SchoolModel model = new SchoolModel();
            model.Id = id;
            model.UpdateBy = base.EmployeeId;
            return Ok(await _schoolService.DeleteAsync(model));
        }
    }
}
