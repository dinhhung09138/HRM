using HRM.Application.Common;
using HRM.Model.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HRM.Api.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class WardController : BaseController
    {
        private readonly IWardService _wardService;

        public WardController(
            IHttpContextAccessor httpContext,
            IWardService wardService) : base(httpContext)
        {
            _wardService = wardService;
        }

        [HttpPost("grid")]
        public async Task<IActionResult> Grid(WardGridParameterModel model)
        {
            return Ok(await _wardService.GridAsync(model));
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(WardModel model)
        {
            model.CreateBy = base.EmployeeId;
            return Ok(await _wardService.SaveAsync(model, true));
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateAsync(WardModel model)
        {
            model.UpdateBy = base.EmployeeId;
            return Ok(await _wardService.SaveAsync(model, false));
        }

        [HttpPost("delete")]
        public async Task<IActionResult> DeleteAsync(WardModel model)
        {
            model.UpdateBy = base.EmployeeId;
            return Ok(await _wardService.DeleteAsync(model));
        }

    }
}
