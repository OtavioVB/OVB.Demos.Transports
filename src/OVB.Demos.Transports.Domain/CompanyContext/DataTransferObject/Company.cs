namespace OVB.Demos.Transports.Domain.CompanyContext.DataTransferObject;

public record Company
{
    public Company(Guid identifier, string platformName, string realName, string cnpj, char typeCompany, DateTime createdAt)
    {
        Identifier = identifier;
        PlatformName = platformName;
        RealName = realName;
        Cnpj = cnpj;
        TypeCompany = typeCompany;
        CreatedAt = createdAt;
    }

    public Guid Identifier { get; init; }
    public string PlatformName { get; init; }
    public string RealName { get; init; }
    public string Cnpj { get; init; }
    public char TypeCompany { get; init; }
    public DateTime CreatedAt { get; init; }

    public static string ToUpper = nameof(Company).ToUpper();
}
