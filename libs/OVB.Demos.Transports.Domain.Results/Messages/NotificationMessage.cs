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
}

public enum TypeMessage
{
    Successfull = 1,
    Error = 2,
    Information = 3,
}
