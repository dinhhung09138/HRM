using HRM.Application.Common;
using HRM.Model.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HRM.Api.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinceController : BaseController
    {
        private readonly IProvinceService _provinceService;

        public ProvinceController(
            IHttpContextAccessor httpContext,
            IProvinceService provinceService) : base(httpContext)
        {
            _provinceService = provinceService;
        }

        [HttpPost("grid")]
        public async Task<IActionResult> Grid(ProvinceGridParameterModel model)
        {
            return Ok(await _provinceService.GridAsync(model));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(ProvinceModel model)
        {
            model.CreateBy = base.EmployeeId;
            return Ok(await _provinceService.SaveAsync(model, true));
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync(ProvinceModel model)
        {
            model.UpdateBy = base.EmployeeId;
            return Ok(await _provinceService.SaveAsync(model, false));
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteAsync(ProvinceModel model)
        {
            model.UpdateBy = base.EmployeeId;
            return Ok(await _provinceService.DeleteAsync(model));
        }

    }
}
