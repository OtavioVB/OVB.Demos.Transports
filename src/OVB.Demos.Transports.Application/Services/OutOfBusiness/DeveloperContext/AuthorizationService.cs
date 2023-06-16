using OVB.Demos.Transports.Application.Services.OutOfBusiness.DeveloperContext.Interfaces;
using OVB.Demos.Transports.Domain.Results;
using OVB.Demos.Transports.Domain.Results.ErrorResults;
using OVB.Demos.Transports.Domain.Results.Interfaces;

namespace OVB.Demos.Transports.Application.Services.OutOfBusiness.DeveloperContext;

public sealed class AuthorizationService : IAuthorizationService
{
    public Task<ICommandResult<IEnumerable<NotificationMessage>>> DeveloperAuthorizeToMakeChanges(string authorizationCode, CancellationToken cancellationToken)
    {
        var response = new CommandResult<IEnumerable<NotificationMessage>>();
        response.AddSuccessfullResponse(new List<NotificationMessage>() {  });
        return Task.FromResult((ICommandResult<IEnumerable<NotificationMessage>>)response);
    }
}
