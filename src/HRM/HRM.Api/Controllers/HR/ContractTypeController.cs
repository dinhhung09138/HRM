using HRM.Api.Providers;
using HRM.Application.HR;
using HRM.Model.HR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HRM.Api.Controllers.HR
{
    [Route("api/hr/contract-type")]
    [ApiController]
    public class ContractTypeController : BaseController
    {
        private readonly IContractTypeService _contractTypeService;

        public ContractTypeController(
            IHttpContextAccessor httpContext,
            IContractTypeService contractTypeService) : base(httpContext)
        {
            _contractTypeService = contractTypeService;
        }

        [HttpPost("grid")]
        public async Task<IActionResult> Grid([FromBody] ContractTypeGridParameterModel model)
        {
            return Ok(await _contractTypeService.GridAsync(model));
        }

        [HttpGet("dropdown")]
        public async Task<IActionResult> Dropdown()
        {
            return Ok(await _contractTypeService.DropdownAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Item(long id)
        {
            return Ok(await _contractTypeService.FindByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ContractTypeModel model)
        {
            model.CreateBy = base.EmployeeId;
            return Ok(await _contractTypeService.SaveAsync(model, true));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, ContractTypeModel model)
        {
            model.UpdateBy = base.EmployeeId;
            return Ok(await _contractTypeService.SaveAsync(model, false));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            ContractTypeModel model = new ContractTypeModel();
            model.Id = id;
            model.UpdateBy = base.EmployeeId;
            return Ok(await _contractTypeService.DeleteAsync(model));
        }
    }
}
