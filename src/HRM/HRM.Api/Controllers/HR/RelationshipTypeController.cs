using HRM.Api.Providers;
using HRM.Application.HR;
using HRM.Model.HR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HRM.Api.Controllers.HR
{
    [Route("api/hr/relationship-type")]
    [ApiController]
    public class RelationshipTypeController : BaseController
    {
        private readonly IRelationshipTypeService _relationshipTypeService;

        public RelationshipTypeController(
            IHttpContextAccessor httpContext,
            IRelationshipTypeService relationshipTypeService) : base(httpContext)
        {
            _relationshipTypeService = relationshipTypeService;
        }

        [HttpPost("grid")]
        public async Task<IActionResult> Grid([FromBody] RelationshipTypeGridParameterModel model)
        {
            return Ok(await _relationshipTypeService.GridAsync(model));
        }

        [HttpGet("dropdown")]
        public async Task<IActionResult> Dropdown()
        {
            return Ok(await _relationshipTypeService.DropdownAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Item(long id)
        {
            return Ok(await _relationshipTypeService.FindByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] RelationshipTypeModel model)
        {
            model.CreateBy = base.EmployeeId;
            return Ok(await _relationshipTypeService.SaveAsync(model, true));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, RelationshipTypeModel model)
        {
            model.UpdateBy = base.EmployeeId;
            return Ok(await _relationshipTypeService.SaveAsync(model, false));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            RelationshipTypeModel model = new RelationshipTypeModel();
            model.Id = id;
            model.UpdateBy = base.EmployeeId;
            return Ok(await _relationshipTypeService.DeleteAsync(model));
        }
    }
}
