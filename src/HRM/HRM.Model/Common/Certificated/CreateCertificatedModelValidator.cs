
namespace HRM.Model.Common
{
    public sealed class CreateCertificatedModelValidator : CertificatedValidator
    {
        public CreateCertificatedModelValidator()
        {
            Name();
            Precedence();
            IsActive();
        }
    }
}
