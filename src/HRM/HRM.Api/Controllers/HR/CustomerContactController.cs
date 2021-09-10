using HRM.Api.Providers;
using HRM.Application.HR;
using HRM.Model.HR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HRM.Api.Controllers.HR
{
    [Route("api/customer-contact")]
    [ApiController]
    public class CustomerContactController : BaseController
    {
        private readonly ICustomerContactService _customerContactService;

        public CustomerContactController(
            IHttpContextAccessor httpContext,
            ICustomerContactService customerContactService) : base(httpContext)
        {
            _customerContactService = customerContactService;
        }

        [HttpPost("grid")]
        public async Task<IActionResult> Grid([FromBody] CustomerContactGridParameterModel model)
        {
            return Ok(await _customerContactService.GridAsync(model));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Item(long id)
        {
            return Ok(await _customerContactService.FindByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CustomerContactModel model)
        {
            model.CreateBy = base.EmployeeId;
            return Ok(await _customerContactService.SaveAsync(model, true));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, CustomerContactModel model)
        {
            model.UpdateBy = base.EmployeeId;
            return Ok(await _customerContactService.SaveAsync(model, false));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            CustomerContactModel model = new CustomerContactModel();
            model.Id = id;
            model.UpdateBy = base.EmployeeId;
            return Ok(await _customerContactService.DeleteAsync(model));
        }
    }
}
