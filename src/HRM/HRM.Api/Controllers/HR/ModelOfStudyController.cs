using HRM.Api.Providers;
using HRM.Application.HR;
using HRM.Model.HR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HRM.Api.Controllers.HR
{
    [Route("api/hr/model-of-study")]
    [ApiController]
    public class ModelOfStudyController : BaseController
    {
        private readonly IModelOfStudyService _modelOfStudyService;

        public ModelOfStudyController(
            IHttpContextAccessor httpContext,
            IModelOfStudyService modelOfStudyService) : base(httpContext)
        {
            _modelOfStudyService = modelOfStudyService;
        }

        [HttpPost("grid")]
        public async Task<IActionResult> Grid([FromBody] ModelOfStudyGridParameterModel model)
        {
            return Ok(await _modelOfStudyService.GridAsync(model));
        }

        [HttpGet("dropdown")]
        public async Task<IActionResult> Dropdown()
        {
            return Ok(await _modelOfStudyService.DropdownAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Item(long id)
        {
            return Ok(await _modelOfStudyService.FindByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ModelOfStudyModel model)
        {
            model.CreateBy = base.EmployeeId;
            return Ok(await _modelOfStudyService.SaveAsync(model, true));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, ModelOfStudyModel model)
        {
            model.UpdateBy = base.EmployeeId;
            return Ok(await _modelOfStudyService.SaveAsync(model, false));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            ModelOfStudyModel model = new ModelOfStudyModel();
            model.Id = id;
            model.UpdateBy = base.EmployeeId;
            return Ok(await _modelOfStudyService.DeleteAsync(model));
        }
    }
}
