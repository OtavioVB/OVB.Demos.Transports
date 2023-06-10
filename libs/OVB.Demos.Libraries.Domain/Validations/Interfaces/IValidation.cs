using OVB.Demos.Transports.Responses;

namespace OVB.Demos.Libraries.Domain.Validations.Interfaces;

public interface IValidation<TEntity>
{
    public (bool IsValid, List<ErrorMessage> Messages) Validate(TEntity entity, string languageCode);
}
