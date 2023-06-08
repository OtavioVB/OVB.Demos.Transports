using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OVB.Demos.Transports.CompanyContext.Infrascructure.EntityFrameworkCore;

namespace OVB.Demos.Transports.CompanyContext.Infrascructure;

public static class DependencyInjection
{
    public static IServiceCollection AddMicrosservicesCompanyContextInfrascructureDependenciesConfiguration(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddDbContextPool<CompanyDataContext>(p => p.UseNpgsql("User Id=admin;Password=1234;Server=localhost;Port=5432;Database=transportsmaintransactionscompany"), 512);
        return serviceCollection;
    }
}
