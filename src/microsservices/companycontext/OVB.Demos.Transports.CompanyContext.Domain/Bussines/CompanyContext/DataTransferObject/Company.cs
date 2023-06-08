using OVB.Demos.Libraries.Domain;
using OVB.Demos.Transports.CompanyContext.Domain.Bussines.OwnerContext.DataTransferObject;

namespace OVB.Demos.Transports.CompanyContext.Domain.Bussines.CompanyContext.DataTransferObject;

public sealed class Company : DataTransferObjectBase.All
{
    public Company(Guid identifier, string documentType, string documentContent, CompanyDocument[] documents, string platformName, string nameReally,
        string language, string country, Guid correlationIdentifier, string sourcePlatform, DateTime createdAt, DateTime updatedAt) 
        : base(identifier, correlationIdentifier, sourcePlatform, createdAt, updatedAt)
    {
        DocumentType = documentType;
        DocumentContent = documentContent;
        PlatformName = platformName;
        RealName = nameReally;
        Language = language;
        Country = country;
        Documents = documents;
    }

    #region Properties

    public string DocumentType { get; set; }
    public string DocumentContent { get; set; }
    public CompanyDocument[] Documents { get; set; }
    public string PlatformName { get; set; }
    public string RealName { get; set; }
    public string Language { get; set; }
    public string Country { get; set; }

    #endregion

    #region Relationships

    public List<Owner>? Owners { get; set; }

    #endregion
}

public sealed class CompanyDocument
{
    public CompanyDocument(string type, string content)
    {
        Type = type;
        Content = content;
    }

    public string Type { get; set; }
    public string Content { get; set; }
}