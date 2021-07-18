namespace HRM.Model.Common
{
    public sealed class UpdateCertificatedModelValidator : CertificatedValidator
    {
        public UpdateCertificatedModelValidator()
        {
            Id();
            Name();
            Precedence();
            IsActive();
        }
    }
}
