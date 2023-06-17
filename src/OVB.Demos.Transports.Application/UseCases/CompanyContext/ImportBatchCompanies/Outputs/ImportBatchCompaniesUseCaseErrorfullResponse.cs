using OVB.Demos.Transports.Domain.Results.ErrorResults;

namespace OVB.Demos.Transports.Application.UseCases.CompanyContext.ImportBatchCompanies.Outputs;

public sealed class ImportBatchCompaniesUseCaseErrorfullResponse
{
    public ImportBatchCompaniesUseCaseErrorfullResponse(
        IReadOnlyCollection<CompanyBatchInformation>? companiesError, 
        IReadOnlyCollection<NotificationMessage> generalNotificationMessages)
    {
        CompaniesError = companiesError;
        GeneralNotificationMessages = generalNotificationMessages;
    }

    public IReadOnlyCollection<CompanyBatchInformation>? CompaniesError { get; init; }
    public IReadOnlyCollection<NotificationMessage> GeneralNotificationMessages { get; init; }
}

public readonly struct CompanyBatchInformation
{
    public CompanyBatchInformation(string cnpj, IReadOnlyCollection<NotificationMessage> notifications)
    {
        Cnpj = cnpj;
        Notifications = notifications;
    }

    public string Cnpj { get; init; }
    public IReadOnlyCollection<NotificationMessage> Notifications { get; init; }
}
