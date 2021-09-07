using HRM.Domain.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public interface ICustomerFactory
    {
        Customer Create(CustomerModel model);

        Customer Update(CustomerModel model);
    }
}
