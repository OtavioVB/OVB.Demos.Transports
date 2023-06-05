using OVB.Demos.Libraries.Application.Interfaces;
using OVB.Demos.Transports.CompanyContext.Application.UseCases.BatchImportCompanies.Inputs;
using OVB.Demos.Transports.CompanyContext.Application.UseCases.BatchImportCompanies.Outputs;

namespace OVB.Demos.Transports.CompanyContext.Application.UseCases.BatchImportCompanies;

public sealed class BatchImportCompaniesUseCase : IUseCase<BatchImportCompaniesUseCaseInput, BatchImportCompaniesUseCaseSuccessfullResponse>
{
    public Task<BatchImportCompaniesUseCaseSuccessfullResponse> ExecuteUseCaseAsync(BatchImportCompaniesUseCaseInput input, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}