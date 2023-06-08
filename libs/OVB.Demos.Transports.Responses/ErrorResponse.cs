namespace OVB.Demos.Transports.Responses;

public readonly struct ErrorResponse
{
    public ErrorResponse(int statusCode, ErrorMessage[] messages)
    {
        StatusCode = statusCode;
        Messages = messages;
    }

    public int StatusCode { get; init; }
    public ErrorMessage[] Messages { get; init; }
}

public readonly struct ErrorMessage
{
    public ErrorMessage(TypeMessage type, string message, string code)
    {
        Type = type.ToString();
        Message = message;
        Code = code;
    }

    public string Type { get; init; }
    public string Message { get; init; }
    public string Code { get; init; }
}

public enum TypeMessage
{
    Error = 1,
    Information = 2,
    Successfull = 3,
}
