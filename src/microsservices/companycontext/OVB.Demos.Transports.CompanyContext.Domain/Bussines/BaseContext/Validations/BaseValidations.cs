using OVB.Demos.Libraries.Domain.Validations.Interfaces;
using OVB.Demos.Transports.Domain;
using OVB.Demos.Transports.Responses;
using OVB.Demos.Transports.Responses.ManagementMessages;
using static OVB.Demos.Transports.CompanyContext.Domain.Bussines.BaseContext.BaseValueObjects;

namespace OVB.Demos.Transports.CompanyContext.Domain.Bussines.BaseContext.Validations;

public static class BaseValidations
{
    public sealed class CountryValidation : IValidation<Country>
    {
        private readonly string _messageTextCode;
        private readonly ManagementMessages<Country> _countryManagementMessages;

        public CountryValidation(ManagementMessages<Country> countryManagementMessages)
        {
            _messageTextCode = nameof(Country).ToUpper().Substring(0, 3);
            _countryManagementMessages = countryManagementMessages;
        }

        public (bool IsValid, List<ErrorMessage> Messages) Validate(Country entity, string languageCode)
        {
            var messages = new List<ErrorMessage>();
            var isValid = true;

            if (entity.ToString() != CountryIsoCodes.Brazil)
            {
                isValid = false;
                messages.Add(_countryManagementMessages.GetErrorMessageByLanguage($"{_messageTextCode}01", languageCode));
            }

            return (isValid, messages);
        }
    }

    public sealed class LanguageValidation : IValidation<Language>
    {
        private readonly string _messageTextCode;
        private readonly ManagementMessages<Language> _languageManagementMessages;

        public LanguageValidation(ManagementMessages<Language> languageManagementMessages)
        {
            _messageTextCode = nameof(Language).ToUpper().Substring(0, 3);
            _languageManagementMessages = languageManagementMessages;
        }

        public (bool IsValid, List<ErrorMessage> Messages) Validate(Language entity, string languageCode = "pt-br")
        {
            var messages = new List<ErrorMessage>();
            var isValid = true;

            if (entity.ToString() != Languages.BrazilPortuguese)
            {
                isValid = false;
                messages.Add(_languageManagementMessages.GetErrorMessageByLanguage($"{_messageTextCode}01", Languages.BrazilPortuguese));
            }

            return (isValid, messages);
        }
    }
}
