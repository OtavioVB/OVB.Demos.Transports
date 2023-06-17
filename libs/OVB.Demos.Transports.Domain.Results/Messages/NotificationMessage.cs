namespace OVB.Demos.Transports.Domain.Results.ErrorResults;

public readonly struct NotificationMessage
{
    public NotificationMessage(string code, string message, TypeMessage typeMessage)
    {
        Code = code;
        Message = message;
        Type = typeMessage.ToString();
    }

    public string Code { get; init; }
    public string Message { get; init; }
    public string Type { get; init; }

    public static NotificationMessage BuildSuccessfullMessage(string code, string message)
        => new NotificationMessage(code, message, TypeMessage.Successfull);

    public static NotificationMessage BuildErrorMessage(string code, string message)
        => new NotificationMessage(code, message, TypeMessage.Error);

    public static NotificationMessage BuildInformationMessage(string code, string message)
        => new NotificationMessage(code, message, TypeMessage.Information);
}

public enum TypeMessage
{
    Successfull = 1,
    Error = 2,
    Information = 3,
}
