using OVB.Demos.Transports.Domain.Results.ErrorResults;
using OVB.Demos.Transports.Domain.Results.Interfaces;

namespace OVB.Demos.Transports.Application.Services.OutOfBusiness.DeveloperContext.Interfaces;

public interface IAuthorizationService
{
    public Task<ICommandResult<IEnumerable<NotificationMessage>>> DeveloperAuthorizeToMakeChanges(string authorizationCode, CancellationToken cancellationToken);
}
