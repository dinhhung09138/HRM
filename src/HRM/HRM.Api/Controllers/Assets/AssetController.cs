using HRM.Api.Providers;
using HRM.Application.Assets;
using HRM.Model.Assets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HRM.Api.Controllers.Assets
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : BaseController
    {
        private readonly IAssetService _assetService;

        public AssetController(
            IHttpContextAccessor httpContext,
            IAssetService assetService) : base(httpContext)
        {
            _assetService = assetService;
        }

        [HttpPost("grid")]
        public async Task<IActionResult> Grid([FromBody] AssetGridParameterModel model)
        {
            return Ok(await _assetService.GridAsync(model));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Item(long id)
        {
            return Ok(await _assetService.FindByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] AssetModel model)
        {
            model.CreateBy = base.EmployeeId;
            return Ok(await _assetService.SaveAsync(model, true));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, AssetModel model)
        {
            model.UpdateBy = base.EmployeeId;
            return Ok(await _assetService.SaveAsync(model, false));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            AssetModel model = new AssetModel();
            model.Id = id;
            model.UpdateBy = base.EmployeeId;
            return Ok(await _assetService.DeleteAsync(model));
        }
    }
}
