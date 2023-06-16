using OVB.Demos.Transports.Application.Services.Business.CompanyContext.Interfaces;
using OVB.Demos.Transports.Application.Services.OutOfBusiness.DeveloperContext.Interfaces;
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
    private readonly IAuthorizationService _authorizationService;
    private readonly ICompanyService _companyService;

    public ImportBatchCompaniesUseCase(
        IFileService fileService,
        IAuthorizationService authorizationService, 
        ICompanyService companyService)
    {
        _fileService = fileService;
        _authorizationService = authorizationService;
        _companyService = companyService;
    }

    public Task<ICommandResult<ImportBatchCompaniesUseCaseSuccessfullResponse>> ExecuteUseCaseAsync(
        ImportBatchCompaniesUseCaseInput input, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
