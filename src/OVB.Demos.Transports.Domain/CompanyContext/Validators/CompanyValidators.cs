using FluentValidation;
using static OVB.Demos.Transports.Domain.CompanyContext.ValueObjects.CompanyValueObjects;

namespace OVB.Demos.Transports.Domain.CompanyContext.Validators;

public static class CompanyValidators
{
    public sealed class PlatformNameValidator : AbstractValidator<PlatformName>
    {
        public PlatformNameValidator()
        {
            RuleFor(p => p.ToString().Length).LessThanOrEqualTo(PlatformName.MaxLength)
                .WithMessage($"The platform name needs to has less than or equal to {PlatformName.MaxLength} characters.")
                .WithErrorCode("CPLTN01");
            RuleFor(p => p.ToString().Length).GreaterThanOrEqualTo(PlatformName.MinLength)
                .WithMessage($"The platform name needs to has greater than or equal to {PlatformName.MinLength} characters.")
                .WithErrorCode("CPLTN02");
        }
    }

    public sealed class NameValidator : AbstractValidator<Name>
    {
        public NameValidator()
        {
            RuleFor(p => p.ToString().Length).LessThanOrEqualTo(Name.MaxLength)
                .WithMessage($"The name needs to has less than or equal to {Name.MaxLength} characters.")
                .WithErrorCode("CNAM01");
            RuleFor(p => p.ToString().Length).GreaterThanOrEqualTo(Name.MinLength)
                .WithMessage($"The name needs to has greater than or equal to {Name.MinLength} characters.")
                .WithErrorCode("CNAM02");
        }
    }

    public sealed class CnpjValidator : AbstractValidator<Cnpj>
    {
        public CnpjValidator()
        {
            RuleFor(p => p.ToString().Length).Equal(Cnpj.UniqueLength)
                .WithMessage($"The cnpj needs to has only {Cnpj.UniqueLength} characters.")
                .WithErrorCode("CCNPJ01");
        }
    }
}
