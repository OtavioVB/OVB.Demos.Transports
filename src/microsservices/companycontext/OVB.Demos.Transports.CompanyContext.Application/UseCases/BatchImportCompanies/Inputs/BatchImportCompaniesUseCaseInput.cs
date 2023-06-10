namespace OVB.Demos.Transports.CompanyContext.Application.UseCases.BatchImportCompanies.Inputs;

public readonly struct BatchImportCompaniesUseCaseInput
{
    public BatchImportCompaniesUseCaseInput(BatchImportCompaniesCompanyInfoUseCaseInput[] companies)
    {
        Companies = companies;
    }

    public BatchImportCompaniesCompanyInfoUseCaseInput[] Companies { get; init; }
}

public readonly struct BatchImportCompaniesCompanyInfoUseCaseInput
{
    public BatchImportCompaniesCompanyInfoUseCaseInput(string name, string platformName, string document, string documentType, string language, 
        string country, BatchImportCompaniesOwnerInfoUseCaseInput[] owners)
    {
        Name = name.Trim();
        PlatformName = platformName.Trim();
        Document = document.Trim();
        DocumentType = documentType.Trim();
        Language = language.Trim();
        Country = country.Trim();
        Owners = owners;
    }

    public string Name { get; init; }
    public string PlatformName { get; init; }
    public string Document { get; init; }
    public string DocumentType { get; init; }
    public string Language { get; init; }
    public string Country { get; init; }
    public BatchImportCompaniesOwnerInfoUseCaseInput[] Owners { get; init; }
}

public readonly struct BatchImportCompaniesOwnerInfoUseCaseInput
{
    public BatchImportCompaniesOwnerInfoUseCaseInput(
        BatchImportCompaniesOwnerPhoneInfoUseCaseInput[] phones, 
        string name, string lastName, string document, string documentType, 
        string language, string country)
    {
        Phones = phones;
        Name = name.Trim();
        LastName = lastName.Trim();
        Document = document.Trim();
        DocumentType = documentType.Trim();
        Language = language.Trim();
        Country = country.Trim();
    }

    public BatchImportCompaniesOwnerPhoneInfoUseCaseInput[] Phones { get; init; }
    public string Name { get; init; }
    public string LastName { get; init; }
    public string Document { get; init; }
    public string DocumentType { get; init; }
    public string Language { get; init; }
    public string Country { get; init; }
}

public readonly struct BatchImportCompaniesOwnerPhoneInfoUseCaseInput
{
    public BatchImportCompaniesOwnerPhoneInfoUseCaseInput(string ddi, string ddd, string phone)
    {
        Ddi = ddi.Trim();
        Ddd = ddd.Trim();
        Phone = phone.Trim();
    }

    public string Ddi { get; init; }
    public string Ddd { get; init; }
    public string Phone { get; init; }
}