using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OVB.Demos.Transports.Responses;

public sealed class ResponseBase<TSuccessfullResponse>
{
    private TypeResponse Type { get; set; }
    private TSuccessfullResponse? SuccessfullResponse { get; set; }
    private ErrorResponse? ErrorResponse { get; set; }

    private const string ResponseSetted = "The response was setted.";
    private const string GetIncorrectResponse = "You are trying to get an incorrect responses return.";
    private const string ResponseNull = "The response that you trying to get has not been setted.";

    public void SetSuccessfullResponse(TSuccessfullResponse successfullResponse)
    {
        if (Type != TypeResponse.Unavailable)
            throw new Exception(ResponseSetted);

        SuccessfullResponse = successfullResponse;
        Type = TypeResponse.Success;
    }

    public void SetErrorResponse(ErrorResponse errorResponse)
    {
        if (Type != TypeResponse.Unavailable)
            throw new Exception(ResponseSetted);

        ErrorResponse = errorResponse;
        Type = TypeResponse.Error;
    }

    public TypeResponse GetResponseType()
    {
        return Type;
    }

    public TSuccessfullResponse GetSuccessfullResponse()
    {
        if (Type != TypeResponse.Success)
            throw new Exception(GetIncorrectResponse);

        if (SuccessfullResponse == null)
            throw new Exception(ResponseNull);

        return SuccessfullResponse;
    }

    public ErrorResponse GetErrorResponse()
    {
        if (Type != TypeResponse.Error)
            throw new Exception(GetIncorrectResponse);

        if (ErrorResponse == null)
            throw new Exception(ResponseNull);

        return (ErrorResponse)ErrorResponse;
    }

    public static ResponseBase<TSuccessfullResponse> BuildErrorResponse(ErrorResponse error)
    {
        var response = new ResponseBase<TSuccessfullResponse>();
        response.SetErrorResponse(error);
        return response;
    }

    public static ResponseBase<TSuccessfullResponse> BuildSuccessfullResponse(TSuccessfullResponse successfullResponse)
    {
        var response = new ResponseBase<TSuccessfullResponse>();
        response.SetSuccessfullResponse(successfullResponse);
        return response;
    }
}

public enum TypeResponse
{
    Unavailable = 0,
    Success = 1,
    Error = 2,
}
