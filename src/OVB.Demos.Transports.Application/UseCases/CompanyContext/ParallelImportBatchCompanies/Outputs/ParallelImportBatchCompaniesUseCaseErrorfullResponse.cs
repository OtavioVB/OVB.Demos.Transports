using OVB.Demos.Transports.Domain.Results.ErrorResults;

namespace OVB.Demos.Transports.Application.UseCases.CompanyContext.ParallelImportBatchCompanies.Outputs; 

public sealed class ParallelImportBatchCompaniesUseCaseErrorfullResponse 
{
    public ParallelImportBatchCompaniesUseCaseErrorfullResponse(
        IReadOnlyCollection<ParallelCompanyBatchInformation>? companiesError,
        IReadOnlyCollection<NotificationMessage> generalNotificationMessages)
    {
        CompaniesError = companiesError;
        GeneralNotificationMessages = generalNotificationMessages;
    }

    public IReadOnlyCollection<ParallelCompanyBatchInformation>? CompaniesError { get; init; }
    public IReadOnlyCollection<NotificationMessage> GeneralNotificationMessages { get; init; }
}

public readonly struct ParallelCompanyBatchInformation
{
    public ParallelCompanyBatchInformation(string cnpj, IReadOnlyCollection<NotificationMessage> notifications)
    {
        Cnpj = cnpj;
        Notifications = notifications;
    }

    public string Cnpj { get; init; }
    public IReadOnlyCollection<NotificationMessage> Notifications { get; init; }
}
