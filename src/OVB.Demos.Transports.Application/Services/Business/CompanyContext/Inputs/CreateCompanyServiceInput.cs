using OVB.Demos.Transports.Domain.CompanyContext.ENUMs;

namespace OVB.Demos.Transports.Application.Services.Business.CompanyContext.Inputs;

public readonly struct CreateCompanyServiceInput
{
    public CreateCompanyServiceInput(string realName, string platformName, string cnpj, TypeCompany typeCompany)
    {
        RealName = realName;
        PlatformName = platformName;
        Cnpj = cnpj;
        TypeCompany = typeCompany;
    }

    public string RealName { get; init; }
    public string PlatformName { get; init; }
    public string Cnpj { get; init; }
    public TypeCompany TypeCompany { get; init; }
}
