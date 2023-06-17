using OVB.Demos.Transports.Domain.Results.ErrorResults;

namespace OVB.Demos.Transports.Application.Services.Business.CompanyContext.Outputs;

public readonly struct CreateCompanyServiceSuccessfullResponse
{
    public CreateCompanyServiceSuccessfullResponse(
        IReadOnlyCollection<NotificationMessage> notifications, 
        Guid identifier, 
        string cnpj, 
        DateTime createdAt)
    {
        Notifications = notifications;
        Identifier = identifier;
        Cnpj = cnpj;
        CreatedAt = createdAt;
    }

    public IReadOnlyCollection<NotificationMessage> Notifications { get; init; }
    public Guid Identifier { get; init; }
    public string Cnpj { get; init; }
    public DateTime CreatedAt { get; init; }
}
