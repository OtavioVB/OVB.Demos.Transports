namespace OVB.Demos.Transports.Gateway.WebApi.Controllers.CompanyContext.Payloads;

public sealed class BatchImportCompaniesPayloadInput
{
    public BatchImportCompaniesPayloadInput(BatchImportCompaniesCompanyInfoPayloadInput[] companies)
    {
        Companies = companies;
    }

    public BatchImportCompaniesCompanyInfoPayloadInput[] Companies { get; init; }
}

public readonly struct BatchImportCompaniesCompanyInfoPayloadInput
{
    public BatchImportCompaniesCompanyInfoPayloadInput(Guid identifier, string platformName, string name)
    {
        Identifier = identifier;
        PlatformName = platformName;
        Name = name;
    }

    public Guid Identifier { get; init; }
    public string PlatformName { get; init; }
    public string Name { get; init; }
}