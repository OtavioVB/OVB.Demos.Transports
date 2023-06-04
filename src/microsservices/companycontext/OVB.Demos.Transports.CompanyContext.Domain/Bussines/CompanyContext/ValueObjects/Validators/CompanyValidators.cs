using FluentValidation;
using static OVB.Demos.Transports.CompanyContext.Domain.Bussines.CompanyContext.ValueObjects.CompanyValueObjects;

namespace OVB.Demos.Transports.CompanyContext.Domain.Bussines.CompanyContext.ValueObjects.Validators;

public static class CompanyValidators
{
    public sealed class NameValidator : AbstractValidator<Name>
    {
        public NameValidator()
        {
        }
    }
}
