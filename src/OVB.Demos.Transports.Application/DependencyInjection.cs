using Microsoft.Extensions.DependencyInjection;
using OVB.Demos.Transports.Application.Services.OutOfBusiness.FileContext;

namespace OVB.Demos.Transports.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationDependenciesConfiguration(this IServiceCollection serviceCollection)
    {
        #region Services Configuration

        serviceCollection.AddSingleton<IFileService, FileService>();

        #endregion


        return serviceCollection;
    }
}
