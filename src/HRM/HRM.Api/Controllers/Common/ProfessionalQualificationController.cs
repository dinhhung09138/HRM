using HRM.Api.Providers;
using HRM.Application.Common;
using HRM.Model.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HRM.Api.Controllers.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessionalQualificationController : BaseController
    {
        private readonly IProfessionalQualificationService _professionalQualificationService;

        public ProfessionalQualificationController(
            IHttpContextAccessor httpContext,
            IProfessionalQualificationService professionalQualificationService) : base(httpContext)
        {
            _professionalQualificationService = professionalQualificationService;
        }

        [HttpPost("grid")]
        public async Task<IActionResult> Grid([FromBody] ProfessionalQualificationGridParameterModel model)
        {
            return Ok(await _professionalQualificationService.GridAsync(model));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Item(long id)
        {
            return Ok(await _professionalQualificationService.FindByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ProfessionalQualificationModel model)
        {
            model.CreateBy = base.EmployeeId;
            return Ok(await _professionalQualificationService.SaveAsync(model, true));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, ProfessionalQualificationModel model)
        {
            model.UpdateBy = base.EmployeeId;
            return Ok(await _professionalQualificationService.SaveAsync(model, false));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            ProfessionalQualificationModel model = new ProfessionalQualificationModel();
            model.Id = id;
            model.UpdateBy = base.EmployeeId;
            return Ok(await _professionalQualificationService.DeleteAsync(model));
        }
    }
}
