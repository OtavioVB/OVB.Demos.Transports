using OVB.Demos.Libraries.Domain;
using OVB.Demos.Transports.CompanyContext.Domain.Bussines.OwnerContext.DataTransferObject;

namespace OVB.Demos.Transports.CompanyContext.Domain.Bussines.CompanyContext.DataTransferObject;

public sealed class Company : DataTransferObjectBase.All
{
    public Company(Guid identifier, Guid correlationIdentifier, string sourcePlatform, string platformName, string nameReally, string cryptographyPrivateKey, string country,
        string language, DateTime updatedAt, DateTime createdAt) : base(identifier, correlationIdentifier, sourcePlatform, createdAt, updatedAt)
    {
        CryptographyPrivateKey = cryptographyPrivateKey;
        PlatformName = platformName;
        NameReally = nameReally;
        Country = country;
        Language = language;
    }

    #region Properties

    public string PlatformName { get; set; }
    public string NameReally { get; set; }
    public string CryptographyPrivateKey { get; set; }
    public string Language { get; set; }
    public string Country { get; set; }

    #endregion

    #region Relationships

    public List<Owner>? Owners { get; set; }

    #endregion
}