namespace OVB.Demos.Transports.CompanyContext.Application.Services.Internal.CompanyContext.Inputs;

public readonly struct CreateCompanyServiceInput
{
    public CreateCompanyServiceInput(string realName, string platformName, string documentNumber, string documentType, string language, string country)
    {
        RealName = realName;
        PlatformName = platformName;
        DocumentNumber = documentNumber;
        DocumentType = documentType;
        Language = language;
        Country = country;
    }

    public string RealName { get; init; }
    public string PlatformName { get; init; }
    public string DocumentNumber { get; init; }
    public string DocumentType { get; init; }
    public string Language { get; init; }
    public string Country { get; init; }
}
