using OVB.Demos.Transports.Domain.Results.ErrorResults;

namespace OVB.Demos.Transports.Domain.Results.Interfaces;

public interface ICommandCompleteResult<TSuccessfullEntity, TErrorfullEntity>
{
    public void AddSuccessfullResponse(TSuccessfullEntity entity);
    public void AddErrorResponse(TErrorfullEntity error);
    public StateResult GetResultState();
    public TErrorfullEntity GetErrorCommandResult();
    public TSuccessfullEntity GetSuccessfullCommandResult();
}
