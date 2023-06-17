namespace OVB.Demos.Transports.Infrascructure.EntityFrameworkCore.Repositories.Extensions;

public interface IExtensionCompanyRepository
{
    public Task<bool> VerifyEntityExistsByCnpjAsync(string cnpj, CancellationToken cancellationToken);
}
