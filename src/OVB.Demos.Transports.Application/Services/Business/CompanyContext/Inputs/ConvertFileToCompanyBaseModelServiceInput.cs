using Microsoft.AspNetCore.Http;

namespace OVB.Demos.Transports.Application.Services.Business.CompanyContext.Inputs;

public readonly struct ConvertFileToCompanyBaseModelServiceInput
{
    public ConvertFileToCompanyBaseModelServiceInput(IFormFile file, char separatorCharacter, string path)
    {
        File = file;
        SeparatorCharacter = separatorCharacter;
        Path = path;
    }

    public IFormFile File { get; init; }
    public char SeparatorCharacter { get; init; }
    public string Path { get; init; }
}
