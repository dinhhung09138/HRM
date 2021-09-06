using HRM.Api.Providers;
using HRM.Application.Assets;
using HRM.Model.Assets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HRM.Api.Controllers.Assets
{
    [Route("api/asset-contract-payment")]
    [ApiController]
    public class AssetContractPaymentController : BaseController
    {
        private readonly IAssetContractPaymentService _assetContractPaymentService;

        public AssetContractPaymentController(
            IHttpContextAccessor httpContext,
            IAssetContractPaymentService assetContractPaymentService) : base(httpContext)
        {
            _assetContractPaymentService = assetContractPaymentService;
        }

        [HttpPost("grid")]
        public async Task<IActionResult> Grid([FromBody] AssetContractPaymentGridParameterModel model)
        {
            return Ok(await _assetContractPaymentService.GridAsync(model));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Item(long id)
        {
            return Ok(await _assetContractPaymentService.FindByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] AssetContractPaymentModel model)
        {
            model.CreateBy = base.EmployeeId;
            return Ok(await _assetContractPaymentService.SaveAsync(model, true));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, AssetContractPaymentModel model)
        {
            model.UpdateBy = base.EmployeeId;
            return Ok(await _assetContractPaymentService.SaveAsync(model, false));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            AssetContractPaymentModel model = new AssetContractPaymentModel();
            model.Id = id;
            model.UpdateBy = base.EmployeeId;
            return Ok(await _assetContractPaymentService.DeleteAsync(model));
        }
    }
}
