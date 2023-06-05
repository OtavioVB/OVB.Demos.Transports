namespace OVB.Demos.Transports.CompanyContext.Application.Services.Internal.OwnerContext.Inputs;

public readonly struct CreateOwnerServiceInput
{
    public CreateOwnerServiceInput(string name, string lastName, string language, string country)
    {
        Name = name;
        LastName = lastName;
        Language = language;
        Country = country;
    }

    public string Name { get; init; }
    public string LastName { get; init; }
    public string Language { get; init; }
    public string Country { get; init; }
}
