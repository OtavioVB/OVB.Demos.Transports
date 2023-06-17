using static OVB.Demos.Transports.Domain.CompanyContext.ValueObjects.CompanyValueObjects;
using OVB.Demos.Transports.Domain.CompanyContext.Contracts;
using OVB.Demos.Transports.Domain.CompanyContext.ENUMs;
using OVB.Demos.Transports.Domain.Results.ErrorResults;
using OVB.Demos.Transports.Domain.Results.Interfaces;
using FluentValidation;
using OVB.Demos.Transports.Domain.Results;

namespace OVB.Demos.Transports.Domain.CompanyContext.Entities.Base;

public abstract class CompanyBase : ICompanyContract
{
    protected Name Name { get; private set; }
    protected PlatformName PlatformName { get; private set; }
    protected Cnpj Cnpj { get; private set; }
    public TypeCompany Type { get; init; }

    protected readonly AbstractValidator<Name> _nameValidator;
    protected readonly AbstractValidator<PlatformName> _platformNameValidator;
    protected readonly AbstractValidator<Cnpj> _cnpjValidator;

    protected CompanyBase(
        AbstractValidator<Name> nameValidator,
        AbstractValidator<PlatformName> platformNameValidator,
        AbstractValidator<Cnpj> cnpjValidator, 
        TypeCompany type)
    {
        _nameValidator = nameValidator;
        _platformNameValidator = platformNameValidator;
        _cnpjValidator = cnpjValidator;
        Type = type;
    }

    public ICommandResult<IEnumerable<NotificationMessage>> CreateCompany(string platformName, string realName, string cnpj)
    {
        var platformNameValueObject = PlatformName.Build(platformName);
        var nameValueObject = Name.Build(realName);
        var cnpjValueObject = Cnpj.Build(cnpj);

        var validationResult = ValidationStrategy(nameValueObject, platformNameValueObject, cnpjValueObject);

        return BuildCommandResult(validationResult.HasAnyInvalid, validationResult.Notifications);
    }

    protected (bool HasAnyInvalid, List<NotificationMessage> Notifications) ValidationStrategy(Name name, PlatformName platformName, Cnpj cnpj)
    {
        var notifications = new List<NotificationMessage>();
        var hasAnyInvalid = false;

        var platformNameValidation = _platformNameValidator.Validate(platformName);
        if (platformNameValidation.IsValid == false)
        {
            notifications.AddRange(platformNameValidation.Errors.Select(p => NotificationMessage.BuildErrorMessage(p.ErrorCode, p.ErrorMessage)).ToList());
            hasAnyInvalid = true;
        }

        var nameValidation = _nameValidator.Validate(name);
        if (nameValidation.IsValid == false)
        {
            notifications.AddRange(nameValidation.Errors.Select(p => NotificationMessage.BuildErrorMessage(p.ErrorCode, p.ErrorMessage)).ToList());
            hasAnyInvalid = true;
        }

        var cnpjValidation = _cnpjValidator.Validate(cnpj);
        if (cnpjValidation.IsValid == false)
        {
            notifications.AddRange(cnpjValidation.Errors.Select(p => NotificationMessage.BuildErrorMessage(p.ErrorCode, p.ErrorMessage)).ToList());
            hasAnyInvalid = true;
        }

        return (hasAnyInvalid, notifications);
    }

    protected ICommandResult<IEnumerable<NotificationMessage>> BuildCommandResult(bool hasAnyInvalid, List<NotificationMessage> notifications)
    {
        var response = new CommandResult<IEnumerable<NotificationMessage>>();
        if (hasAnyInvalid == true)
        {
            response.AddErrorResponse(notifications);
            return response;
        }
        else
        {
            response.AddSuccessfullResponse(notifications);
            return response;
        }
    }
}
