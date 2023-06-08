using OVB.Demos.Transports.CompanyContext.Application.Services.Internal.CompanyContext.Inputs;
using OVB.Demos.Transports.CompanyContext.Application.Services.Internal.CompanyContext.Outputs;
using OVB.Demos.Transports.Responses;

namespace OVB.Demos.Transports.CompanyContext.Application.Services.Internal.CompanyContext.Interfaces;

public interface ICompanyService
{
    public Task<ResponseBase<CreateCompanyServiceSuccessfullResponse>> CreateCompanyServiceAsync(CreateCompanyServiceInput input, 
        CancellationToken cancellationToken);
}
