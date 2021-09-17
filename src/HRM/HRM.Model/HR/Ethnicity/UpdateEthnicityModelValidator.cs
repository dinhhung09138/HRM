using System;

namespace HRM.Model.HR
{
    public class UpdateEthnicityModelValidator : EthnicityValidator
    {
        public UpdateEthnicityModelValidator()
        {
            Id();
            Name();
        }
    }
}
