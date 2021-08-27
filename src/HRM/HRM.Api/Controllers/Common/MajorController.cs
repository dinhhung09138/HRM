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
    public class MajorController : BaseController
    {
        private readonly IMajorService _majorService;

        public MajorController(
            IHttpContextAccessor httpContext,
            IMajorService majorService) : base(httpContext)
        {
            _majorService = majorService;
        }

        [HttpPost("grid")]
        public async Task<IActionResult> Grid([FromBody] MajorGridParameterModel model)
        {
            return Ok(await _majorService.GridAsync(model));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Item(long id)
        {
            return Ok(await _majorService.FindByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] MajorModel model)
        {
            model.CreateBy = base.EmployeeId;
            return Ok(await _majorService.SaveAsync(model, true));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, MajorModel model)
        {
            model.UpdateBy = base.EmployeeId;
            return Ok(await _majorService.SaveAsync(model, false));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            MajorModel model = new MajorModel();
            model.Id = id;
            model.UpdateBy = base.EmployeeId;
            return Ok(await _majorService.DeleteAsync(model));
        }
    }
}
