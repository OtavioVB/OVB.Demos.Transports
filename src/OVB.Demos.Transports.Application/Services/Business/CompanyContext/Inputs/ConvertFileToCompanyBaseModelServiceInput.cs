using Microsoft.AspNetCore.Http;

namespace OVB.Demos.Transports.Application.Services.Business.CompanyContext.Inputs;

public readonly struct ConvertFileToCompanyBaseModelServiceInput
{
    public ConvertFileToCompanyBaseModelServiceInput(IFormFile file)
    {
        File = file;
    }

    public IFormFile File { get; init; }
}
