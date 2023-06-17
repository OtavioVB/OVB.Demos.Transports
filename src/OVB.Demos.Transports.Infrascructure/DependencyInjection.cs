using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OVB.Demos.Transports.Domain.CompanyContext.DataTransferObject;
using OVB.Demos.Transports.Infrascructure.EntityFrameworkCore;
using OVB.Demos.Transports.Infrascructure.EntityFrameworkCore.Repositories;
using OVB.Demos.Transports.Infrascructure.EntityFrameworkCore.Repositories.Base;
using OVB.Demos.Transports.Infrascructure.EntityFrameworkCore.Repositories.Base.Interfaces;
using OVB.Demos.Transports.Infrascructure.EntityFrameworkCore.Repositories.Extensions;
using OVB.Demos.Transports.Infrascructure.EntityFrameworkCore.UnitOfWork;
using OVB.Demos.Transports.Infrascructure.EntityFrameworkCore.UnitOfWork.Interfaces;

namespace OVB.Demos.Transports.Infrascructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrascructureDependenciesConfiguration(this IServiceCollection serviceCollection, string? connectionString)
    {
        #region Configuration Params Validations

        if (connectionString == null)
            throw new Exception("The DevOps need to insert a connnectionString in the scheme of configuration for this application.");

        #endregion

        #region Entity Framework Core Context Configuration

        serviceCollection.AddDbContextPool<DataContext>(p => p.UseNpgsql(connectionString, p => p.MigrationsAssembly("OVB.Demos.Transports.Infrascructure")), 10);

        #endregion

        #region Unit Of Work

        serviceCollection.AddScoped<IUnitOfWork, DefaultUnitOfWork>();

        #endregion

        #region Repositories

        serviceCollection.AddScoped<IBaseRepository<Company>, CompanyRepository>();
        serviceCollection.AddScoped<BaseRepository<Company>, CompanyRepository>();
        serviceCollection.AddScoped<IExtensionCompanyRepository, CompanyRepository>();

        #endregion

        return serviceCollection;
    }
}
