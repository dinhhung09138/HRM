using System;
using HRM.Domain.HR;
using HRM.Model.HR;

namespace HRM.Application.HR
{
    public interface IBranchFactory
    {
        Branch Create(BranchModel model);

        Branch Update(BranchModel model);
    }
}
