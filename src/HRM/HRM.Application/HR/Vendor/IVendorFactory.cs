using HRM.Domain.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public interface IVendorFactory
    {
        Vendor Create(VendorModel model);

        Vendor Update(VendorModel model);
    }
}
