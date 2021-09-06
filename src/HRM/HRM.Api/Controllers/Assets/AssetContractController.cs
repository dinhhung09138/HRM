using HRM.Api.Providers;
using HRM.Application.Assets;
using HRM.Model.Assets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HRM.Api.Controllers.Assets
{
    [Route("api/asset-contract")]
    [ApiController]
    public class AssetContractController : BaseController
    {
        private readonly IAssetContractService _assetContractService;

        public AssetContractController(
            IHttpContextAccessor httpContext,
            IAssetContractService assetContractService) : base(httpContext)
        {
            _assetContractService = assetContractService;
        }

        [HttpPost("grid")]
        public async Task<IActionResult> Grid([FromBody] AssetContractGridParameterModel model)
        {
            return Ok(await _assetContractService.GridAsync(model));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Item(long id)
        {
            return Ok(await _assetContractService.FindByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] AssetContractModel model)
        {
            model.CreateBy = base.EmployeeId;
            return Ok(await _assetContractService.SaveAsync(model, true));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, AssetContractModel model)
        {
            model.UpdateBy = base.EmployeeId;
            return Ok(await _assetContractService.SaveAsync(model, false));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            AssetContractModel model = new AssetContractModel();
            model.Id = id;
            model.UpdateBy = base.EmployeeId;
            return Ok(await _assetContractService.DeleteAsync(model));
        }
    }
}
