using OVB.Demos.Transports.CompanyContext.Domain.Bussines.OwnerPhoneContext.DataTransferObject;

namespace OVB.Demos.Transports.CompanyContext.Domain.Bussines.OwnerContext.DataTransferObject;

public sealed class Owner
{
    public Owner(Guid identifier, Guid correlationIdentifier, string sourcePlatform, string name, string lastName, string country, List<OwnerPhone> ownerPhones, 
        DateTime createdAt, DateTime updatedAt)
    {
        Identifier = identifier;
        CorrelationIdentifier = correlationIdentifier;
        SourcePlatform = sourcePlatform;
        Name = name;
        LastName = lastName;
        Country = country;
        OwnerPhones = ownerPhones;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }

    public Guid Identifier { get; set; }
    public Guid CorrelationIdentifier { get; set; }
    public string SourcePlatform { get; set; }

    public string Name { get; set; }
    public string LastName { get; set; }
    public string Country { get; set; }

    public List<OwnerPhone> OwnerPhones { get; set; }

    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
