using OVB.Demos.Libraries.Domain;

namespace OVB.Demos.Transports.CompanyContext.Domain.Bussines.CompanyContext.DataTransferObject;

public sealed class Company : DataTransferObjectBase.All
{
    public Company(Guid identifier, Guid correlationIdentifier, string sourcePlatform, string platformName, string nameReally, string cryptographyPrivateKey, 
        DateTime updatedAt, DateTime createdAt) : base(identifier, correlationIdentifier, sourcePlatform, createdAt, updatedAt)
    {
        CryptographyPrivateKey = cryptographyPrivateKey;
        PlatformName = platformName;
        NameReally = nameReally;
    }

    public string PlatformName { get; set; }
    public string NameReally { get; set; }
    public string CryptographyPrivateKey { get; set; }

    public static Company Empty { get; set; } = new Company(Guid.Empty, Guid.Empty, string.Empty, string.Empty, string.Empty, string.Empty, DateTime.UnixEpoch,
        DateTime.UnixEpoch);
}