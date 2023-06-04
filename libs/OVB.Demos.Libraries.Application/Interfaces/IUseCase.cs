namespace OVB.Demos.Libraries.Application.Interfaces;

public interface IUseCase<TInput, TOutput>
{
    public Task<TOutput> ExecuteUseCaseAsync(TInput input, CancellationToken cancellationToken);
}
