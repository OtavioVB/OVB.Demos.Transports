﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OVB.Demos.Transports.Infrascructure.EntityFrameworkCore;

namespace OVB.Demos.Transports.Infrascructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrascructureDependenciesConfiguration(this IServiceCollection serviceCollection, string? connectionString)
    {
        #region Entity Framework Core Context Configuration
        serviceCollection.AddDbContextPool<DataContext>(p => p.UseNpgsql(connectionString, p => p.MigrationsAssembly("OVB.Demos.Transports.Infrascructure")), 10);
        #endregion

        return serviceCollection;
    }
}
