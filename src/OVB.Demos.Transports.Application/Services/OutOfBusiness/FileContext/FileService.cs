using Microsoft.AspNetCore.Http;
using OVB.Demos.Transports.Domain.Results;
using OVB.Demos.Transports.Domain.Results.ErrorResults;
using OVB.Demos.Transports.Domain.Results.Interfaces;

namespace OVB.Demos.Transports.Application.Services.OutOfBusiness.FileContext;

public sealed class FileService : IFileService
{
    public static string ExtensionCsvName = ".csv";

    private NotificationMessage FileExtensionNameInvalid =
        new NotificationMessage("FILE01", "The file inserted doesn't have a valid extension name.", TypeMessage.Error);

    public async Task<ICommandResult<IEnumerable<NotificationMessage>>> ValidateIsCsvFileServiceAsync(IFormFile input, CancellationToken cancellationToken)
    {
        var response = new CommandResult<IEnumerable<NotificationMessage>>();
        var messages = new List<NotificationMessage>();

        if (VerifyEndsWithExtensionName(input, ExtensionCsvName) == false)
        {
            messages.Add(FileExtensionNameInvalid);
            response.AddErrorResponse(
                notificationMessages: messages);
            return response;
        }

        response.AddSuccessfullResponse(messages);
        return response;
    }

    private bool VerifyEndsWithExtensionName(IFormFile file, string extension)
        => file.FileName.EndsWith(extension);
}
