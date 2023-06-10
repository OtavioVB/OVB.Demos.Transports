using OVB.Demos.Libraries.Domain.Validations.Interfaces;
using OVB.Demos.Transports.Responses;
using OVB.Demos.Transports.Responses.ManagementMessages;
using static OVB.Demos.Transports.CompanyContext.Domain.Bussines.CompanyContext.ValueObjects.CompanyValueObjects;

namespace OVB.Demos.Transports.CompanyContext.Domain.Bussines.CompanyContext.ValueObjects.Validators;

public static class CompanyValidators
{
    public sealed class NameValidator : IValidation<Name>
    {
        private readonly string _messageTextCode;
        private readonly ManagementMessages<Name> _nameManagementMessages;

        public NameValidator(ManagementMessages<Name> nameManagementMessages)
        {
            _messageTextCode = nameof(Name).ToUpper().Substring(0, 3);
            _nameManagementMessages = nameManagementMessages;
        }

        public (bool IsValid, List<ErrorMessage> Messages) Validate(Name entity, string languageCode)
        {
            var messages = new List<ErrorMessage>();
            var isValid = true;

            if (entity.ToString().Length > Name.MaxLength)
            {
                isValid = false;
                messages.Add(_nameManagementMessages.GetErrorMessageByLanguage($"{_messageTextCode}01", languageCode));
            }

            if (entity.ToString().Length < Name.MinLength)
            {
                isValid = false;
                messages.Add(_nameManagementMessages.GetErrorMessageByLanguage($"{_messageTextCode}02", languageCode));
            }

            return (isValid, messages);
        }
    }
}
