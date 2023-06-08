using OVB.Demos.Transports.CompanyContext.Domain.Bussines.CompanyContext.DataTransferObject;
using OVB.Demos.Transports.CompanyContext.Infrascructure.EntityFrameworkCore.Repositories.Base;
using OVB.Demos.Transports.CompanyContext.Infrascructure.EntityFrameworkCore.Repositories.Base.Interfaces;

namespace OVB.Demos.Transports.CompanyContext.Infrascructure.EntityFrameworkCore.Repositories;

public sealed class CompanyRepository : BaseRepository<Company>, IExtensionCompanyRepository
{
    public CompanyRepository(CompanyDataContext dataContext) : base(dataContext)
    {
    }
}
