using Microsoft.AspNetCore.Http;
using OVB.Demos.Transports.Domain.Results.ErrorResults;
using OVB.Demos.Transports.Domain.Results.Interfaces;

namespace OVB.Demos.Transports.Application.Services.OutOfBusiness.FileContext;

public interface IFileService
{
    public Task<ICommandResult<IEnumerable<NotificationMessage>>> ValidateIsCsvFileServiceAsync(IFormFile input, CancellationToken cancellationToken);
}
