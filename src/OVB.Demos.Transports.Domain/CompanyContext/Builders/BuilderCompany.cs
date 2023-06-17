using FluentValidation;
using OVB.Demos.Transports.Domain.CompanyContext.Builders.Interfaces;
using OVB.Demos.Transports.Domain.CompanyContext.Contracts;
using OVB.Demos.Transports.Domain.CompanyContext.Entities;
using OVB.Demos.Transports.Domain.CompanyContext.Entities.Base;
using OVB.Demos.Transports.Domain.CompanyContext.ENUMs;
using static OVB.Demos.Transports.Domain.CompanyContext.ValueObjects.CompanyValueObjects;

namespace OVB.Demos.Transports.Domain.CompanyContext.Builders;

public sealed class BuilderCompany : IBuilderCompany
{
    private readonly AbstractValidator<Name> _nameValidator;
    private readonly AbstractValidator<PlatformName> _platformNameValidator;
    private readonly AbstractValidator<Cnpj> _cnpjValidator;

    public BuilderCompany(
        AbstractValidator<Name> nameValidator, 
        AbstractValidator<PlatformName> platformNameValidator, 
        AbstractValidator<Cnpj> cnpjValidator)
    {
        _nameValidator = nameValidator;
        _platformNameValidator = platformNameValidator;
        _cnpjValidator = cnpjValidator;
    }

    public CompanyBase BuildCompanyAccordingToHisType(TypeCompany typeCompany)
    {
        switch (typeCompany)
        {
            case TypeCompany.Standard:
                return new CompanyStandard(_nameValidator, _platformNameValidator, _cnpjValidator);
            default:
                throw new Exception("Is not possible to build the company according the enum type passed in the method param.");
        }
    }

    public ICompanyContract BuildCompanyContractAccordingToHisType(TypeCompany typeCompany)
    {
        switch (typeCompany)
        {
            case TypeCompany.Standard:
                return new CompanyStandard(_nameValidator, _platformNameValidator, _cnpjValidator);
            default:
                throw new Exception("Is not possible to build the company according the enum type passed in the method param.");
        }
    }
}
