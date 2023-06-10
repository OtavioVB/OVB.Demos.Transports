using OVB.Demos.Transports.CompanyContext.Domain.Bussines.CompanyContext.DataTransferObject;
using static OVB.Demos.Transports.CompanyContext.Domain.Bussines.CompanyContext.ValueObjects.CompanyValueObjects;
using static OVB.Demos.Libraries.Domain.DomainBase;
using OVB.Demos.Libraries.Cryptography;
using OVB.Demos.Libraries.Domain;
using static OVB.Demos.Transports.CompanyContext.Domain.Bussines.BaseContext.BaseValueObjects;
using OVB.Demos.Transports.Responses;
using OVB.Demos.Transports.CompanyContext.Domain.Bussines.CompanyContext.Responses;
using OVB.Demos.Libraries.Domain.Validations.Interfaces;
using OVB.Demos.Transports.CompanyContext.Domain.Bussines.CompanyContext.ENUMs;
using Microsoft.AspNetCore.Http;
using OVB.Demos.Transports.Domain;

namespace OVB.Demos.Transports.CompanyContext.Domain.Bussines.CompanyContext.Entities.Base;

public abstract class CompanyBase : All
{
    #region Properties

    protected Name Name { get; set; }
    protected PlatformName PlatformName { get; set; }
    protected Document Document { get; set; }
    protected Language Language { get; set; }
    protected Country Country { get; set; }

    protected State State { get; set; }
    protected TypeCompany Type { get; init; }

    protected Company Company { get; set; }

    #endregion

    #region Validators

    protected readonly IValidation<Language> _languageValidation;
    protected readonly IValidation<Country> _countryValidation;
    protected readonly IValidation<Name> _nameValidation;
    protected readonly IValidation<PlatformName> _platformNameValidation;
    protected readonly IValidation<Document> _documentValidation;

    #endregion

    #region Constructors
    protected CompanyBase(
        IValidation<Language> languageValidation,
        IValidation<Country> countryValidation,
        IValidation<Name> nameValidation,
        IValidation<PlatformName> platformNameValidation,
        IValidation<Document> documentValidation,
        TypeCompany typeCompany)
    {
        Type = typeCompany;
        State = State.Unavailable;
        Company = Company.Empty;
        _languageValidation = languageValidation;
        _countryValidation = countryValidation;
        _nameValidation = nameValidation;
        _platformNameValidation = platformNameValidation;
        _documentValidation = documentValidation;
    }
    #endregion

    #region Bussiness Methods

    public ResponseBase<CreateCompanyDomainSuccessfullResponse> CreateCompany(Name name, PlatformName platformName, Document document, Language language, Country country)
    {
        var response = new ResponseBase<CreateCompanyDomainSuccessfullResponse>();
        bool hasAnyInvalid = false;
        var messages = new List<ErrorMessage>();

        var languageValidationResult = _languageValidation.Validate(language, Languages.BrazilPortuguese);
        if (languageValidationResult.IsValid == false)
        {
            messages.AddRange(languageValidationResult.Messages);
            response.SetErrorResponse(
                errorResponse: new ErrorResponse(
                    statusCode: StatusCodes.Status400BadRequest,
                    messages: messages.ToArray()));
            return response;
        }

        var nameValidation = _nameValidation.Validate(name, language.ToString());
        if (nameValidation.IsValid == false)
        {
            messages.AddRange(nameValidation.Messages);
            hasAnyInvalid = true;
        }

        var platformNameValidation = _platformNameValidation.Validate(platformName, language.ToString());
        if (platformNameValidation.IsValid == false)
        {
            messages.AddRange(platformNameValidation.Messages);
            hasAnyInvalid = true;
        }

        var documentValidation = _documentValidation.Validate(document, language.ToString());
        if (documentValidation.IsValid == false)
        {
            messages.AddRange(documentValidation.Messages);
            hasAnyInvalid = true;
        }

        var countryValidation = _countryValidation.Validate(country, language.ToString());
        if (countryValidation.IsValid == false)
        {
            messages.AddRange(countryValidation.Messages);
            hasAnyInvalid = true;
        }

        if (hasAnyInvalid == true)
        {
            response.SetErrorResponse(
                errorResponse: new ErrorResponse(
                    statusCode: StatusCodes.Status422UnprocessableEntity, 
                    messages: messages.ToArray()));
            return response;
        }
        else
        {
            response.SetSuccessfullResponse(
                successfullResponse: new CreateCompanyDomainSuccessfullResponse(messages));
            return response;
        }
    }

    #endregion

    #region Public Methods

    #endregion

    #region Private Methods

    #endregion
}
