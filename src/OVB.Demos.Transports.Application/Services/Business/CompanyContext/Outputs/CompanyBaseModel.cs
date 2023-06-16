namespace OVB.Demos.Transports.Application.Services.Business.CompanyContext.Outputs;

public readonly struct CompanyBaseModel
{
    public CompanyBaseModel(string realName, string platformName, string cnpj)
    {
        RealName = realName;
        PlatformName = platformName;
        Cnpj = cnpj;
    }

    public string RealName { get; init; }
    public string PlatformName { get; init; }
    public string Cnpj { get; init; }
}
