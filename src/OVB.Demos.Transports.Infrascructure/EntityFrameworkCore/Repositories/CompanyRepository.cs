using OVB.Demos.Transports.Domain.CompanyContext.DataTransferObject;
using OVB.Demos.Transports.Infrascructure.EntityFrameworkCore.Repositories.Base;
using OVB.Demos.Transports.Infrascructure.EntityFrameworkCore.Repositories.Extensions;

namespace OVB.Demos.Transports.Infrascructure.EntityFrameworkCore.Repositories;

public sealed class CompanyRepository : BaseRepository<Company>, IExtensionCompanyRepository
{
    public CompanyRepository(DataContext dataContext) : base(dataContext)
    {
    }
}
