using Microsoft.AspNetCore.Http;

namespace OVB.Demos.Transports.Application.UseCases.CompanyContext.ParallelImportBatchCompanies.Inputs;

public readonly struct ParallelImportBatchCompaniesUseCaseInput
{
    public ParallelImportBatchCompaniesUseCaseInput(string developerAuthorizationCode, IFormFile file)
    {
        DeveloperAuthorizationCode = developerAuthorizationCode;
        File = file;
    }

    public string DeveloperAuthorizationCode { get; init; }
    public IFormFile File { get; init; }
}
