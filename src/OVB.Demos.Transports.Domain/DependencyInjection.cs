using Microsoft.Extensions.DependencyInjection;

namespace OVB.Demos.Transports.Domain;

public static class DependencyInjection
{
    public static IServiceCollection AddDomainDependenciesConfiguration(this IServiceCollection serviceCollection)
    {
        return serviceCollection;
    }
}
