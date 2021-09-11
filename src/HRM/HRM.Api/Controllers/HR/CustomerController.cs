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
    public class CustomerController : BaseController
    {
        private readonly ICustomerService _customerService;

        public CustomerController(
            IHttpContextAccessor httpContext,
            ICustomerService customerService) : base(httpContext)
        {
            _customerService = customerService;
        }

        [HttpPost("grid")]
        public async Task<IActionResult> Grid([FromBody] CustomerGridParameterModel model)
        {
            return Ok(await _customerService.GridAsync(model));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Item(long id)
        {
            return Ok(await _customerService.FindByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CustomerModel model)
        {
            model.CreateBy = base.EmployeeId;
            return Ok(await _customerService.SaveAsync(model, true));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(long id, CustomerModel model)
        {
            model.UpdateBy = base.EmployeeId;
            return Ok(await _customerService.SaveAsync(model, false));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(long id)
        {
            CustomerModel model = new CustomerModel();
            model.Id = id;
            model.UpdateBy = base.EmployeeId;
            return Ok(await _customerService.DeleteAsync(model));
        }
    }
}
