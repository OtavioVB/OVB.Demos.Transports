using Microsoft.AspNetCore.Http;

namespace OVB.Demos.Transports.Application.UseCases.CompanyContext.ImportBatchCompanies.Inputs;

public readonly struct ImportBatchCompaniesUseCaseInput
{
    public ImportBatchCompaniesUseCaseInput(string authorization, IFormFile file)
    {
        Authorization = authorization;
        File = file;
    }

    public string Authorization { get; init; }
    public IFormFile File { get; init; }
}
