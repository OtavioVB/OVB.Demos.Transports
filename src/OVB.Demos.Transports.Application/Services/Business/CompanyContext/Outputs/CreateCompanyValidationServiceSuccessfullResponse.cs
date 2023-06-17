using OVB.Demos.Transports.Domain.Results.ErrorResults;

namespace OVB.Demos.Transports.Application.Services.Business.CompanyContext.Outputs;

public readonly struct CreateCompanyValidationServiceSuccessfullResponse
{
    public CreateCompanyValidationServiceSuccessfullResponse(string name, string platformName, string cnpj, IReadOnlyCollection<NotificationMessage> notifications)
    {
        Name = name;
        PlatformName = platformName;
        Cnpj = cnpj;
        Notifications = notifications;
    }

    public string Name { get; init; }
    public string PlatformName { get; init; }
    public string Cnpj { get; init; }
    public IReadOnlyCollection<NotificationMessage> Notifications { get; init; }
}
