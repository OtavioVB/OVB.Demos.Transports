using OVB.Demos.Transports.Domain.Results.ErrorResults;

namespace OVB.Demos.Transports.Domain.Results.Interfaces;

public interface ICommandResult<TSuccessfullEntity>
{
    public void AddSuccessfullResponse(TSuccessfullEntity entity);
    public void AddErrorResponse(IEnumerable<NotificationMessage> notificationMessages);
    public StateResult GetResultState();
    public IEnumerable<NotificationMessage> GetErrorCommandResult();
    public TSuccessfullEntity GetSuccessfullCommandResult();
}
