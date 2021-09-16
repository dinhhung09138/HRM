using HRM.Api.Providers;
using HRM.Application.HR;
using HRM.Model.HR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HRM.Api.Controllers.HR
{
    [Route("api/hr/[controller]")]
    [ApiController]
    public class BranchController : BaseController
    {
        private readonly IBranchService _branchService;

        public BranchController(
            IHttpContextAccessor httpContext,
            IBranchService branchService) : base(httpContext)
        {
            _branchService = branchService;
        }

        [HttpPost("grid")]
        public async Task<IActionResult> Grid([FromBody] BranchGridParameterModel model)
        {
            return Ok(await _branchService.GridAsync(model));
        }

        [HttpGet("dropdown")]
        public async Task<IActionResult> Dropdown()
        {
            return Ok(await _branchService.DropdownAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Item(long id)
        {
            return Ok(await _branchService.FindByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] BranchModel model)
        {
            model.CreateBy = base.EmployeeId;
            return Ok(await _branchService.SaveAsync(model, true));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, BranchModel model)
        {
            model.UpdateBy = base.EmployeeId;
            return Ok(await _branchService.SaveAsync(model, false));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            BranchModel model = new BranchModel();
            model.Id = id;
            model.UpdateBy = base.EmployeeId;
            return Ok(await _branchService.DeleteAsync(model));
        }
    }
}
