using OVB.Demos.Transports.Domain.Results.ErrorResults;
using OVB.Demos.Transports.Domain.Results.Interfaces;

namespace OVB.Demos.Transports.Domain.Results;

public sealed class CommandResult<TSuccessfullEntity> : ICommandResult<TSuccessfullEntity>
{
    private TSuccessfullEntity? Result { get; set; } = default;
    private IEnumerable<NotificationMessage>? NotificationMessages { get; set; } = null;
    private StateResult State { get; set; }

    public CommandResult()
    {
        State = StateResult.Unavailable;
    }

    private const string ResultSetted = "The result already has been setted.";
    private const string InvalidState = "The response model is in an invalid state.";

    public void AddSuccessfullResponse(TSuccessfullEntity entity)
    {
        if (State != StateResult.Unavailable)
            throw new Exception(InvalidState);

        State = StateResult.SuccessfullResult;
        Result = entity;
    }

    public void AddErrorResponse(IEnumerable<NotificationMessage> notificationMessages)
    {
        if (NotificationMessages != null)
            throw new Exception(ResultSetted);

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

    public IEnumerable<NotificationMessage> GetErrorCommandResult()
    {
        if (NotificationMessages == null)
            throw new Exception(InvalidState);

        return NotificationMessages;
    }
}
