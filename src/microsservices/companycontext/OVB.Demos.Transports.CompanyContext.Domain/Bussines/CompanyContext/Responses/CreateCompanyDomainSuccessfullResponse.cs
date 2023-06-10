using OVB.Demos.Transports.Responses;

namespace OVB.Demos.Transports.CompanyContext.Domain.Bussines.CompanyContext.Responses;

public readonly struct CreateCompanyDomainSuccessfullResponse
{
    public CreateCompanyDomainSuccessfullResponse(List<ErrorMessage> informations)
    {
        Informations = informations;
    }

    public List<ErrorMessage> Informations { get; init; }
}
