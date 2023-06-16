using OVB.Demos.Transports.Application.Services.OutOfBusiness.FileContext;
using OVB.Demos.Transports.Application.UseCases.CompanyContext.ImportBatchCompanies.Inputs;
using OVB.Demos.Transports.Application.UseCases.CompanyContext.ImportBatchCompanies.Outputs;
using OVB.Demos.Transports.Application.UseCases.Interfaces;
using OVB.Demos.Transports.Domain.Results;
using OVB.Demos.Transports.Domain.Results.Interfaces;

namespace OVB.Demos.Transports.Application.UseCases.CompanyContext.ImportBatchCompanies;

public sealed class ImportBatchCompaniesUseCase : IUseCase<ImportBatchCompaniesUseCaseInput, ICommandResult<ImportBatchCompaniesUseCaseSuccessfullResponse>>
{
    private readonly IFileService _fileService;

    public ImportBatchCompaniesUseCase(
        IFileService fileService)
    {
        _fileService = fileService;
    }

    public Task<ICommandResult<ImportBatchCompaniesUseCaseSuccessfullResponse>> ExecuteUseCaseAsync(
        ImportBatchCompaniesUseCaseInput input, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
