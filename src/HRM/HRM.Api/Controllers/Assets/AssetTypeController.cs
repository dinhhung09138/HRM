using HRM.Api.Providers;
using HRM.Application.Assets;
using HRM.Model.Assets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HRM.Api.Controllers.Assets
{
    [Route("api/asset-type")]
    [ApiController]
    public class AssetTypeController : BaseController
    {
        private readonly IAssetTypeService _assetTypeService;

        public AssetTypeController(
            IHttpContextAccessor httpContext,
            IAssetTypeService assetTypeService) : base(httpContext)
        {
            _assetTypeService = assetTypeService;
        }

        [HttpPost("grid")]
        public async Task<IActionResult> Grid([FromBody] AssetTypeGridParameterModel model)
        {
            return Ok(await _assetTypeService.GridAsync(model));
        }

        [HttpGet("dropdown")]
        public async Task<IActionResult> Dropdown()
        {
            return Ok(await _assetTypeService.DropdownAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Item(long id)
        {
            return Ok(await _assetTypeService.FindByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] AssetTypeModel model)
        {
            model.CreateBy = base.EmployeeId;
            return Ok(await _assetTypeService.SaveAsync(model, true));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, AssetTypeModel model)
        {
            model.UpdateBy = base.EmployeeId;
            return Ok(await _assetTypeService.SaveAsync(model, false));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            AssetTypeModel model = new AssetTypeModel();
            model.Id = id;
            model.UpdateBy = base.EmployeeId;
            return Ok(await _assetTypeService.DeleteAsync(model));
        }
    }
}
