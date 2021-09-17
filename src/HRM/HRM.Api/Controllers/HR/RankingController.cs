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
    public class RankingController : BaseController
    {
        private readonly IRankingService _RankingService;

        public RankingController(
            IHttpContextAccessor httpContext,
            IRankingService RankingService) : base(httpContext)
        {
            _RankingService = RankingService;
        }

        [HttpPost("grid")]
        public async Task<IActionResult> Grid([FromBody] RankingGridParameterModel model)
        {
            return Ok(await _RankingService.GridAsync(model));
        }

        [HttpGet("dropdown")]
        public async Task<IActionResult> Dropdown()
        {
            return Ok(await _RankingService.DropdownAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Item(long id)
        {
            return Ok(await _RankingService.FindByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] RankingModel model)
        {
            model.CreateBy = base.EmployeeId;
            return Ok(await _RankingService.SaveAsync(model, true));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, RankingModel model)
        {
            model.UpdateBy = base.EmployeeId;
            return Ok(await _RankingService.SaveAsync(model, false));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            RankingModel model = new RankingModel();
            model.Id = id;
            model.UpdateBy = base.EmployeeId;
            return Ok(await _RankingService.DeleteAsync(model));
        }
    }
}
