using OVB.Demos.Libraries.Domain;
using OVB.Demos.Transports.CompanyContext.Domain.Bussines.OwnerPhoneContext.DataTransferObject;

namespace OVB.Demos.Transports.CompanyContext.Domain.Bussines.OwnerContext.DataTransferObject;

public sealed class Owner : DataTransferObjectBase.All
{
    public Owner(Guid identifier, Guid correlationIdentifier, string sourcePlatform, string name, string lastName, string country, List<OwnerPhone> ownerPhones, 
        DateTime createdAt, DateTime updatedAt) : base(identifier, correlationIdentifier, sourcePlatform, createdAt, updatedAt)
    {
        Name = name;
        LastName = lastName;
        Country = country;
        OwnerPhones = ownerPhones;
    }

    public string Name { get; set; }
    public string LastName { get; set; }
    public string Country { get; set; }
    public List<OwnerPhone> OwnerPhones { get; set; }
}
