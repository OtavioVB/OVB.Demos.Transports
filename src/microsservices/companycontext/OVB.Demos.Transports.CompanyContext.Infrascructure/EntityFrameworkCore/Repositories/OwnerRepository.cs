using OVB.Demos.Transports.CompanyContext.Domain.Bussines.OwnerContext.DataTransferObject;
using OVB.Demos.Transports.CompanyContext.Infrascructure.EntityFrameworkCore.Repositories.Base;

namespace OVB.Demos.Transports.CompanyContext.Infrascructure.EntityFrameworkCore.Repositories;

public sealed class OwnerRepository : BaseRepository<Owner>
{
    public OwnerRepository(CompanyDataContext dataContext) : base(dataContext)
    {
    }
}
