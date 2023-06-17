using static OVB.Demos.Transports.Domain.CompanyContext.ValueObjects.CompanyValueObjects;
using OVB.Demos.Transports.Domain.CompanyContext.Contracts;
using OVB.Demos.Transports.Domain.CompanyContext.ENUMs;
using OVB.Demos.Transports.Domain.Results.ErrorResults;
using OVB.Demos.Transports.Domain.Results.Interfaces;
using FluentValidation;
using OVB.Demos.Transports.Domain.Results;
using OVB.Demos.Transports.Domain.CompanyContext.DataTransferObject;

namespace OVB.Demos.Transports.Domain.CompanyContext.Entities.Base;

public abstract class CompanyBase : ICompanyContract
{
    protected Guid Identifier { get; private set; }
    protected Name Name { get; private set; }
    protected PlatformName PlatformName { get; private set; }
    protected Cnpj Cnpj { get; private set; }
    protected DateTime CreatedAt { get; private set; }
    public TypeCompany Type { get; init; }
    private State State { get; set; }

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
        State = State.Unavailable;
    }

    public virtual ICommandResult<IEnumerable<NotificationMessage>> CreateCompany(string platformName, string realName, string cnpj)
    {
        var platformNameValueObject = PlatformName.Build(platformName);
        var nameValueObject = Name.Build(realName);
        var cnpjValueObject = Cnpj.Build(cnpj);

        var validationResult = ValidationStrategy(nameValueObject, platformNameValueObject, cnpjValueObject);
        
        if(validationResult.HasAnyInvalid == false)
            SetCompanyBasicCredentials(Guid.NewGuid(), platformNameValueObject, cnpjValueObject, nameValueObject, DateTime.UtcNow);

        return BuildCommandResult(validationResult.HasAnyInvalid, validationResult.Notifications);
    }

    public Company GetCompanyDataTransferObject()
    {
        if (State != State.Available)
            throw new Exception("Is not possible to get company in an invalid state.");

        return new Company(Identifier, PlatformName.ToString(), Name.ToString(), Cnpj.ToString(), Type.ToString().ToCharArray()[0], CreatedAt);
    }

    protected void SetCompanyBasicCredentials(Guid identifier, PlatformName platformName, Cnpj cnpj, Name name, DateTime createdAt)
    {
        if (State != State.Unavailable)
            throw new Exception("Is not possible to set company basic credentials in an invalid state.");

            Identifier = identifier;
        PlatformName = platformName;
        Cnpj = cnpj;
        Name = name;
        CreatedAt = createdAt;
        State = State.Available;
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
