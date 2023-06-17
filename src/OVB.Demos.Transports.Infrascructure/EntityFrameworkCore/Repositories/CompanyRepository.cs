using Microsoft.EntityFrameworkCore;
using OVB.Demos.Transports.Domain.CompanyContext.DataTransferObject;
using OVB.Demos.Transports.Infrascructure.EntityFrameworkCore.Repositories.Base;
using OVB.Demos.Transports.Infrascructure.EntityFrameworkCore.Repositories.Extensions;

namespace OVB.Demos.Transports.Infrascructure.EntityFrameworkCore.Repositories;

public sealed class CompanyRepository : BaseRepository<Company>, IExtensionCompanyRepository
{
    public CompanyRepository(DataContext dataContext) : base(dataContext)
    {
    }

    public Task<bool> VerifyEntityExistsByCnpjAsync(string cnpj, CancellationToken cancellationToken)
    {
        if (_dataContext.Set<Company>().Local.Where(p => p.Cnpj == cnpj).Any() == true)
            return Task.FromResult(true);

        return _dataContext.Set<Company>().Where(p => p.Cnpj == cnpj).AnyAsync(cancellationToken);
    }
}
