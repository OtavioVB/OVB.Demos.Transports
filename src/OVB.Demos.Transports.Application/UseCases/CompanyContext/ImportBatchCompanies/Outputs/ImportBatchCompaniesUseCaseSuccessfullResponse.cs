using OVB.Demos.Transports.Domain.Results.ErrorResults;

namespace OVB.Demos.Transports.Application.UseCases.CompanyContext.ImportBatchCompanies.Outputs;

public sealed class ImportBatchCompaniesUseCaseSuccessfullResponse
{
    public ImportBatchCompaniesUseCaseSuccessfullResponse(
        IReadOnlyCollection<ImportBatchCompaniesCompanyInformationUseCaseSuccessfullResponse> companiesInformation, 
        IReadOnlyCollection<NotificationMessage> notifications)
    {
        CompaniesInformation = companiesInformation;
        Notifications = notifications;
    }

    public IReadOnlyCollection<ImportBatchCompaniesCompanyInformationUseCaseSuccessfullResponse> CompaniesInformation { get; init; }
    public IReadOnlyCollection<NotificationMessage> Notifications { get; init; }
}

public readonly struct ImportBatchCompaniesCompanyInformationUseCaseSuccessfullResponse
{
    public ImportBatchCompaniesCompanyInformationUseCaseSuccessfullResponse(Guid identifier, string cnpj, DateTime createdAt, IReadOnlyCollection<NotificationMessage> notifications)
    {
        Identifier = identifier;
        Cnpj = cnpj;
        CreatedAt = createdAt;
        Notifications = notifications;
    }

    public Guid Identifier { get; init; }
    public string Cnpj { get; init; }
    public DateTime CreatedAt { get; init; }
    public IReadOnlyCollection<NotificationMessage> Notifications { get; init; }
}