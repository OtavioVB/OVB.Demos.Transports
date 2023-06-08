using OVB.Demos.Libraries.Domain;
using OVB.Demos.Transports.CompanyContext.Domain.Bussines.CompanyContext.DataTransferObject;
using OVB.Demos.Transports.CompanyContext.Domain.Bussines.OwnerAuthenticationContext.DataTransferObject;
using OVB.Demos.Transports.CompanyContext.Domain.Bussines.OwnerPhoneContext.DataTransferObject;

namespace OVB.Demos.Transports.CompanyContext.Domain.Bussines.OwnerContext.DataTransferObject;

public sealed class Owner : DataTransferObjectBase.All
{
    public Owner(Guid identifier, Guid correlationIdentifier, string sourcePlatform, string name, string lastName, string language, string country,
        string documentType, string documentContent, OwnerDocument[] ownerDocuments, DateTime createdAt, DateTime updatedAt) 
        : base(identifier, correlationIdentifier, sourcePlatform, createdAt, updatedAt)
    {
        OwnerDocuments = ownerDocuments;
        Name = name;
        LastName = lastName;
        Country = country;
        Language = language;
        DocumentType = documentType; 
        DocumentContent = documentContent;
    }

    #region Properties

    public string DocumentType { get; set; }
    public string DocumentContent { get; set; }
    public OwnerDocument[] OwnerDocuments { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Language { get; set; }
    public string Country { get; set; }

    #endregion

    #region Relationships

    public Guid? CompanyIdentifier { get; set; }
    public Company? Company { get; set; }

    public OwnerAuthentication? OwnerAuthentication { get; set; }

    public List<OwnerPhone>? OwnerPhones { get; set; }

    #endregion
}

public sealed class OwnerDocument
{
    public OwnerDocument(string type, string content)
    {
        Type = type;
        Content = content;
    }

    public string Type { get; set; }
    public string Content { get; set; }
}