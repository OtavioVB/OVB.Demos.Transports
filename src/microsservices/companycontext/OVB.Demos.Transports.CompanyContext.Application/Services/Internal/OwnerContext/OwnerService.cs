using OVB.Demos.Transports.CompanyContext.Application.Services.Internal.OwnerContext.Inputs;
using OVB.Demos.Transports.CompanyContext.Application.Services.Internal.OwnerContext.Outputs;
using OVB.Demos.Transports.Responses;

namespace OVB.Demos.Transports.CompanyContext.Application.Services.Internal.OwnerContext;

public sealed class OwnerService : IOwnerService
{

    public Task<ResponseBase<CreateOwnerSuccessfullResponse>> CreateOwnerServiceAsync(CreateOwnerServiceInput input, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
