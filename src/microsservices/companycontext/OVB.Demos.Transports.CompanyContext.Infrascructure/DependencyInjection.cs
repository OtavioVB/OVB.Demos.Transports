using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OVB.Demos.Transports.CompanyContext.Domain.Bussines.CompanyContext.DataTransferObject;
using OVB.Demos.Transports.CompanyContext.Domain.Bussines.OwnerContext.DataTransferObject;
using OVB.Demos.Transports.CompanyContext.Infrascructure.EntityFrameworkCore;
using OVB.Demos.Transports.CompanyContext.Infrascructure.EntityFrameworkCore.Repositories;
using OVB.Demos.Transports.CompanyContext.Infrascructure.EntityFrameworkCore.Repositories.Base;
using OVB.Demos.Transports.CompanyContext.Infrascructure.EntityFrameworkCore.Repositories.Base.Interfaces;

namespace OVB.Demos.Transports.CompanyContext.Infrascructure;

public static class DependencyInjection
{
    public static IServiceCollection AddMicrosservicesCompanyContextInfrascructureDependenciesConfiguration(this IServiceCollection serviceCollection,
        string connectionString)
    {
        #region Data Context Configuration
        serviceCollection.AddDbContextPool<CompanyDataContext>(p => p.UseNpgsql(connectionString), 512);
        #endregion

        #region Repositories

        #region Company Repository Configuration
        serviceCollection.AddScoped<IBaseRepository<Company>, CompanyRepository>();
        serviceCollection.AddScoped<BaseRepository<Company>, CompanyRepository>();
        serviceCollection.AddScoped<IExtensionCompanyRepository, CompanyRepository>();
        #endregion

        #region Owner Repository Configuration
        serviceCollection.AddScoped<IBaseRepository<Owner>, OwnerRepository>();
        serviceCollection.AddScoped<BaseRepository<Owner>, OwnerRepository>();
        serviceCollection.AddScoped<IExtensionOwnerRepository, OwnerRepository>();
        #endregion

        #endregion

        return serviceCollection;
    }
}
