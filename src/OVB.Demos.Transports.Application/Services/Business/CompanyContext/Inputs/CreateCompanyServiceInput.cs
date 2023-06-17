using OVB.Demos.Transports.Domain.CompanyContext.ENUMs;

namespace OVB.Demos.Transports.Application.Services.Business.CompanyContext.Inputs;

public readonly struct CreateCompanyServiceInput
{
    public CreateCompanyServiceInput(string realName, string platformName, string cnpj, TypeCompany typeCompany)
    {
        RealName = realName;
        PlatformName = platformName;
        Cnpj = cnpj;
        this.typeCompany = typeCompany;
    }

    public string RealName { get; init; }
    public string PlatformName { get; init; }
    public string Cnpj { get; init; }
    public TypeCompany typeCompany { get; init; }
}
