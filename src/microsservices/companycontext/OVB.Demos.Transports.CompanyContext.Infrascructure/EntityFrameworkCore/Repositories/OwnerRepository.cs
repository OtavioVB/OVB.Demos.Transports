﻿using OVB.Demos.Transports.CompanyContext.Domain.Bussines.OwnerContext.DataTransferObject;
using OVB.Demos.Transports.CompanyContext.Infrascructure.EntityFrameworkCore.Repositories.Base;
using OVB.Demos.Transports.CompanyContext.Infrascructure.EntityFrameworkCore.Repositories.Base.Interfaces;

namespace OVB.Demos.Transports.CompanyContext.Infrascructure.EntityFrameworkCore.Repositories;

public sealed class OwnerRepository : BaseRepository<Owner>, IExtensionOwnerRepository
{
    public OwnerRepository(CompanyDataContext dataContext) : base(dataContext)
    {
    }
}
