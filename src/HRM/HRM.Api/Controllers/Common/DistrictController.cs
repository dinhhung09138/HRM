using HRM.Application.Common;
using HRM.Model.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;


namespace HRM.Api.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : BaseController
    {
        private readonly IDistrictService _districtService;

        public DistrictController(
            IHttpContextAccessor httpContext,
            IDistrictService districtService) : base(httpContext)
        {
            _districtService = districtService;
        }

        [HttpPost("grid")]
        public async Task<IActionResult> Grid(DistrictGridParameterModel model)
        {
            return Ok(await _districtService.GridAsync(model));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(DistrictModel model)
        {
            model.CreateBy = base.EmployeeId;
            return Ok(await _districtService.SaveAsync(model, true));
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync(DistrictModel model)
        {
            model.UpdateBy = base.EmployeeId;
            return Ok(await _districtService.SaveAsync(model, false));
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteAsync(DistrictModel model)
        {
            model.UpdateBy = base.EmployeeId;
            return Ok(await _districtService.DeleteAsync(model));
        }

    }
}
