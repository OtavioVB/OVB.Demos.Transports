using FluentValidation;
using OVB.Demos.Transports.Domain.CompanyContext.Entities.Base;
using OVB.Demos.Transports.Domain.CompanyContext.ENUMs;
using OVB.Demos.Transports.Domain.CompanyContext.ValueObjects;

namespace OVB.Demos.Transports.Domain.CompanyContext.Entities;

public sealed class CompanyStandard : CompanyBase
{
    public CompanyStandard(
        AbstractValidator<CompanyValueObjects.Name> nameValidator, 
        AbstractValidator<CompanyValueObjects.PlatformName> platformNameValidator, 
        AbstractValidator<CompanyValueObjects.Cnpj> cnpjValidator) : base(nameValidator, platformNameValidator, cnpjValidator, TypeCompany.Standard)
    {
    }
}
