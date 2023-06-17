using OVB.Demos.Transports.Domain.Results.ErrorResults;
using OVB.Demos.Transports.Domain.Results.Interfaces;

namespace OVB.Demos.Transports.Domain.Results;

public sealed class CommandCompleteResult<TSuccessfullEntity, TErrorfullEntity> : ICommandCompleteResult<TSuccessfullEntity, TErrorfullEntity>
{
    private TSuccessfullEntity? Result { get; set; } = default;
    private TErrorfullEntity? NotificationMessages { get; set; } = default;
    private StateResult State { get; set; }

    public CommandCompleteResult()
    {
        State = StateResult.Unavailable;
    }

    private const string InvalidState = "The response model is in an invalid state.";

    public void AddSuccessfullResponse(TSuccessfullEntity entity)
    {
        if (State != StateResult.Unavailable)
            throw new Exception(InvalidState);

        State = StateResult.SuccessfullResult;
        Result = entity;
    }

    public void AddErrorResponse(TErrorfullEntity notificationMessages)
    {
        if (State != StateResult.Unavailable)
            throw new Exception(InvalidState);

        State = StateResult.ErrorResult;
        NotificationMessages = notificationMessages;
    }

    public StateResult GetResultState()
    {
        if (State == StateResult.Unavailable)
            throw new Exception(InvalidState);

        return State;
    }

    public TSuccessfullEntity GetSuccessfullCommandResult()
    {
        if (Result == null)
            throw new Exception(InvalidState);

        return Result;
    }

    public TErrorfullEntity GetErrorCommandResult()
    {
        if (NotificationMessages == null)
            throw new Exception(InvalidState);

        return NotificationMessages;
    }
}
