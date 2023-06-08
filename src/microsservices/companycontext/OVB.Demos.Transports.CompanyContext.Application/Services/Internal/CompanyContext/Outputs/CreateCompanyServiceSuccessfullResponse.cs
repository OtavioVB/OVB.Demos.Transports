using OVB.Demos.Transports.Responses;

namespace OVB.Demos.Transports.CompanyContext.Application.Services.Internal.CompanyContext.Outputs;

public readonly struct CreateCompanyServiceSuccessfullResponse
{
    public CreateCompanyServiceSuccessfullResponse(ErrorMessage[] messages)
    {
        Messages = messages;
    }

    public ErrorMessage[] Messages { get; init; }
}
