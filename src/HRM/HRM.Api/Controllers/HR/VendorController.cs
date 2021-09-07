using HRM.Api.Providers;
using HRM.Application.HR;
using HRM.Model.HR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HRM.Api.Controllers.HR
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendorController : BaseController
    {
        private readonly IVendorService _vendorService;

        public VendorController(
            IHttpContextAccessor httpContext,
            IVendorService vendorService) : base(httpContext)
        {
            _vendorService = vendorService;
        }

        [HttpPost("grid")]
        public async Task<IActionResult> Grid([FromBody] VendorGridParameterModel model)
        {
            return Ok(await _vendorService.GridAsync(model));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Item(long id)
        {
            return Ok(await _vendorService.FindByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] VendorModel model)
        {
            model.CreateBy = base.EmployeeId;
            return Ok(await _vendorService.SaveAsync(model, true));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, VendorModel model)
        {
            model.UpdateBy = base.EmployeeId;
            return Ok(await _vendorService.SaveAsync(model, false));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            VendorModel model = new VendorModel();
            model.Id = id;
            model.UpdateBy = base.EmployeeId;
            return Ok(await _vendorService.DeleteAsync(model));
        }
    }
}
