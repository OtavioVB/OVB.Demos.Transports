using OVB.Demos.Transports.Domain.Results.ErrorResults;

namespace OVB.Demos.Transports.Application.UseCases.CompanyContext.ParallelImportBatchCompanies.Outputs;

public sealed class ParallelImportBatchCompaniesUseCaseSuccessfullResponse 
{
    public ParallelImportBatchCompaniesUseCaseSuccessfullResponse(
        IReadOnlyCollection<ParallelImportBatchCompaniesCompanyInformationUseCaseSuccessfullResponse> companiesInformation,
        IReadOnlyCollection<NotificationMessage> notifications)
    {
        CompaniesInformation = companiesInformation;
        Notifications = notifications;
    }

    public IReadOnlyCollection<ParallelImportBatchCompaniesCompanyInformationUseCaseSuccessfullResponse> CompaniesInformation { get; init; }
    public IReadOnlyCollection<NotificationMessage> Notifications { get; init; }
}

public readonly struct ParallelImportBatchCompaniesCompanyInformationUseCaseSuccessfullResponse
{
    public ParallelImportBatchCompaniesCompanyInformationUseCaseSuccessfullResponse(Guid identifier, string cnpj, DateTime createdAt, IReadOnlyCollection<NotificationMessage> notifications)
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