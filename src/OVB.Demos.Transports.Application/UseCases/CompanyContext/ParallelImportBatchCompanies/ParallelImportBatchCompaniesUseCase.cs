using OVB.Demos.Transports.Application.UseCases.CompanyContext.ParallelImportBatchCompanies.Inputs;
using OVB.Demos.Transports.Application.UseCases.CompanyContext.ParallelImportBatchCompanies.Outputs;
using OVB.Demos.Transports.Application.UseCases.Interfaces;
using OVB.Demos.Transports.Domain.Results.Interfaces;

namespace OVB.Demos.Transports.Application.UseCases.CompanyContext.ParallelImportBatchCompanies;

public sealed class ParallelImportBatchCompaniesUseCase : IUseCase<ParallelImportBatchCompaniesUseCaseInput,
    ICommandCompleteResult<ParallelImportBatchCompaniesUseCaseSuccessfullResponse, ParallelImportBatchCompaniesUseCaseErrorfullResponse>>
{
    public Task<ICommandCompleteResult<ParallelImportBatchCompaniesUseCaseSuccessfullResponse, ParallelImportBatchCompaniesUseCaseErrorfullResponse>> ExecuteUseCaseAsync(
        ParallelImportBatchCompaniesUseCaseInput input, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
