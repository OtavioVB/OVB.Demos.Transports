namespace OVB.Demos.Transports.CompanyContext.Domain.Bussines.CompanyContext.DataTransferObject;

public sealed class Company
{
    public Company(Guid identifier, Guid correlationIdentifier, string sourcePlatform, string platformName, string nameReally)
    {
        Identifier = identifier;
        CorrelationIdentifier = correlationIdentifier;
        SourcePlatform = sourcePlatform;
        PlatformName = platformName;
        NameReally = nameReally;
    }

    public Guid Identifier { get; set; }
    public Guid CorrelationIdentifier { get; set; }
    public string SourcePlatform { get; set; }
    public string PlatformName { get; set; }
    public string NameReally { get; set; }
}