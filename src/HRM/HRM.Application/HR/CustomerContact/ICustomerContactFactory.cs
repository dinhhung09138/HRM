using HRM.Domain.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public interface ICustomerContactFactory
    {
        CustomerContact Create(CustomerContactModel model);

        CustomerContact Update(CustomerContactModel model);
    }
}
